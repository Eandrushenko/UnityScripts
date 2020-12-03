using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isOver = false;
    [TextArea]
    public string DescriptionText = "Nice";
    public Text DescriptionBox;
    //System.Text.RegularExpressions.Regex.Unescape

    public void OnPointerEnter(PointerEventData eventData)
    {
        DescriptionBox.text = DescriptionText;
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionBox.text = "";
        isOver = false;
    }
}
