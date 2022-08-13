using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeMusicButton : BaseMusicButton
{
    [SerializeField] private Image _onImage;
    [SerializeField] private Image _offImage;
    [SerializeField] private AudioSource _audioSource;
    
    
#if UNITY_EDITOR
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_onImage.fillAmount == 0)
        {
            _audioSource.volume = .1f;
            _onImage.fillAmount = .5f;
            _offImage.fillAmount = .5f;
            pressed = true;
            _audioSource.mute = false;
        }
        else if (Math.Abs(_onImage.fillAmount - .5f) < float.Epsilon)
        {
            _audioSource.volume = .25f;
            _onImage.fillAmount = 1;
            _offImage.fillAmount = 0f;
        }
        else if (Math.Abs(_onImage.fillAmount - 1) < float.Epsilon)
        {
            _onImage.fillAmount = 0;
            _offImage.fillAmount = 1f;
            pressed = false;
            _audioSource.mute = true;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
    }
#else
    public override void OnPointerClick(PointerEventData eventData)
    {
    }

    public override void OnPointerEnter(PointerEventData eventData)
    { 
        if (_onImage.fillAmount == 0)
        {
            _audioSource.volume = .1f;
            _onImage.fillAmount = .5f;
            _offImage.fillAmount = .5f;
            pressed = true;
            _audioSource.mute = false;
        }
        else if (Math.Abs(_onImage.fillAmount - .5f) < float.Epsilon)
        {
            _audioSource.volume = .25f;
            _onImage.fillAmount = 1;
            _offImage.fillAmount = 0f;
        }
        else if (Math.Abs(_onImage.fillAmount - 1) < float.Epsilon)
        {
            _onImage.fillAmount = 0;
            _offImage.fillAmount = 1f;
            pressed = false;
            _audioSource.mute = true;
        }
    }
#endif
}
