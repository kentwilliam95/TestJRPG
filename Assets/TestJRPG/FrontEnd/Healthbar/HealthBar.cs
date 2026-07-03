using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace frontend
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private CanvasGroup _group;
        
        private Sequence _seq;
        
        private void OnDestroy()
        {
            _seq?.Kill();
        }

        private void Start()
        {
            _seq = DOTween.Sequence();
            _seq.SetAutoKill(false);
            _seq.Insert(0f,transform.DOPunchScale(-Vector3.one * 0.1f, 0.125f));
            _seq.Pause();
        }

        public void ResetProgress()
        {
            _fill.fillAmount = 1;
        }

        public void SetProgress(float value)
        {
            _fill.DOFillAmount(value, 0.25f).SetEase(Ease.OutBack);
            _seq.Restart();
        }

        public void Hide()
        {
            _group.alpha = 0;
        }

        public void Show()
        {
            _group.alpha = 1;
        }
    }   
}