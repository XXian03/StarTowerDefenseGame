using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Card_0_Display : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField] UiHandler Ui;
    void Start()
    {
        Ui.TextBox_0.SetActive(false);
    }

    void Update()
    {

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
            Ui.TextBox_0.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Ui.TextBox_0.SetActive(false);
    }
}
