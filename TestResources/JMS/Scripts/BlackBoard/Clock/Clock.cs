using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [System.Serializable]
    public class StageTimes
    {
        private float _curIdleTime;
        public float CurIdleTime { set { _curIdleTime = value; } get { return _curIdleTime; } }

        [SerializeField]
        private float _idleTime;
        public float IdleTime { set { _idleTime = value; } get { return _idleTime; } }

        [SerializeField]
        private float _minWalkChangeTime;
        public float MinWalkChangeTime { get { return _minWalkChangeTime; } }

        [SerializeField]
        private float _maxWalkChangeTime;
        public float MaxWalkChangeTime { get { return _maxWalkChangeTime; } }

        private float _curWalkTime = 0.0f;
        public float CurWalkTime { set { _curWalkTime = value; } get { return _curWalkTime; } }

        private float _walkChangeTime;
        public float WalkChangeTime { set { _walkChangeTime = value; } get { return _walkChangeTime; } }

        [SerializeField]
        private float _preRushTime;
        public float PreRushTime { get { return _preRushTime; } }

        [SerializeField]
        private float _rushRunTime;
        public float RushRunTime { set { _rushRunTime = value; } get { return _rushRunTime; } }

        [SerializeField]
        private float _afterRushTime;
        public float AfterRushTime { get { return _afterRushTime; } }

        [SerializeField]
        private float _preOverLapTime;
        public float PreOverLapTime { get { return _preOverLapTime; } }

        [SerializeField]
        private float _overLapRunTime;
        public float OverLapRunTime { set { _overLapRunTime = value; } get{ return _overLapRunTime; } }

        [SerializeField]
        private float _afterOverLapTime;
        public float AfterOverLapTime { get { return _afterOverLapTime; } }

        public void InitTime()
        {
            _curIdleTime = 0.0f;
            _curWalkTime = 0.0f;
        }
    }

    [System.Serializable]
    public class FlyingTimes
    {

        /* 호버링 시간 */
        [SerializeField]
        private float _hoveringTime;
        public float HoveringTime { set { _hoveringTime = value; } get { return _hoveringTime; } }

        [SerializeField]
        private float _curHoveringTime;
        public float CurHoveringTime { set { _curHoveringTime = value; } get { return _curHoveringTime; } }

        /* 나는 시간 */
        [SerializeField]
        private float _flyTime;
        public float FlyTime { get { return _flyTime; } }

        [SerializeField]
        private float _curFlyTime;
        public float CurFlyTime { set { _curFlyTime = value; } get { return _curFlyTime; } }

        /* 유도탄 */
        [SerializeField]
        private float _preMissileTime;
        public float PreMissileTime { set { _preMissileTime = value; } get { return _preMissileTime; } }

        [SerializeField]
        private float _afterMissileTime;
        public float AfterMissileTime { set { _afterMissileTime = value; } get { return _afterMissileTime; } }

        /* 브레스 */
        [SerializeField]
        private float _preBreathTime;
        public float PreBreathTime { set { _preBreathTime = value; } get { return _preBreathTime; } }

        [SerializeField]
        private float _runBreathTime;
        public float RunBreathTime { set { _runBreathTime = value; } get { return _runBreathTime; } }

        [SerializeField]
        private float _afterBreathTime;
        public float AfterBreathTime { set { _afterBreathTime = value; } get { return _afterBreathTime; } }


        /* 얼음탄환  */
        [SerializeField]
        private float _preIceBulletTime;
        public float PreIceBulletTime { set { _preIceBulletTime = value; } get { return _preIceBulletTime; } }

        [SerializeField]
        private float _runIceBulletTime;
        public float RunIceBulletTime { set { _runIceBulletTime = value; } get { return _runIceBulletTime; } }

        [SerializeField]
        private float _afterIceBulletTime;
        public float AfterIceBulletIime { set { _afterIceBulletTime = value; } get { return _afterIceBulletTime; } }



        public void InitTime()
        {
            _curHoveringTime = 0.0f;
            _curFlyTime = 0.0f;
        }
        
    }

    [SerializeField]
    private StageTimes _stageTime;
    public StageTimes StageTime { get { return _stageTime; } }

    [SerializeField]
    private FlyingTimes _flyingTime;
    public FlyingTimes Flyingtime { get { return _flyingTime; } }

    [SerializeField]
    private float _fallingTime;
    public float FallingTime { set { _fallingTime = value; } get { return _fallingTime; } }

    public void InitLandTimes()
    {
        _stageTime.InitTime();
    }

    public void InitFlyingTime()
    {
        Flyingtime.InitTime();
    }

    private void Awake()
    {
        _stageTime.WalkChangeTime = Random.Range(_stageTime.MinWalkChangeTime, _stageTime.MaxWalkChangeTime);
    }

}
