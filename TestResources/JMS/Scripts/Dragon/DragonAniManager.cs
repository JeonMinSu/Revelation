using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    수 정 날 : 2018 - 05 - 05
    작 성 자 : 전민수
    수정내역 : DragonManager를 Singleton화로 인한 소스코드 정리
*/

namespace DragonController { 

    public class DragonAniManager : MonoBehaviour
    {
        void Start()
        {
            if (Application.isPlaying)
            {
                //SwicthAnimation("Idle");
            }
        }

        public void TakeOffReadyOn()
        {
            Debug.Log("TakeOffReady");
            BlackBoard.Instance.IsTakeOffReady = true;
        }

    }
}
