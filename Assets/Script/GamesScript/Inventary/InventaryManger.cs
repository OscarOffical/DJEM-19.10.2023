using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class InventaryManger : MonoBehaviour
{
    
    public Transform InventaryPanel; // позиция ячеййкм в ивентаре
    public List<InventarySlot> slot = new List<InventarySlot>();// список словтов 

    [Header("Open and close panel inventary")]// открытие закрытие
    public GameObject PanelInvetary;
    public bool isOpen;
    public Canvas Cs;

    public  InventarySlot[] inventarySlot;

   




    private void Awake()
    {

        PanelInvetary.SetActive(true);
        Cs.GetComponent<GraphicRaycaster>().enabled = false;
    }

    void Start()
    {
        PanelInvetary.SetActive(false);

       

        for (int i = 0; i < InventaryPanel.childCount; i++) // перебеарет все ячейки иневенторя 
        {

            if(InventaryPanel.GetChild(i).GetComponent<InventarySlot>() != null)// берется объект инветнарь и проверяется каждый его дочерний объект, на наличее существования дочернего обекта 
            {
                slot.Add(InventaryPanel.GetChild(i).GetComponent<InventarySlot>()); // если дочений объект существует, то он добовляется в список. 

                inventarySlot[i].IdSlot = i;
                
            }
            
             
        }
       



    }

    
    void Update()
    {
        PanelInventary();

        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
               if (collision.gameObject.GetComponent<Item>() != null)
                    if (Input.GetKeyDown(KeyCode.E))
              {
                    {            
                        AddItemInventary(collision.gameObject.GetComponent<Item>().item, collision.gameObject.GetComponent<Item>().amount);
                        Destroy(collision.gameObject);
                    }
                }

    }



    private void PanelInventary()
     {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                PanelInvetary.SetActive(true);
                gameObject.GetComponent<PlayerControler>().enabled = false;
                gameObject.GetComponent<WeaponКotation>().enabled = false;
                //gameObject.GetComponentInChildren<ProtatapeGun>().enabled = false;
                Time.timeScale = 0;
                Cs.GetComponent<GraphicRaycaster>().enabled = true;

            }
            else
            {
                PanelInvetary.SetActive(false);
                gameObject.GetComponent<PlayerControler>().enabled = true;
                gameObject.GetComponent<WeaponКotation>().enabled = true;
                //gameObject.GetComponentInChildren<ProtatapeGun>().enabled = true;
                Time.timeScale = 1;
                Cs.GetComponent<GraphicRaycaster>().enabled = false;

            }
        }

       

    }


    public void AddItemInventary(ItemScripteblObject _item, int _amount)
    {
        foreach (InventarySlot slots in slot)// луп если объект уже есть в инвентаре. 
        {
            if (slots.item == _item) // если предмет из скриптебл обжекта равен объекту из слота то проверяется следующий кусок 
            {
                if (slots.amount + _amount <= _item.MaximumAmout) // проверка количеста предметов в слоте, если оно меньше макс то происходит следующий шаг 
                {
                    slots.amount += _amount; // к количесту в инвентаре добовляется количесто при подёме с земли. 
                    if (slots.amount != 1)
                    {
                        slots.ItemAmountText.text = slots.amount.ToString();   
                    }
                    else
                    {
                        slots.ItemAmountText.text = "";
                    }

                    return;
                }
                continue;
            }
        }
        foreach (InventarySlot slots in slot)// луп если это первый объект и его только нужно добавить
        {
            if(slots.isEmpty == true) // если слот пустой, то туда можно добавить объект. 
            {
                slots.item = _item;  // заносим карику 
                slots.amount = _amount; // заносим колличество 
                slots.isEmpty = false; // делаем ячейку заполненой 
                slots.SetIcon(_item.icon); // берем картинку 
                if(slots.amount != 1 )
                {
                    slots.ItemAmountText.text = _amount.ToString();// текст.
                }
                else
                {
                    slots.ItemAmountText.text = " ";
                }
                break;
              
               
            }
        }
    }
}
