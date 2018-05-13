using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    수 정 날 : 2018 - 05 - 05
    작 성 자 : 전민수
    수정내역 : DragonManager를 Singleton화로 인한 소스코드 정리
*/

public class BlackBoard : Singleton<BlackBoard>
{

    [SerializeField]
    private Transform _dragonMouth;
    public Transform DragonMouth { get { return _dragonMouth; } }

    private Clock _clocks;
    public Clock Clocks { get { return _clocks; } }

    /* 보스몹 HP 상태 관련 변수 */
    //[SerializeField]
    //private float _maxHpTakeOffPercent;
    //public float MaxHpTakeOffPercent { get { return _maxHpTakeOffPercent; } }

    //[SerializeField]
    //private float _hpTakeOff;
    //public float HpTakeOff { set { _hpTakeOff = value; } get { return _hpTakeOff; } }

    //[SerializeField]
    //private float _maxHpLandPercent;
    //public float MaxHpLandPercent { get { return _maxHpLandPercent; } }

    //[SerializeField]
    //private float _hpLand;
    //public float HpLand { set { _hpLand = value; } get { return _hpLand; } }

    //[SerializeField]
    //private float _changedHP;
    //public float ChangedHP { set { _changedHP = value; } get { return _changedHP; } }

    /* 보스몹 페이즈 관련 변수 */
    //[SerializeField]
    //private float _hpPhaseSecond;
    //public float HpPhaseSecond { set { _hpPhaseSecond = value; } get { return _hpPhaseSecond; } }

    //[SerializeField]
    //private float _hpPhaseThird;
    //public float HpPhaseThird { set { _hpPhaseThird = value; } get { return _hpPhaseThird; } }

    [Space]
    [Header("Boss Action Distance")]

    /* 보스몹 액션 거리 변수 */
    [SerializeField]
    private float _takeOffDistance;     //이륙거리(보스몹과 플레이어의 거리를 측정하여 이륙)
    public float TakeOffDistance { set { _takeOffDistance = value; } get { return _takeOffDistance; } }

    private bool _isTakeOffEnd;         //이륙이 끝났는지
    public bool IsTakeOffEnd { set { _isTakeOffEnd = value; } get { return _isTakeOffEnd; } }

    [SerializeField]
    private float _rushDistance;
    public float RushDistance { set { _rushDistance = value; } get { return _rushDistance; } }

    [SerializeField]
    private float _overLapDistance;
    public float OverLapDistance { set { _overLapDistance = value; } get { return _overLapDistance; } }

    /* 보스몹 이동 거리*/
    [Space]
    [Header("Boss Move Distance ")]

    [SerializeField]
    private float _overLapMoveDistance;
    public float OverLapMoveDistance { get { return _overLapMoveDistance; } }

    [SerializeField]
    private float _rushMoveDistance;
    public float RushMoveDistance { get { return _rushMoveDistance; } }


    [Space]
    [Header("Boss State")]
    /* 보스몹 해야되는 행동 관련 변수 */
    [SerializeField]
    private bool _isGround;      //땅 상태
    public bool IsGround { set { _isGround = value; } get { return _isGround; } }

    private bool _isLanding;    //착륙 상태
    public bool IsLanding { set { _isLanding = value; } get { return _isLanding; } }

    private bool _isIdle;       //아이들 상태
    public bool IsIdle { set { _isIdle = value; } get { return _isIdle; } }
    
    [SerializeField]
    private bool _isWalk;       //걷기 상태
    public bool IsWalk { set { _isWalk = value; }  get { return _isWalk; } }

    private bool _isTakeOffReady;//이륙 준비 상태
    public bool IsTakeOffReady { set { _isTakeOffReady = value; } get { return _isTakeOffReady; } }

    private bool _isTakeOff;    //이륙 상태
    public bool IsTakeOff { set { _isTakeOff = value; } get { return _isTakeOff; } }

