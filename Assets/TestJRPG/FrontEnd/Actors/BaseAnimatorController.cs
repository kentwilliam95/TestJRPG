using System;
using ProjectSims.Simulation.Scripts.StateMachine;
using UnityEngine;

namespace Frontend
{
    public class BaseAnimatorController : MonoBehaviour
    {
        private StateMachine<BaseAnimatorController> _stateMachine;
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public InputCapturer InputCapturer { get; private set; }
        private bool _isEnable;
        private void OnEnable()
        {
            _isEnable = true;
            _stateMachine?.CurrentState.OnEnter(this);
        }

        private void OnDisable()
        {
            _isEnable = false;
            _stateMachine?.CurrentState.OnExit(this);
        }

        private void Start()
        {
            _stateMachine = new StateMachine<BaseAnimatorController>(this);
            ChangeState(new StateIdle());
        }

        private void Update()
        {
            if(!_isEnable)
                return;
            
            _stateMachine?.Update();
        }

        public void ChangeState(IState<BaseAnimatorController> nextState)
        {
            _stateMachine.ChangeState(nextState);
        }
    }   
}