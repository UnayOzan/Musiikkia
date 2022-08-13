using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamModeMusicButton : BaseMusicButton
{
    [SerializeField] private Image _offImage;
    [SerializeField] private Image _onImage;
    [SerializeField] private Color nonSelectableColor;
    [SerializeField] private AudioSource _audioSource;

    private static List<GamModeMusicButton> _selectedButtons;

    public enum State
    {
        Selectable,
        NonSelectable,
        Selected,
        Deselected
    }

    [SerializeField] public State state = State.NonSelectable;

    private static GamModeAudioSource _gamModeAudioSource;

    private void Awake()
    {
        _gamModeAudioSource ??= FindObjectOfType<GamModeAudioSource>();
        _selectedButtons ??= new List<GamModeMusicButton>();
    }

#if UNITY_EDITOR
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (state == State.Selectable)
        {
            _selectedButtons.Add(this);
            
            _gamModeAudioSource.OpenLine(transform.GetSiblingIndex());
            
            Select();
        }
        else if (state == State.Selected)
        {
            if (_selectedButtons.Last() != this)
                return;

            _selectedButtons.Remove(this);
            
            _gamModeAudioSource.CloseLine(transform.GetSiblingIndex());
            Deselect();
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
        if (state == State.Selectable)
        {
            _selectedButtons.Add(this);
            
            _gamModeAudioSource.OpenLine(transform.GetSiblingIndex());
            
            Select();
        }
        else if (state == State.Selected)
        {
            if (_selectedButtons.Last() != this)
                return;

            _selectedButtons.Remove(this);
            
            _gamModeAudioSource.CloseLine(transform.GetSiblingIndex());
            Deselect();
        }
    }
#endif

    public void Select()
    {
        _onImage.gameObject.SetActive(true);
        _offImage.gameObject.SetActive(false);

        _audioSource.mute = false;
        pressed = true;
        state = State.Selected;
    }

    public void Deselect()
    {
        _onImage.gameObject.SetActive(false);
        _offImage.gameObject.SetActive(true);

        _audioSource.mute = true;
        pressed = false;
        state = State.Deselected;

        if (_selectedButtons.Count == 0)
        {
            SetSelectable();
        }
    }

    //selectable
    public void SetSelectable()
    {
        _audioSource.mute = true;
        pressed = false;
        _offImage.color = Color.white;
        state = State.Selectable;
    }

    //non selectable
    public void SetNonSelectable()
    {
        _audioSource.mute = true;
        pressed = false;
        _offImage.color = nonSelectableColor;
        state = State.NonSelectable;
    }
}