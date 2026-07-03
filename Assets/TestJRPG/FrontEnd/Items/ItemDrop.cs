using System;
using DG.Tweening;
using Frontend;
using frontend.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace frontend
{
    public class ItemDrop : MonoBehaviour, IInteract
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private InputCapturer _inputCapturer;
        [SerializeField] private TextMeshProUGUI _textContent;
        [SerializeField] private Button _button;
        [SerializeField] private SpriteRenderer _renderer;
        
        [SerializeField] private ItemData _itemData;
        [SerializeField] private AudioClip _sfxInteract;
        private Sequence _sequence;
        private BaseActor _actor;

        public Action OnInteracted { get; set; }
        public Action OnInteractionCompleted { get; set; }
        private bool _markedForDestroy;
        private void OnDestroy()
        {
            _inputCapturer.OnUsePressed -= InputOnUsePressed;
            _button.onClick.RemoveListener(InputOnUsePressed);
            _sequence?.Kill(true);
        }

        private void Start()
        {
            _inputCapturer.OnUsePressed += InputOnUsePressed;
            _button.onClick.AddListener(InputOnUsePressed);
            
            HideSign();
            InitializeItemData(_itemData);
            InitializeAnimation();
        }

        private void InitializeAnimation()
        {
            _sequence = DOTween.Sequence();
            _sequence.SetAutoKill(false);
            _sequence.Insert(0f, _canvasGroup.transform.DOScale(1f, 0.25f).From(0f));
            _sequence.Insert(0f, _canvasGroup.DOFade(1f, 0.25f).From(0f));
            _sequence.Pause();
        }

        public void InitializeItemData(ItemData itemData)
        {
            _textContent.SetText(itemData.DisplayName);
            _renderer.sprite = itemData.Sprite;
        }

        private void InputOnUsePressed()
        {
            if(_actor == null)
                return;
            
            Interact();
        }

        private void ShowSign()
        {
            _sequence?.Restart();
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        
        private void HideSign()
        {
            _sequence?.SmoothRewind();
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
        public void ShowInteract(BaseActor actor)
        {
            _actor = actor;
            ShowSign();
        }

        public void HideInteract(BaseActor actor)
        {
            HideSign();   
        }

        public virtual void Interact()
        {
            HideSign();
            OnInteractionCompleted?.Invoke();
            var item = _itemData.GenerateItem();
            if (_actor.ReceiveItem(item))
            {
                AudioController.Instance.PlaySfx(_sfxInteract);
                Destroy(gameObject);
            }
        }
    }   
}