﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DragonController
{
    [RequireComponent(typeof(DragonStat))]
    [RequireComponent(typeof(ObjectMovement))]
    [RequireComponent(typeof(Rigidbody))]
    public class DragonManager : Singleton<DragonManager> {

        [SerializeField]
        private BehaviorTree _dragonBehaviroTree;
        public BehaviorTree DragonBehaviroTree { get { return _dragonBehaviroTree; } }

        private static ObjectMovement _dragonMovement;
        public static ObjectMovement DragonMovement { get { return _dragonMovement; } }

        private static DragonStat _stat;
        public static DragonStat Stat { get { return _stat; } }

        private Transform _player;
        public Transform Player { get { return _player; } }

        private Rigidbody _dragonRigidBody;
        public Rigidbody DragonRigidBody { get { return _dragonRigidBody; } }

        private Animator _ani;
        public Animator Ani { get { return _ani; } }

        private string _aniParamName;
        public string AniParamName { set { _aniParamName = value; } get { return _aniParamName; } }

        IEnumerator _dragonAiCor;

        //private int _aniParamID;
        //public int AniParamID { set { _aniParamID = value; } get { return _aniParamID; } }
        
        bool _isInit;

        private void Awake()
        {
            BlackBoard.Instance.InitMember();

            _player = GameObject.FindWithTag("Player").transform;
            _stat = GetComponent<DragonStat>();
            _dragonMovement = GetComponent<ObjectMovement>();
            _ani = GetComponentInChildren<Animator>();

            _dragonRigidBody = GetComponent<Rigidbody>();

            _dragonAiCor = StartDragonAI();

        } 

        // Use this for initialization
        void Start () {
         
            if (Application.isPlaying)
            {
                CoroutineManager.DoCoroutine(_dragonAiCor);
                _isInit = true;
            }
		
	    }

        public void FixedUpdate()
        {
        }

        public bool IsFindNode(MOVEMENTTYPE Type)
        {
            NodeManager NodesPath = DragonMovement.GetNodeManager(Type);

            if (!NodesPath.IsRotation)
            {
                if (NodesPath.IsStick)
                {
                    Vector3 forward = (transform.position - NodesPath.transform.position).normalized;

                    Vector3 changePos = new Vector3(transform.position.x, NodesPath.transform.position.y, transform.position.z);

                    NodesPath.transform.position = changePos;
                    NodesPath.transform.rotation = transform.rotation;

                    Debug.Log("NodePath Find");
                    return true;
                }
            }
            Debug.Log("NodePath No Find");
            return false;
        }

        public void SwicthAnimation(string _newAniName)
        {
            if (_isInit)
                Ani.ResetTrigger(_aniParamName);

            _aniParamName = _newAniName;
            Ani.SetTrigger(_aniParamName);
        }

        IEnumerator StartDragonAI()
        {
            while (!_dragonBehaviroTree.Root.Run())
            {
                yield return CoroutineManager.FiexdUpdate;
            }
            Debug.Log("end");
        }

        public void Hit(float Damege)
        {
            Stat.HP -= Damege;
            Debug.Log("OnHit");
        }

    }

}