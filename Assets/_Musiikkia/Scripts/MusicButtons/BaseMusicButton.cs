using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseMusicButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Value")] [SerializeField] protected bool pressed;

#if UNITY_EDITOR
    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
#else
    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
#endif
}