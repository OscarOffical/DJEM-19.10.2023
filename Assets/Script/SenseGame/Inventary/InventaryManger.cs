using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.PackageManager;
using UnityEngine;

public class InventaryManger : MonoBehaviour
{
    
    public Transform InventaryPanel; // ������� ������� � ��������
    public List<InventarySlot> slot = new List<InventarySlot>();// ������ ������� 

    [Header("Open and close panel inventary")]
    public GameObject PanelInvetary;
    public bool isOpen;

    public bool mognopologit;

   

    private void Awake()
    {
        PanelInvetary.SetActive(true);
    }

    void Start()
    {
        PanelInvetary.SetActive(false);


        for (int i = 0; i < InventaryPanel.childCount; i++) // ���������� ��� ������ ���������� 
        {
            if(InventaryPanel.GetChild(i).GetComponent<InventarySlot>() != null)// ���� ����� ���������� � ������ ���-�� ���� 
            {
                slot.Add(InventaryPanel.GetChild(i).GetComponent<InventarySlot>());
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
                gameObject.GetComponent<Weapon�otation>().enabled = false;
                gameObject.GetComponentInChildren<ProtatapeGun>().enabled = false;
                Time.timeScale = 0;
               
            }else
            {
                PanelInvetary.SetActive(false);
                gameObject.GetComponent<PlayerControler>().enabled = true;
                gameObject.GetComponent<Weapon�otation>().enabled = true;
                gameObject.GetComponentInChildren<ProtatapeGun>().enabled = true;
                Time.timeScale = 1;

            }
        }

       

    }


    public void AddItemInventary(ItemScripteblObject _item, int _amount)
    {
        foreach (InventarySlot slots in slot)// ��� ���� ������ ��� ���� � ���������. 
        {
            if (slots.item == _item)
            {
                if (slots.amount + _amount <= _item.MaximumAmout)
                {
                    slots.amount += _amount;
                    slots.ItemAmountText.text = slots.amount.ToString();
                    return;
                }
                continue;
            }
        }
        foreach (InventarySlot slots in slot)// ��� ���� ��� ������ ������ � ��� ������ ����� ��������
        {
            if(slots.isEmpty == true) 
            {
                slots.item = _item;  
                slots.amount = _amount;
                slots.isEmpty = false;
                slots.SetIcon(_item.icon);
                slots.ItemAmountText.text = _amount.ToString();
                break;
              
               
            }
        }
    }
}
