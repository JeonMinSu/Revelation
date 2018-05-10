using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonController { 

    public class DragonStat : MonoBehaviour {

        [SerializeField]
        private float _moveSpeed = 10.0f;
        public float MoveSpeed { set { _moveSpeed = value; } get { return _moveSpeed; } }

        [SerializeField]
        private float _turnSpeed = 70.0f;
        public float TurnSpeed { set { _turnSpeed = value; } get { return _turnSpeed; } }

        [SerializeField]
        private float _landMoveSpeed = 10.0f;
        public float LandMoveSpeed { set { _landMoveSpeed = value; } get { return _landMoveSpeed; } }

        [SerializeField]
        private float _landTurnSpeed = 180.0f;
        public float LandTurnSpeed { set { _landTurnSpeed = value; } get { return _landTurnSpeed; } }

        [SerializeField]
        private float _curRushSpeed;
        public float CurRushSpeed { set { _curRushSpeed = value; } get { return _curRushSpeed; } }

        [SerializeField]
        private float _maxRushSpeed;
        public float MaxRushSpeed { set { _maxRushSpeed = value; } get { return _maxRushSpeed; } }

        [SerializeField]
        private float _accRushSpeed;
        public float AccRushSpeed { set { _accRushSpeed = value; } get { return _accRushSpeed; } }

        [SerializeField]
        private float _curTakeOffDir;
        public float CurTakeOffDir { set { _curTakeOffDir = value; } get { return _curTakeOffDir; } }

        [SerializeField]
        private float _maxTakeOffSpeed;
        public float MaxTakeOffSpeed { set { _maxTakeOffSpeed = value; } get { return _maxTakeOffSpeed; } }

        [SerializeField]
        private float _accTakeOffeSpeed;
        public float AccTakeOffeSpeed { set { _accTakeOffeSpeed = value; } get { return _accTakeOffeSpeed; } }

        [SerializeField]
        private float _curFlySpeed;
        public float CurFlySpeed{ set { _curFlySpeed = value; } get { return _curFlySpeed; } }

        [SerializeField]
        private float _maxFlySpeed;
        public float MaxFlySpeed { set { _maxFlySpeed = value; } get { return _maxFlySpeed; } }

        [SerializeField]
        private float _maxHP;
        public float MaxHP { set { _maxHP = value; } get { return _maxHP; } }

        [SerializeField]
        private float _hp;
        public float HP { set { _hp = value; } get { return _hp; } }

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

        [SerializeField]
        private float _firstPhaseHpPercent;
        public float FirstPhaseHpPercent { set { _firstPhaseHpPercent = value; } get { return _firstPhaseHpPercent; } }

        [SerializeField]
        private float _secondPhaseHpPercent;
        public float SecondPhaseHpPercent { set { _secondPhaseHpPercent = value; } get { return _secondPhaseHpPercent; } }

        [SerializeField]
        private float _thirdPhaseHpPercent;
        public float ThirdPhaseHpPercent { set { _thirdPhaseHpPercent = value; } get { return _thirdPhaseHpPercent; } }

        [SerializeField]
        private float _changedHP;
        public float ChangedHP { set { _changedHP = value; } get { return _changedHP; } }

        [SerializeField]
        private float _sight = 5.0f;
        public float Sight { set { _sight = value; }  get { return _sight; } }

        [SerializeField]
        private float _chaseSight = 10.0f;
        public float ChaseSight { set { _chaseSight = value; } get { return _chaseSight; } }

        [SerializeField]
        private float _damege = 10.0f;
        public float Damege { set { _damege = value; } get { return _damege; } }

        [SerializeField]
        private float _attackRange = 2.0f;
        public float AttackRange { set { _attackRange = value; } get { return _attackRange; } }

        public void Awake()
        {
            _changedHP = _maxHP;

            _takeOffHP = _maxHP * _takeOffHpPercent;
            _landHP = _maxHP * _landHpPercent;

        }

    }
}
