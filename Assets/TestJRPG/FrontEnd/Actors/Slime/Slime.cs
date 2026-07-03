using UnityEngine;

namespace frontend
{
    public class Slime : Enemy
    {
        [SerializeField] private Animator _animator;
        public override Animator Animator => _animator;

        protected override void Start()
        {
            base.Start();
            _healthBar.Hide();
        }

        public override void SwitchToBattle()
        {
            _healthBar.Show();
        }

        public override void Hit(float damage)
        {
            if (IsDead)
            {
               return;
            }
            
            _animator.SetTrigger(GameConstant.AnimatorTriggerHurt);
            base.Hit(damage);
            var range = _status.Getvalue(PropertiesCollection.Category.Health);
            _healthBar.SetProgress(range.Value / range.Max);

            if (IsDead)
            {
                _animator.SetTrigger(GameConstant.AnimatorTriggerDead);
                _healthBar.Hide();
            }
        }
    }   
}