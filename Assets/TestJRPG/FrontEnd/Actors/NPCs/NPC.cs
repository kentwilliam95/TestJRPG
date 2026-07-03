using System;
using frontend.Interfaces;
using UnityEngine;

namespace Frontend
{
    public class NPC: MonoBehaviour, IInteract
    {
        [SerializeField] private GameObject _gointeractSign;
        [SerializeField] private FungusGetOnEndConversation _endConversation;

        public Action OnInteracted { get; set; }
        public Action OnInteractionCompleted { get; set; }

        private void FungusOnEndConversation()
        {
            OnInteractionCompleted?.Invoke();
        }

        public void ShowInteract(BaseActor actor)
        {
            _gointeractSign.SetActive(true);
        }

        public void HideInteract(BaseActor actor)
        {
            _gointeractSign.SetActive(false);
        }

        public void Interact()
        {
            _endConversation.OnEndConversation = FungusOnEndConversation;
            OnInteracted?.Invoke();
            HideInteract(null);
        }
    }
}