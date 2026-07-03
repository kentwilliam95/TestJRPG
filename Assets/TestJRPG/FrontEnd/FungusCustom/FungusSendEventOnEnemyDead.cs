using System;
using Frontend;
using Fungus;
using UnityEngine;

namespace frontend
{
    public class FungusSendEventOnEnemyDead : MonoBehaviour
    {
        [SerializeField] private Flowchart _flowchart;
        [SerializeField] private string _message;

        private void OnDestroy()
        {
            var actor = GetComponentInParent<BaseActor>();
            if (actor)
            {
                actor.OnDead -= ActorOnDead;
            }
        }

        private void Start()
        {
            var actor = GetComponentInParent<BaseActor>();
            if (actor)
            {
                actor.OnDead += ActorOnDead;
            }
        }

        private void ActorOnDead()
        {
            _flowchart.SendFungusMessage(_message);
        }
    }   
}