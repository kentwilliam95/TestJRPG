using System;
using UnityEngine;

public class FungusGetOnEndConversation : MonoBehaviour
{
    public Action OnEndConversation;

    public void ReceiveEndConversation()
    {
        OnEndConversation?.Invoke();
    }
}