    [SerializeField]
    private bool _isHovering;   //호버링 상태
    public bool IsHovering{ set { _isHovering = value; } get { return _isHovering; } }

    private bool _isFlying;     //플라잉 상태
    public bool IsFlying { set { _isFlying = value; } get { return _isFlying; } }

    private bool _isWeakPoint;  //약점 상태
    public bool IsWeakPoint { set { _isWeakPoint = value; } get { return _isWeakPoint; } }

    private bool _isAttack;     //공격 상태
    public bool IsAttack { set { _isAttack = value; } get { return _isAttack; } }

    [Space]
    [Header("Boss Pattern On")]
    /* 보스몹 행동 중 관련 변수 */
    [SerializeField]
    private bool _isGroundPatternAct;   //땅에서 패턴을 사용하고 있는지
    public bool IsGroundPatternAct { set { _isGroundPatternAct = value; } get { return _isGroundPatternAct; } }

    [SerializeField]
    private bool _isLandingAct;         //착륙 액션을 하고 있는지
    public bool IsLandingAct { set { _isLandingAct = value; } get { return _isLandingAct; } }

    [SerializeField]
    private bool _isTakeOffAct;         //이륙 액션을 하고 있는지
    public bool IsTakeOffAct { set { _isTakeOffAct = value; } get { return _isTakeOffAct; } }

    [SerializeField]
    private bool _isHoveringPatternAct;  //호버링 패턴을 사용하고 있는지
    public bool IsHoveringPatternAct { set { _isHoveringPatternAct = value; } get { return _isHoveringPatternAct; } }

    [SerializeField]
    private bool _isFlyingPatternAct;    //플라잉 패턴을 하고 있는지
    public bool IsFlyingPatternAct { set { _isFlyingPatternAct = value; } get { return _isFlyingPatternAct; } }

    [Space]
    [Header("Boss Ensuing On")]

    /* 보스 2차 공격 패턴 */
    [SerializeField]
    private bool _isSecondaryOverLap;   //덮치기 2차 공격
    public bool IsSecondaryOverLap { set { _isSecondaryOverLap = value; } get { return _isSecondaryOverLap; } }

    [SerializeField]
    private bool _isSecondaryRush;      //돌격 2차 공격
    public bool IsSecondaryRush { set { _isSecondaryRush = value; } get { return _isSecondaryRush; } }


    [Header("IceCrystal")]
    /* 현재 얼음결정 개수 */
    [SerializeField]
    private int _curIceCrystalNum;
    public int CurIceCrystalNum { set { _curIceCrystalNum = value; } get { return _curIceCrystalNum; } }

    /* IceBullet(얼음탄환) 얼음 결정 개수 */
    [SerializeField]
    private int _maxIceBulletCrystalNum;
    public int MaxIceBulletCrystalNum { set { _maxIceBulletCrystalNum = value; } get { return _maxIceBulletCrystalNum; } }

    [SerializeField]
    private int _minIceBulletCrystalNum;
    public int MinIceBulletCrtystalNum { set { _minIceBulletCrystalNum = value; } get { return _minIceBulletCrystalNum; } }

    /* Missile(유도탄) 얼음 결정 개수 */
    [SerializeField]
    private int _maxHommingBulletCrystalNum;
    public int MaxHommingBulletCrystalNum { set { _maxHommingBulletCrystalNum = value; } get{ return _maxHommingBulletCrystalNum; } }

    [SerializeField]
    private int _maxBreathCrystalNum;
    public int MaxBreathCrystalNum { set { _maxBreathCrystalNum = value; }  get { return _maxBreathCrystalNum; } }


    [Header("WeakPoint")]

    [SerializeField]
    private int _curWeakPointCount;
    public int CurWeakPointCount { set { _curWeakPointCount = value; } get { return _curWeakPointCount; } }

    [SerializeField]
    private int _maxWeakPointCount;
    public int MaxWeakPointCount { set { _maxWeakPointCount = value; } get { return _maxWeakPointCount; } }


