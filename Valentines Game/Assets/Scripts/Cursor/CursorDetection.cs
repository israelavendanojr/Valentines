using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CursorDetection : MonoBehaviour
{

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);
    List<RaycastResult> results;
    [SerializeField] Transform currentCharacter;

    [SerializeField] TextMeshProUGUI nameText, descriptionText;

    void Start()
    {

        gr = GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        if (isOnButton())
            SetButton(results[0].gameObject.transform);

    }
    private bool isOnButton()
    {
        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            //Debug.Log(results[0].gameObject.name);
            return true;

        }

        //Debug.Log(results[0].gameObject.name);
        return false;
    }
    void SetButton(Transform raycastedCharacter)
    {
        currentCharacter = raycastedCharacter;

        UpdateItemInfo(raycastedCharacter);
    }
    void UpdateItemInfo(Transform item)
    {
        UI_ItemSlot itemInfo = item.GetComponent<UI_ItemSlot>();
        if (itemInfo == null)
            return;

        nameText.text = itemInfo.itemName;
        descriptionText.text = itemInfo.description;
    }
}
