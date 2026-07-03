using System;
using frontend.Interfaces;
using Fungus;
using UnityEngine;

public class FungusSendEventOnInteract : MonoBehaviour
{
    [SerializeField] private Flowchart _flowchartTarget;
    [SerializeField] private string _fungusMessage;
    private IInteract _interact;
    private void Start()
    {
        var interact = GetComponent<IInteract>();
        if (interact != null)
        {
            _interact = interact;
            _interact.OnInteracted += InteractOnInteractionCompleted;
        }
    }

    private void OnDestroy()
    {
        _interact.OnInteracted -= InteractOnInteractionCompleted;
    }

    private void InteractOnInteractionCompleted()
    {
        _flowchartTarget.SendFungusMessage(_fungusMessage);
    }
}
