using System;
using Fungus;
using UnityEngine;

public class FungusSendEventOnTrigger : MonoBehaviour
{
    [SerializeField] private Flowchart _flowchart;
    [SerializeField] private string _eventMessage;
    public void OnTriggerEnter(Collider other)
    {
        _flowchart.SendFungusMessage(_eventMessage);
    }
}
