using System;
using UnityEngine;

namespace frontend
{
    public class SpriteFlipper : MonoBehaviour
    {
        [SerializeField] private InputCapturer _inputCapturer;
        [SerializeField] private SpriteRenderer _renderer;
        private void OnEnable()
        {
            _inputCapturer.OnMove += InputOnMoved;
            _inputCapturer.OnMoveReleased += InputOnMoved;
        }

        private void OnDisable()
        {
            _inputCapturer.OnMove -= InputOnMoved;
            _inputCapturer.OnMoveReleased -= InputOnMoved;
        }

        private void InputOnMoved(Vector2 input)
        {
            _renderer.flipX = input.x < 0;
        }
    }   
}