    [Header("PlayerHP Dummy")]
    /* 나중에 지워야 됨!!! */
    public float PlayerMaxHP;
    public float CurPlayerHP;

  
    public void InitMember()
    {
        _isGround = true;
        _clocks = GetComponentInChildren<Clock>();
    }

    public Clock.GroundTimes GetGroundTime()
    {
        return _clocks.GroundTime;
    }

    public Clock.FlyingTimes GetFlyingTime()
    {
        return _clocks.Flyingtime;
    }

    public void Move(Transform Target, float MoveSpeed, float TurnSpeed)
    {
        Transform Dragon = DragonManager.Instance.transform;

        if (Dragon.position != Target.position)
        {
            Vector3 forward = Target.position - Dragon.position;

            if (forward != Vector3.zero)
            {
                Dragon.rotation =
                    Quaternion.RotateTowards(
                        Dragon.rotation,
                        Quaternion.LookRotation(forward),
                        TurnSpeed * Time.deltaTime);

                Vector3 nextPos =
                    Vector3.MoveTowards(
                        Dragon.position,
                        Target.position,
                        MoveSpeed * Time.deltaTime);

                Dragon.position = nextPos;

            }
        }


    }

    /*
    public void CircleMove(Vector3 Target, float Radian)
    {
        Transform dragon = DragonManager.Instance.transform;

        Vector3 circlePos = GetCirclePos(Target, Radian);
        Vector3 forward = (Target - dragon.position).normalized;

        dragon.position = circlePos;
        dragon.rotation = Quaternion.LookRotation(forward);

    }
    */

    public float Acceleration(float fCurSpeed, float fMaxSpeed, float fAccSpeed)
    {
        if (fCurSpeed >= fMaxSpeed)
            return fMaxSpeed;
        else
        {
            float dir = Mathf.Sign(fMaxSpeed - fCurSpeed);
            fCurSpeed += fAccSpeed * dir * Time.fixedDeltaTime;
            return (dir == Mathf.Sign(fMaxSpeed - fCurSpeed)) ? fCurSpeed : fMaxSpeed;
        }

    }

    /*
    public Vector3 GetCirclePos(Vector3 Target, float Radian)
    {
        Vector3 retPos;

        Transform dragon = DragonManager.Instance.transform;

        float x = Mathf.Cos(Radian) * Radius + Target.x;
        float z = Mathf.Sin(Radian) * Radius + Target.z;

        retPos = new Vector3(x, dragon.position.y, z);
        return retPos;

    }
    */

    public bool DistanceCalc(Transform _this, Transform _target, float Range)
    {
        if (Vector3.Distance(_this.position, _target.position) <= Range)
            return true;

        return false;
    }

    public NodeManager GetNodeManager(MOVEMENTTYPE Type)
    {
        return DragonManager.DragonMovement.GetNodeManager(Type);
    }

    public bool IsMoveReady(MOVEMENTTYPE Type)
    {
        return GetNodeManager(Type).IsMoveReady;
    }

    public void MovementReady(MOVEMENTTYPE Type)
    {
        DragonManager.DragonMovement.MovementReady(Type);
    }

    public void FlyingMovement(MOVEMENTTYPE Type)
    {
        DragonManager.DragonMovement.Movement(Type);
    }

    /*
    public void HoveringPatternChk()
    {
        if (CurPlayerHP >= PlayerMaxHP * 0.5f &&
            CurIceCrystalNum < MissileCrystalNum)
        {
            IsFlying = false;
            FlyingAct = false;
            IsHovering = true;
            GetFlyingTime().CurHoveringTime = 0.0f;
            return;
        }

        if (CurPlayerHP < PlayerMaxHP * 0.5 &&
            CurIceCrystalNum < BreathCrystalNum)
        {
            IsFlying = false;
            FlyingAct = false;
            IsHovering = true;
            GetFlyingTime().CurHoveringTime = 0.0f;
            return;
        }

    }
    */

}
