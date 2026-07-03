using System;
using UnityEngine;
using DG.Tweening;

namespace frontend
{
    public class InteractAnimation : MonoBehaviour
    {
        private Sequence _sequence;
        private void OnEnable()
        {
            InitializeAnimation();
        }

        private void OnDisable()
        {
        
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }

        private void InitializeAnimation()
        {
            if (_sequence != null) { _sequence.Restart(); return;}

            _sequence = DOTween.Sequence();
            _sequence.SetAutoKill(false);
            _sequence.SetLoops(-1);
            
            _sequence.Insert(0.5f, transform.DOPunchScale(Vector3.one * 0.05f, 0.2f, 1, 1f).SetEase(Ease.OutBounce));
            _sequence.Insert(0.5f, transform.DOPunchScale(Vector3.one * -0.05f, 0.2f, 1, 1f).SetEase(Ease.OutBounce));
        }
    }   
}