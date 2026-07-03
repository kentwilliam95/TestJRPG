using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace frontend
{
    public class BattleHUD : MonoBehaviour
    {
        [SerializeField] private RectTransform _groupTransform;
        [SerializeField] private CanvasGroup[] _groupImages;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _groupText;
        [SerializeField] private Camera _camera;
        [SerializeField] private AudioClip _audioSelect;
        private int _currentSelection = 0;
        private Sequence _seqShowText;

        private void Start()
        {
            HidePlayerActions();
            _seqShowText = DOTween.Sequence();
            _seqShowText.SetAutoKill(false);

            _seqShowText.Insert(0f, _groupText.DOFade(1f, 0.25f));
            _seqShowText.Insert(1f, _groupText.DOFade(0f, 0.125f));
            _seqShowText.Rewind();
        }

        private void OnDestroy()
        {
            _seqShowText?.Kill();
        }

        public void UpdatePlayerHUDTransform(Vector3 worldPos)
        {
            _groupTransform.position = _camera.WorldToScreenPoint(worldPos);
        }

        public void Left()
        {
            _currentSelection -= 1;
            _currentSelection = Mathf.Clamp(_currentSelection, 0, _groupImages.Length - 1);
            SelectSelection();
        }

        public void Right()
        {
            _currentSelection += 1;
            _currentSelection = Mathf.Clamp(_currentSelection, 0, _groupImages.Length - 1);
            SelectSelection();
        }

        public void Select()
        {
            AudioController.Instance.PlaySfx(_audioSelect);
        }

        public void SetTextMessage(string someText)
        {
            _text.SetText(someText);
            _seqShowText.Restart();
        }

        public void HidePlayerActions()
        {
            for (int i = 0; i < _groupImages.Length; i++)
            {
                _groupImages[i].alpha = 0f;
            }
        }
        
        public void ShowPlayerActions()
        {
            for (int i = 0; i < _groupImages.Length; i++)
            {
                _groupImages[i].alpha = 1f;
            }

            _currentSelection = 0;
        }

        private void SelectSelection()
        {
            for (int i = 0; i < _groupImages.Length; i++)
            {
                _groupImages[i].alpha = 0.5f;
            }
            _groupImages[_currentSelection].alpha = 1;
        }
    }
}