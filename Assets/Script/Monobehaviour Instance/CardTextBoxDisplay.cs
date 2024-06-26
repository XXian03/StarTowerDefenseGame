using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardTextBoxDisplay : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField] int i;
    [SerializeField] UiHandler Ui;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Ui.AllTextBox[i].SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Ui.AllTextBox[i].SetActive(false);
    }
}
