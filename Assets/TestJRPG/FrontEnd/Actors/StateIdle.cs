using Frontend;
using ProjectSims.Simulation.Scripts.StateMachine;
using UnityEngine;

namespace Frontend
{
    public class StateIdle : IState<BaseAnimatorController>
    {
        private BaseAnimatorController _animatorController;
        public void OnEnter(BaseAnimatorController t)
        {
            t.InputCapturer.OnMove += InputOnMoveChanged;
            // t.InputCapturer.OnFirePressed += InputOnFirePressed;
            
            _animatorController = t;
            
            t.Animator.SetTrigger("Idle");
        }

        public void OnUpdate(BaseAnimatorController t)
        {
        
        }

        public void OnExit(BaseAnimatorController t)
        {
            t.InputCapturer.OnMove -= InputOnMoveChanged;
            // t.InputCapturer.OnFirePressed -= InputOnFirePressed;
        }

        private void InputOnMoveChanged(Vector2 input)
        {
            if (input.sqrMagnitude > 0)
            {
                _animatorController.ChangeState(new StateRun());
            }
            else
            {
                _animatorController.ChangeState(new StateIdle());
            }
        }
        //
        // private void InputOnFirePressed()
        // {
        //     _actor.ChangeState(new StateAttack());
        // }
    }   
}