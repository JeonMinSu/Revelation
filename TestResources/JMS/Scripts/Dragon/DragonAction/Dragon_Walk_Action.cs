using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Walk_Action : ActionTask
{
    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float moveSpeed = DragonManager.Stat.MoveSpeed;
        float turnSpeed = DragonManager.Stat.LandTurnSpeed;

        DragonManager.Instance.SwicthAnimation("Walk");

        BlackBoard.Instance.Move(Player, moveSpeed, turnSpeed);
        BlackBoard.Instance.GetStageTime().CurWalkTime += Time.deltaTime;

        return BlackBoard.Instance.DistanceCalc(Dragon, Player, 20.0f);

        /* 횡이동 */
        /*
        if (!BlackBoard.Instance.DistanceCalc(Dragon, Player, 30.0f))
        //{
        //BlackBoard.Instance.Move(Player, moveSpeed, turnSpeed);
        }
        else
        {

            if (!IsRadiusChk)
            {
                Vector3 fixTransPos = new Vector3();

                fixTransPos = Player.position;

                Vector3 forward = (Player.position - Dragon.position).normalized;
                Dragon.rotation = Quaternion.LookRotation(forward);

                BlackBoard.Instance.Radius =
                    Vector3.Distance(Dragon.position, fixTransPos);

                float Dot = Vector3.Dot(Vector3.left, forward);

                if (Dot >= Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f))
                {
                    Vector3 cross = Vector3.Cross(Vector3.left, forward);
                    float Result = Vector3.Dot(cross, Vector3.up);

                    if (Result >= 0)
                    {
                        forward = (Dragon.position - Player.position).normalized;
                        Dot = Vector3.Dot(Vector3.left, forward);
                        BlackBoard.Instance.Theta = Mathf.Acos(Dot) + Mathf.PI;
                    }
                    else { BlackBoard.Instance.Theta = Mathf.Acos(Dot);  }
                }
                else
                {
                    Vector3 cross = Vector3.Cross(Vector3.left, forward);
                    float Result = Vector3.Dot(cross, Vector3.up);

                    if (Result >= 0)
                    {
                        forward = (Dragon.position - Player.position).normalized;
                        Dot = Vector3.Dot(Vector3.left, forward);
                        BlackBoard.Instance.Theta = Mathf.Acos(Dot) + Mathf.PI;
                    }
                    else { BlackBoard.Instance.Theta = Mathf.Acos(Dot); }

                }

                BlackBoard.Instance.IsRadiusChk = true;
                BlackBoard.Instance.FixTargetPos = fixTransPos;

            }

            float angleSpeed = moveSpeed * Mathf.Deg2Rad * Time.deltaTime;

            BlackBoard.Instance.Theta += angleSpeed;

            BlackBoard.Instance.CircleMove(BlackBoard.Instance.FixTargetPos,
            BlackBoard.Instance.Theta);


        }
        */
    }
}
