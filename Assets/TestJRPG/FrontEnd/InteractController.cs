using System;
using Frontend;
using frontend.Interfaces;
using UnityEngine;

[RequireComponent(typeof(InteractController))]
public class InteractController : MonoBehaviour
{
    [SerializeField] private InputCapturer _inputCapturer;
    private IInteract _currentInteract;
    public Action OnInteractBegan;
    public Action OnInteractEnded;
    private BaseActor _actor;
    
    private void OnEnable()
    {
        _inputCapturer.OnFirePressed += InputOnFirePressed;
        _actor = GetComponentInParent<BaseActor>();
    }

    private void OnDisable()
    {
        _inputCapturer.OnFirePressed -= InputOnFirePressed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var interact = other.GetComponentInParent<IInteract>();
        _currentInteract = interact;
        if (interact != null)
        {
            _currentInteract.OnInteractionCompleted += OnInteractionCompleted;   
        }
        interact?.ShowInteract(_actor);
    }

    private void OnTriggerExit(Collider other)
    {
        var interact = other.GetComponentInParent<IInteract>();
        interact?.HideInteract(_actor);
        _currentInteract = null;
    }

    private void InputOnFirePressed()
    {
        if (_currentInteract == null)
        {
            return;
        }
        
        enabled = false;
        OnInteractBegan?.Invoke();
        _currentInteract?.Interact();
    }

    private void OnInteractionCompleted()
    {
        _currentInteract.OnInteractionCompleted -= OnInteractionCompleted;   
        enabled = true;
        OnInteractEnded?.Invoke();
        _currentInteract = null;
    }
}
