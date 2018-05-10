using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    만 든 날 : 2018-04-02
    작 성 자 : 전민수

    작성내역 : 베지어곡선을 이용한 노드를 사용하여 오브젝트 이동   

    수 정 날 : 2018 - 05 - 05
    작 성 자 : 전민수
    수정내역 : 소스코드 정리
*/

/*
    수정한날 : 2018 - 04 - 30
    작성자 : 김영민
    수정내역: 업벡터 확인후 드래곤 업벡터 , 월드 업벡터  사용
 */



public class ObjectMovement : MonoBehaviour {

    public List<NodeManager> NodesManager;

    private void Awake()
    { 

    }
    // 노드 찾기 
    /*
    public bool FindNode(int Index)
    {
        if (!NodesManager[Index].IsRotation) { 
            if (NodesManager[Index].IsStick)
            { 
                Vector3 forward = transform.position - NodesManager[Index].transform.position;
                NodesManager[Index].transform.rotation = Quaternion.LookRotation(forward);
                NodesManager[Index].transform.position = transform.position;
                return true;
            }
            else
            {
                Vector3 forward = (NodesManager[Index].transform.position - transform.position).normalized;

                float curSpeed = DragonManager.Stat.CurFlySpeed;
                float speed = NodesManager[Index].Nodes[0].NodeSpeed;

                DragonManager.Stat.CurFlySpeed = BlackBoard.Instance.Acceleration(curSpeed, speed, 38.0f);

                transform.position =
                    Vector3.MoveTowards(
                        transform.position,
                        NodesManager[Index].transform.position,
                        DragonManager.Stat.CurFlySpeed * Time.deltaTime);

                transform.rotation =
                    Quaternion.Lerp(
                        transform.rotation,
                        Quaternion.LookRotation(forward),
                        360.0f * Time.deltaTime);

                return BlackBoard.Instance.DistanceCalc(transform, NodesManager[Index].Nodes[0].transform, 0.0f);
            }
        }
        return true;
    } 
    */

    /* 중심축으로 회전 */
    public void AxisRotation(int Index)
    {
        if (NodesManager[Index].IsRotation)
        {
            Vector3 forward = (NodesManager[Index].transform.position - transform.position).normalized;
            NodesManager[Index].transform.rotation = Quaternion.LookRotation(forward);
        }
    }

    /* 이동 반복 */
    public void MovementLoop(int Index)
    {
        if (NodesManager[Index].IsMoveLoop)
        {
            if (NodesManager[Index].IsMoveEnd)
            {
                NodesManager[Index].CurNodesIndex = 0;
            }
        }
    }

    //노드 포지션 및 로테이션 셋팅
    public void MovementReady(int Index)
    {
        AxisRotation(Index);

        //bool isFindNode = FindNode(Index);
        //if (!isFindNode)
        //    return;


        NodesManager[Index].AllNodesCalc();

        int NodesCount = NodesManager[Index].NodesSpeed.Count;

        for (int nodeIndex = 0; nodeIndex < NodesCount; nodeIndex++)
        {
            NodesManager[Index].Stat.NodeDir.Add(NodesManager[Index].NodesDir[nodeIndex]);
            NodesManager[Index].Stat.NodeSpeed.Add(NodesManager[Index].NodesSpeed[nodeIndex]);
            NodesManager[Index].Stat.NodeRot.Add(NodesManager[Index].NodesRot[nodeIndex]);
        }
        NodesManager[Index].IsMoveReady = true;

    }

    //노드를 따라서 이동 및 회전
    public void Movement(int Index)
    {
        int NodesCount = NodesManager[Index].NodesSpeed.Count;
        int NodesIndex = NodesManager[Index].CurNodesIndex;

        if (NodesIndex < NodesCount)
        {
            NodesManager[Index].IsMoveEnd = false;

            float moveDistance = NodesManager[Index].Stat.NodeSpeed[NodesIndex] * Time.deltaTime;
            float nextDistance = Vector3.Distance(NodesManager[Index].Stat.NodeDir[NodesIndex], transform.position);
            
            Vector3 dir = (NodesManager[Index].Stat.NodeDir[NodesIndex] - transform.position).normalized;
            Vector3 eulerAngle = NodesManager[Index].NodesRot[NodesIndex];
            bool dragonUp = NodesManager[Index].NodesDragonUp[NodesIndex];

            //if (NodesIndex + 1 < NodesCount)
            //{
            //    eulerAngle = (NodesManager[Index].NodesRot[NodesIndex] - NodesManager[Index].Stat.NodeRot[NodesIndex + 1]);
            //}
            

            for (; moveDistance > nextDistance;)
            {
                transform.position += dir * nextDistance;
                moveDistance -= nextDistance;

                NodesManager[Index].CurNodesIndex++;
                NodesIndex = NodesManager[Index].CurNodesIndex;

                if (NodesIndex >= NodesCount)
                    return;
                dir = (NodesManager[Index].Stat.NodeDir[NodesIndex] - transform.position).normalized;

                eulerAngle = NodesManager[Index].Stat.NodeRot[NodesIndex];
                //(NodesManager[Index].Stat.NodeRot[NodesIndex - 1] - NodesManager[Index].Stat.NodeRot[NodesIndex]);


                nextDistance = Vector3.Distance(NodesManager[Index].Stat.NodeDir[NodesIndex],
                    transform.position);

            }

            if (NodesManager[Index].CenterAxisRot != null)
            {
                Vector3 CentralAxis = (NodesManager[Index].CenterAxisRot.position - transform.position).normalized;

                transform.rotation =
                    Quaternion. Slerp(
                        transform.rotation,
                        Quaternion.LookRotation(dir, CentralAxis),
                        45.0f * Time.fixedDeltaTime);
            }
            else
            {
                Quaternion rot;

                if (dragonUp)
                {
                    rot = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(dir, transform.up) * Quaternion.Euler(eulerAngle), 0.1f);
                }
                else
                {
                    rot = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(dir, Vector3.up) * Quaternion.Euler(eulerAngle), 0.1f);
                }
      

                //Quaternion rot = (Quaternion.LookRotation(dir, Vector3.up));
                //Quaternion rot = Quaternion.LookRotation(dir, Dragon.transform.up) 
                //    * Quaternion.Euler(eulerAngle);

                transform.rotation = rot;
            }

            transform.position += dir * moveDistance;

            if (NodesIndex + 1 >= NodesCount)
                return;
            dir = (NodesManager[Index].Stat.NodeDir[NodesIndex] - transform.position).normalized;

        }
        else
        {
            NodesManager[Index].IsMoveEnd = true;
            MovementLoop(Index);
        }
    }


}
