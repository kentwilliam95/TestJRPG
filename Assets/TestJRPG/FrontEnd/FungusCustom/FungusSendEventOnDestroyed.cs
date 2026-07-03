using System;
using Fungus;
using UnityEngine;
using UnityEngine.Serialization;

namespace frontend
{
    public class FungusSendEventOnDestroyed : MonoBehaviour
    {
        [SerializeField] private Flowchart _flowchartTarget;
        [SerializeField] private string _fungmessage;
        private void OnDestroy()
        {
            _flowchartTarget.SendFungusMessage(_fungmessage);
        }
    }   
}