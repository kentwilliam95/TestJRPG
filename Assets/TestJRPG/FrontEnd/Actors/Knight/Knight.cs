using frontend;
using UnityEngine;

namespace Frontend
{
    public class Knight : BaseActor
    {
        [SerializeField] private InputCapturer _inputCapturer;
        [SerializeField] private BaseAnimatorController _normal;
        [SerializeField] private MovementController _movementController;
        [SerializeField] private SpriteFlipper _spriteFlipper;
        [SerializeField] private InteractController _interactController;
        
        public override bool IsDead => _status.Getvalue(PropertiesCollection.Category.Health).Value <= 0;
        public override Animator Animator => _normal.Animator;

        private void OnEnable()
        {
            _interactController.OnInteractBegan += InteractOnInteractionBegan;
            _interactController.OnInteractEnded += InteractOnInteractionEnded;
        }

        private void OnDisable()
        {
            _interactController.OnInteractBegan -= InteractOnInteractionBegan;
            _interactController.OnInteractEnded -= InteractOnInteractionEnded;
        }

        private void Start()
        {
            _status = _statData.GenerateCollection();
            Debug.Log(_status);
        }

        private void InteractOnInteractionBegan()
        {
            SwitchToConversation();
        }
        
        private void InteractOnInteractionEnded()
        {
            SwitchToNormal();
        }

        public override bool ReceiveItem(Item item)
        {
            Debug.Log($"Receive Item: {item.Name}");
            return true;
        }

        public override void SwitchToBattle()
        {
            _normal.enabled = false;
            _movementController.enabled = false;
            _spriteFlipper.enabled = false;
        }

        public override void SwitchToNormal()
        {
            _inputCapturer.enabled = true;
            _interactController.enabled = true;
            _normal.enabled = true;
            _movementController.enabled = true;
            _spriteFlipper.enabled = true;
        }

        public void SwitchToConversation()
        {
            _inputCapturer.enabled = false;
            _interactController.enabled = false;
            _normal.enabled = false;
            _movementController.enabled = false;
            _spriteFlipper.enabled = false;
        }

        public override void Hit(float damage)
        {
            _status.Add(PropertiesCollection.Category.Health, -damage);
            _normal.Animator.SetTrigger(GameConstant.AnimatorTriggerHurt);
        }
    }   
}