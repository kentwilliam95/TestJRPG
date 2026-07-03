using System;
using DG.Tweening;
using frontend;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonClicked : MonoBehaviour
{
    private Button _button;
    private Sequence _sequence;
    [SerializeField] private AudioClip _audioOnClicked;
    public Action OnClicked;
    
    private void OnEnable()
    {
        if(_button == null)
        {
            _button = GetComponentInParent<Button>();   
        }
        
        _button.onClick.AddListener(ButtonOnClicked);
        InitAnimation();
    }

    private void OnDisable()
    {
        if(_button == null)
        {
            _button = GetComponentInParent<Button>();   
        }
        _button.onClick.RemoveListener(ButtonOnClicked);
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }

    private void ButtonOnClicked()
    {
        _sequence?.Restart();
        OnClicked?.Invoke();
        AudioController.Instance.PlaySfx(_audioOnClicked);
    }

    private void InitAnimation()
    {
        if(_sequence != null)
            return;

        _sequence = DOTween.Sequence();
        _sequence.SetAutoKill(false);
        var localscaleX = transform.localScale.x * -0.20f;
        var localscaleY = transform.localScale.y * -0.20f;
        
        _sequence.Insert(0f, _button.transform.DOPunchScale(new Vector3(localscaleX, localscaleY), 0.125f, 1, 1).SetEase(Ease.OutBack));
        _sequence.Pause();
    }
}
