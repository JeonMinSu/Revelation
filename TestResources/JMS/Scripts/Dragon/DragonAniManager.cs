using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    수 정 날 : 2018 - 05 - 05
    작 성 자 : 전민수
    수정내역 : DragonManager를 Singleton화로 인한 소스코드 정리
*/

namespace DragonController { 

    public class DragonAniManager : MonoBehaviour {

        private string _currentAniName;
        public string CurrentAniName { set { _currentAniName = value; } get { return _currentAniName; } }

        bool _isInit;

        private void Awake()
        {
        }

        private void Start()
        {
            if (Application.isPlaying)
            {
                //SwicthAnimation("Idle");
                _isInit = true;
            }
        }
        /*
        public void SwicthAnimation(string _newAniName)
        {
            if (_isInit)
                DragonManager.Instance.Ani.ResetTrigger(_currentAniName);

            _currentAniName = _newAniName;
            DragonManager.Instance.Ani.SetTrigger(_currentAniName);
        }
        */
        public void TakeOffReadyOn()
        {
            Debug.Log("TakeOffReady");
            BlackBoard.Instance.IsTakeOffReady = true;
        }

    }
}
