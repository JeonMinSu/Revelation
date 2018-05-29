﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonController {

    public class DragonStat : MonoBehaviour {
        [Space]
        [Header("Boss Move Speed")]
        [SerializeField]
        private float _moveSpeed = 10.0f;
        public float MoveSpeed { set { _moveSpeed = value; } get { return _moveSpeed; } }

        [SerializeField]
        private float _turnSpeed = 360.0f;
        public float TurnSpeed { set { _turnSpeed = value; } get { return _turnSpeed; } }

        [SerializeField]
        private float _walkSpeed = 10.0f;
        public float WalkSpeed { set { _walkSpeed = value; } get { return _walkSpeed; } }

        [SerializeField]
        private float _animSpeed = 0.0f;
        public float AnimSpeed { set { _animSpeed = value; } get { return _animSpeed; } }

        [SerializeField]
        private float _idleAnimSpeed = 1.0f;
        public float IdleAnimSpeed { set { _idleAnimSpeed = value; } get { return _idleAnimSpeed; } }

        //[SerializeField]
        //private float _curRushSpeed;
        //public float CurRushSpeed { set { _curRushSpeed = value; } get { return _curRushSpeed; } }

        //[SerializeField]
        //private float _maxRushSpeed;
        //public float MaxRushSpeed { set { _maxRushSpeed = value; } get { return _maxRushSpeed; } }

        //[SerializeField]
        //private float _accRushSpeed;
        //public float AccRushSpeed { set { _accRushSpeed = value; } get { return _accRushSpeed; } }

        [Space]
        [Header("Boss flying Speed")]

        [SerializeField]
        private float _maxTakeOffSpeed;
        public float MaxTakeOffSpeed { set { _maxTakeOffSpeed = value; } get { return _maxTakeOffSpeed; } }

        [SerializeField]
        private float _accTakeOffeSpeed;
        public float AccTakeOffeSpeed { set { _accTakeOffeSpeed = value; } get { return _accTakeOffeSpeed; } }

        [SerializeField]
        private float _curFlySpeed;
        public float CurFlySpeed { set { _curFlySpeed = value; } get { return _curFlySpeed; } }

        [SerializeField]
        private float _maxFlySpeed;
        public float MaxFlySpeed { set { _maxFlySpeed = value; } get { return _maxFlySpeed; } }

        [Space]
        [Header("Boss HPBar")]

        [SerializeField]
        private float _maxHP;
        public float MaxHP { set { _maxHP = value; } get { return _maxHP; } }

        [SerializeField]
        private float _hp;
        public float HP { set { _hp = value; } get { return _hp; } }

        /*
        [SerializeField]
        private float _landHP;
        public float LandHP { set { _landHP = value; } get { return _landHP; } }

        [SerializeField]
        private float _landHpPercent;
        public float LandHpPercent { get { return _landHpPercent; } }

        [SerializeField]
        private float _takeOffHP;
        public float TakeOffHP { set { _takeOffHP = value; } get{ return _takeOffHP; }}

        [SerializeField]
        private float _takeOffHpPercent;
        public float TakeOffHpPercent { set { _takeOffHpPercent = value; } get { return _takeOffHpPercent; } }
        */

        [Space]
        [Header("Boss Phase HPBar Precent")]

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _firstPhaseHpPercent;
        public float FirstPhaseHpPercent { set { _firstPhaseHpPercent = value; } get { return _firstPhaseHpPercent; } }

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _secondPhaseHpPercent;
        public float SecondPhaseHpPercent { set { _secondPhaseHpPercent = value; } get { return _secondPhaseHpPercent; } }

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _thirdPhaseHpPercent;
        public float ThirdPhaseHpPercent { set { _thirdPhaseHpPercent = value; } get { return _thirdPhaseHpPercent; } }

        [Space]
        [Header("Boss State HPBar Precent")]

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _groggyHpPercent;
        public float GroggyHpPercent { set { _groggyHpPercent = value; } get { return _groggyHpPercent; } }


        //[SerializeField]
        //private float _changedHP;
        //public float ChangedHP { set { _changedHP = value; } get { return _changedHP; } }

        public void Awake()
        {
            //_changedHP = _maxHP;

            //_takeOffHP = _maxHP * _takeOffHpPercent;
            //_landHP = _maxHP * _landHpPercent;

        }

    }
}
