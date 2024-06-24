using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Card_1_Display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] UiHandler Ui;
    void Start()
    {
        Ui.TextBox_1.SetActive(false);
    }

    void Update()
    {

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Ui.TextBox_1.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Ui.TextBox_1.SetActive(false);
    }
}
