using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Frontend;
using UnityEngine;

namespace frontend
{
    public class BattleController : MonoBehaviour
    {
        private enum Turn  
        {
            None,
            Left,
            Right
        }
            
        [SerializeField] private InputCapturer _input;
        [SerializeField] private BaseActor _actor1;
        [SerializeField] private BaseActor _actor2;
        
        [SerializeField] private BattleHUD _battleHUD;
        [SerializeField] private AudioClip _audioBattle;
        [SerializeField] private AudioClip _audioNormal;
        [SerializeField] private AudioClip _audioWin;
        public Action OnBattleEnd;
        
        private Turn _turn = Turn.Left;
        private bool _isBattle;
        private bool _isRightHasTakenTurn;
        private bool _isLeftHasTakenTurn;
        
        private void Start()
        {
            _input.OnMove = InputOnMove;
            _input.OnJumpPressed = InputOnJumpPressed;

            _actor2.OnDead = Actor2OnDead;
        }

        private void Actor2OnDead()
        {
            _isBattle = false;
            FinishBattle();
        }

        private void InputOnMove(Vector2 v)
        {
            if (_turn == Turn.Right || _isLeftHasTakenTurn || !_isBattle) { return;}

            if (v.x > 0)
            {
                _battleHUD.Right();
            }
            else if(v.x< 0)
            {
                _battleHUD.Left();
            }
        }
        
        private void InputOnJumpPressed()
        {
            if (_turn == Turn.Right || _isLeftHasTakenTurn || !_isBattle) { return;}
            _battleHUD.Select();

            _isLeftHasTakenTurn = true;
            _actor1.Animator.SetTrigger(GameConstant.AnimatorTriggerAttack);
            _battleHUD.HidePlayerActions();
            DOVirtual.DelayedCall(0.25f, () =>
            {
                var value = _actor1.Status.Getvalue(PropertiesCollection.Category.AttackDamage).Value;
                _actor2.Hit(value);
            });
            
            DOVirtual.DelayedCall(2f, () =>
            {
                _turn = Turn.Right;
            });
        }

        public void TriggerBattle()
        {
            DOVirtual.DelayedCall(0.5f, () =>
            {
                _isBattle = true;                
            });
            
            _battleHUD.ShowPlayerActions();
            _actor1.SwitchToBattle();
            _actor2.SwitchToBattle();
            AudioController.Instance.PlayMusic(_audioBattle, 0.25f);
        }

        private void Update()
        {
            _battleHUD.UpdatePlayerHUDTransform(_actor1.transform.position);
            if (!_isBattle)
            {
                return;
            }
            
            switch (_turn)
            {
                case Turn.None:
                    break;
                
                case Turn.Left:
                    _isRightHasTakenTurn = false;
                    _battleHUD.ShowPlayerActions();
                    _turn = Turn.None;
                    break;
                
                case Turn.Right:
                    if (_isRightHasTakenTurn)
                    {
                        break;
                    }

                    _isLeftHasTakenTurn = false;
                    _actor2.Animator.SetTrigger(GameConstant.AnimatorTriggerAttack);
                    DOVirtual.DelayedCall(0.25f, () =>
                    {
                        _actor1.Hit(_actor2.Status.Getvalue(PropertiesCollection.Category.AttackDamage).Value);
                    });
                    
                    DOVirtual.DelayedCall(2f, () =>
                    {
                        _turn = Turn.Left;
                    });
                    _isRightHasTakenTurn = true;
                    break;
            }
        }

        private void FinishBattle()
        {
            _actor1.SwitchToNormal();
            _actor2.SwitchToNormal();
            _battleHUD.HidePlayerActions();
            OnBattleEnd?.Invoke();
            
            AudioController.Instance.PlaySfx(_audioWin);
            AudioController.Instance.PlayMusic(_audioNormal, 0.25f);
        }
    }   
}