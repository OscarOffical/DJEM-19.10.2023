using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventarySlot : MonoBehaviour
{

    public ItemScripteblObject item; // что будет лежать в слоте. 
    public int amount; // текущее количество предметов, в слоте
    public bool isEmpty = true;// ячейка занята или нет
    public GameObject iconGO; // каритнка где будет будет отображаться картинка предемета в ячейке 
    public TMP_Text ItemAmountText;// количество в цибрах( визуал) 


    private void Awake()
    {
        iconGO = transform.GetChild(0).GetChild(0).gameObject; // заносить в iconGo положение картинки которая будет отобрачаться в слоте, берет 0 
        //элемент у основного  обекта, и 0 обек дочернего


        ItemAmountText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();// тоже самое 

    }

    public void SetIcon(Sprite icon) // тут поступает картинка 
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1); // тут картинка становиться вимдемой
        iconGO.GetComponent<Image>().sprite = icon; // от тсюда идет катинка 
    }
}
