using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InventarySlot oldSlot;
    private Transform player;
    private QulckPanel qulckpanel;
    public InventaryManger InventaryManger;




    public GameObject AdditionalInformation;// пнель дополнительной информации.
    public bool isOpenes = true;
    public TMP_Text NameItem;
    public TMP_Text DescriptionItem;
    public ButtonUseing buttonUseing;




    private void Start()
    {
        //ПОСТАВЬТЕ ТЭГ "PLAYER" НА ОБЪЕКТЕ ПЕРСОНАЖА!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Находим скрипт InventorySlot в слоте в иерархии
        oldSlot = transform.GetComponentInParent<InventarySlot>();
       
        qulckpanel = FindObjectOfType<QulckPanel>();

        buttonUseing = FindObjectOfType<ButtonUseing>();

        

       


    }
    public void OnDrag(PointerEventData eventData)
    {
        // Если слот пустой, то мы не выполняем то что ниже return;
        if (oldSlot.isEmpty)
            return;
        GetComponent<RectTransform>().anchoredPosition += eventData.delta;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        //Делаем картинку прозрачнее
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // Делаем так чтобы нажатия мышкой не игнорировали эту картинку
        GetComponentInChildren<Image>().raycastTarget = false;
        // Делаем наш DraggableObject ребенком InventoryPanel чтобы DraggableObject был над другими слотами инвенторя
        transform.SetParent(transform.parent.parent);


        if (isOpenes == true)
        {
            AdditionalInformation.SetActive(true);
            isOpenes = false;
            buttonUseing.idSlot = oldSlot.IdSlot;

        }
        else if (isOpenes == false)
        {
            AdditionalInformation.SetActive(false);
            isOpenes = true;
            NameItem.text = oldSlot.item.name;
            DescriptionItem.text = oldSlot.item.name;



        }




    }




    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        // Делаем картинку опять не прозрачной
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // И чтобы мышка опять могла ее засечь
        GetComponentInChildren<Image>().raycastTarget = true;

        //Поставить DraggableObject обратно в свой старый слот
        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        //Если мышка отпущена над объектом по имени UIPanel, то...
        if (eventData.pointerCurrentRaycast.gameObject.name == "UIPanel")
        {
            // Выброс объектов из инвентаря - Спавним префаб обекта перед персонажем
            GameObject itemObject = Instantiate(oldSlot.item.ItemPrifbs, player.position + Vector3.up + player.forward, Quaternion.identity);
            // Устанавливаем количество объектов такое какое было в слоте
            itemObject.GetComponent<Item>().amount = oldSlot.amount;
            // убираем значения InventorySlot
            NullifySlotData();

           

        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventarySlot>() != null)
        {
            //Перемещаем данные из одного слота в другой
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventarySlot>());
            qulckpanel.CheckItemHand();
        }

       




    }
    public void NullifySlotData()
    {
        // убираем значения InventorySlot
        oldSlot.item = null; // айтем мтановиться пустым 
        oldSlot.amount = 0;// количетсво в инвенторе равно нулю
        oldSlot.isEmpty = true;// слот становиться пустым 
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);// цвет каринку равен 0 
        oldSlot.iconGO.GetComponent<Image>().sprite = null; // катринки нет
        oldSlot.ItemAmountText.text = "";// пустое количетво
    }
    void ExchangeSlotData(InventarySlot newSlot)
    {
        // Временно храним данные newSlot в отдельных переменных
        ItemScripteblObject item = newSlot.item; 
        int amount = newSlot.amount;
        bool isEmpty = newSlot.isEmpty;
        GameObject iconGO = newSlot.iconGO;
        TMP_Text itemAmountText = newSlot.ItemAmountText;



        // Разделение пердметов
        if(item == null)
        {
            if(oldSlot.item.MaximumAmout > 1 && oldSlot.amount > 1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    newSlot.item = oldSlot.item;
                    newSlot.amount = Mathf.CeilToInt((float)oldSlot.amount / 2); // округление в большую сторону
                    newSlot.isEmpty = false;
                    newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);
                    newSlot.ItemAmountText.text = newSlot.amount.ToString();
                    oldSlot.amount = Mathf.FloorToInt((float)oldSlot.amount / 2); // округление в большую сторону
                    oldSlot.ItemAmountText.text = oldSlot.amount.ToString();
                    return;

                }
                else if(Input.GetKey(KeyCode.LeftControl)) 
                {
                    newSlot.item = oldSlot.item;
                    newSlot.amount = 1;
                    newSlot.isEmpty = false ;
                    newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);
                    newSlot.ItemAmountText.text = newSlot.amount.ToString();
                    oldSlot.amount--;
                    oldSlot.ItemAmountText.text = oldSlot.amount.ToString();

                    
                    return;
                }

            }
        }else if (newSlot.item != null ) // соединение предметов.
        {
            if (oldSlot.item.ItemName == newSlot.item.ItemName && oldSlot.item.MaximumAmout > 1)
            {
                int tempslot = newSlot.amount;
                newSlot.amount += oldSlot.amount;
                newSlot.ItemAmountText.text = newSlot.amount.ToString();

                if (newSlot.amount == tempslot + oldSlot.amount)
                {
                    NullifySlotData();
                }
                else
                {
                    oldSlot.amount -= tempslot;
                    oldSlot.ItemAmountText.text = oldSlot.amount.ToString();
                }
                return;
            }
        }

        // Заменяем значения newSlot на значения oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;

        if (oldSlot.isEmpty == false)// если в ячеуи нет другого объета или ячейка пустая.
        {
            newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);// заносит картинку в пустой слот 
            if(newSlot.amount != 1)
            {
                newSlot.ItemAmountText.text = oldSlot.amount.ToString();
            }
            else
            {
                newSlot.ItemAmountText.text = " ";
            }
        }
        else
        {
            newSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            newSlot.iconGO.GetComponent<Image>().sprite = null;
            newSlot.ItemAmountText.text = "";
        }

        newSlot.isEmpty = oldSlot.isEmpty;

        // Заменяем значения oldSlot на значения newSlot сохраненные в переменных
        oldSlot.item = item;
        oldSlot.amount = amount;
        if (isEmpty == false)
        {
            oldSlot.SetIcon(item.icon);
            if(oldSlot.amount != 1)
            {
                oldSlot.ItemAmountText.text = amount.ToString();
            }
            else
            {
                oldSlot.ItemAmountText.text = "";
            }
        }
        else
        {
            oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            oldSlot.iconGO.GetComponent<Image>().sprite = null;
            oldSlot.ItemAmountText.text = "";
        }

        oldSlot.isEmpty = isEmpty;
    }

}
