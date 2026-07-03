using System;
using Frontend;

namespace frontend.Interfaces
{
    public interface IInteract
    {
        public Action OnInteracted { get; set; }
        public Action OnInteractionCompleted { get; set; }
        public void ShowInteract(BaseActor actor);
        public void HideInteract(BaseActor actor);
        public void Interact();
    }
}