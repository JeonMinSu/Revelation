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

        [SerializeField]
        private GameObject _howlingEffect;
        public GameObject HowlingEffect { get{ return _howlingEffect; } }

        [SerializeField]
        private GameObject _rightPowEffect;
        public GameObject RightPowEffect { get { return _rightPowEffect; } }

        [SerializeField]
        private GameObject _rightClaw;
        public GameObject RightClaw { get { return _rightClaw; } }

        [SerializeField]
        private GameObject _leftPowEffect;
        public GameObject LeftPowEffect { get { return _leftPowEffect; } }

        [SerializeField]
        private GameObject _leftClaw;
        public GameObject LeftClaw { get { return _leftClaw; } }


        private static ObjectMovement _dragonMovement;
        public static ObjectMovement DragonMovement { get { return _dragonMovement; } }

        private static DragonStat _stat;
        public static DragonStat Stat { get { return _stat; } }

        private Rigidbody _dragonRigidBody;
        public Rigidbody DragonRigidBody { get { return _dragonRigidBody; } }

        IEnumerator _dragonAiCor;
        
        bool _isInit;

        private void Awake()
        {
            _stat = GetComponent<DragonStat>();
            _dragonMovement = GetComponent<ObjectMovement>();
            _dragonRigidBody = GetComponent<Rigidbody>();

            _dragonAiCor = StartDragonAI();
        }

        // Use this for initialization
        void Start ()
        {

            if (Application.isPlaying)
            {
                CoroutineManager.DoCoroutine(_dragonAiCor);
                _isInit = true;
            }
		
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

        public void Hit(float Damege)
        {
            Stat.HP -= Damege;
            Debug.Log("OnHit");
        }
        
        IEnumerator StartDragonAI()
        {
            while (!_dragonBehaviroTree.Root.Run())
            {
                yield return CoroutineManager.FiexdUpdate;
            }
            Debug.Log("end");
        }
    }

}