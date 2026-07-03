using Frontend;
using ProjectSims.Simulation.Scripts.StateMachine;
using UnityEngine;

namespace Frontend
{
    public class StateAttack : IState<BaseAnimatorController>
    {
        private float _countdown;
        public void OnEnter(BaseAnimatorController t)
        {
            t.Animator.SetTrigger("Attack");
            _countdown = 0.25f;
        }

        public void OnUpdate(BaseAnimatorController t)
        {
            _countdown -= Time.deltaTime;
            if(_countdown <= 0)
                t.ChangeState(new StateIdle());
        }

        public void OnExit(BaseAnimatorController t)
        {
        
        }
    }   
}