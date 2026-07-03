using System;
using UnityEngine;

public class InputCapturer : MonoBehaviour
{
    private Vector2 _prevVector;
    private bool _prevFirePressState;
    
    public Action<Vector2> OnMove;
    public Action OnJumpPressed;
    public Action OnUsePressed;
    public Action OnFirePressed;

    public Action<Vector2> OnMoveReleased;
    private void Update()
    {
        var currentFireState = Input.GetKeyDown(KeyCode.Space); 
        if (currentFireState)
        {
            if (_prevFirePressState == false)
            {
                OnFirePressed?.Invoke();   
            }
        }

        _prevFirePressState = currentFireState;

        if (Input.GetAxisRaw("Jump") > 0)
        {
            OnJumpPressed?.Invoke();
        }
        
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveVector.sqrMagnitude > 0)
        {
            OnMove?.Invoke(moveVector);
            _prevVector = moveVector;
        }
        else
        {
            if (Math.Abs(_prevVector.sqrMagnitude - moveVector.sqrMagnitude) > Mathf.Epsilon)
            {
                _prevVector = moveVector;
                OnMoveReleased?.Invoke(_prevVector);   
            }
        }
    }
}
