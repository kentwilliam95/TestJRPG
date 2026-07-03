using Frontend;
using ProjectSims.Simulation.Scripts.StateMachine;
using UnityEngine;

namespace Frontend
{
    public class StateRun : IState<BaseAnimatorController>
    {
        private BaseAnimatorController _animatorController;
        public void OnEnter(BaseAnimatorController t)
        {
            // t.InputCapturer.OnMove += InputOnMoveChanged;
            t.InputCapturer.OnMoveReleased += InputOnMoveReleased;
            t.Animator.SetTrigger("Moving");
            _animatorController = t;
            
        }

        public void OnUpdate(BaseAnimatorController t)
        {
        
        }

        public void OnExit(BaseAnimatorController t)
        {
            // t.InputCapturer.OnMove -= InputOnMoveChanged;
            t.InputCapturer.OnMoveReleased -= InputOnMoveReleased;
        }
        
        private void InputOnMoveChanged(Vector2 input)
        {

        }

        private void InputOnMoveReleased(Vector2 velocity)
        {
            _animatorController.ChangeState(new StateIdle());
        }
    }   
}