using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DefaultMusicButton : BaseMusicButton, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Events")]
    [SerializeField] private UnityEvent<bool> OnButtonPress;
    [SerializeField] private UnityEvent<bool> OnButtonPressRev;

#if UNITY_EDITOR
    public override void OnPointerClick(PointerEventData eventData)
    {
        pressed = !pressed;
        UpdateStatus(pressed);
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
        pressed = !pressed;
        UpdateStatus(pressed);
    }
#endif

    public void UpdateStatus(bool value)
    {
        pressed = value;
        
        OnButtonPress.Invoke(pressed);
        OnButtonPressRev.Invoke(!pressed);
    }
}