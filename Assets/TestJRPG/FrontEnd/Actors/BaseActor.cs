using System;
using frontend;
using UnityEngine;

namespace Frontend
{
    public abstract class BaseActor: MonoBehaviour, IHitable
    {
        protected PropertiesCollection _status;
        public PropertiesCollection Status => _status;
        
        [SerializeField] protected ActorData _statData;
        public virtual bool IsDead { get; protected set; }
        public Action OnDead;

        public virtual Animator Animator { get; }
        
        public abstract bool ReceiveItem(Item item);
        public abstract void SwitchToBattle();
        public abstract void SwitchToNormal();
        public abstract void Hit(float damage);
    }
}