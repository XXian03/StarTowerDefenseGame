using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Card_2_Display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] UiHandler Ui;
    void Start()
    {
        Ui.TextBox_2.SetActive(false);
    }

    void Update()
    {

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Ui.TextBox_2.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Ui.TextBox_2.SetActive(false);
    }
}
