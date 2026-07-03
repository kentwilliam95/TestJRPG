using System;
using frontend;
using Fungus;
using UnityEngine;

public class FungusSendEventOnBattleEnd : MonoBehaviour
{
    [SerializeField] private Flowchart _flowchart;
    [SerializeField] private string _message;

    private void Start()
    {
        GetComponent<BattleController>().OnBattleEnd = () =>
        {
            _flowchart.SendFungusMessage(_message);
        };
    }
}
