using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] UI_TabGroup tabGroup;
    [HideInInspector] public Image background;
    [SerializeField] GameEvent selectEvent , deselectEvent;
    void Awake()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void Select()
    {
        if (selectEvent != null)
            selectEvent.Raise();
    }
    public void Deselect()
    {
        if (deselectEvent != null)
            deselectEvent.Raise();
    }


}
