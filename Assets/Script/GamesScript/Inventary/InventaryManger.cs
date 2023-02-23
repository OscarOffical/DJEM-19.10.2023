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
    
    public Transform InventaryPanel; // ������� ������� � ��������
    public List<InventarySlot> slot = new List<InventarySlot>();// ������ ������� 

    [Header("Open and close panel inventary")]// �������� ��������
    public GameObject PanelInvetary;
    public bool isOpen;
    public Canvas Cs;

    public  InventarySlot[] inventarySlot;


    public Transform AttackPosition;
    public float AttaclReang;
    public LayerMask LayerMask;



    public CraftManager craftManager;


    private void Awake()
    {

        PanelInvetary.SetActive(true);
        PanelInvetary.SetActive(false);
        Cs.GetComponent<GraphicRaycaster>().enabled = false;
    }

    void Start()
    {
        
        craftManager = GetComponent<CraftManager>();
       

        for (int i = 0; i <= InventaryPanel.childCount; i++) // ���������� ��� ������ ���������� 
        {
            
            if (InventaryPanel.GetChild(i).GetComponent<InventarySlot>() != null)// ������� ������ ��������� � ����������� ������ ��� �������� ������, �� ������� ������������� ��������� ������ 
            {
                
                slot.Add(InventaryPanel.GetChild(i).GetComponent<InventarySlot>()); // ���� ������� ������ ����������, �� �� ����������� � ������. 
                inventarySlot[i].IdSlot = i;


            }
            

        }
       



    }

    
    void Update()
    {
        PanelInventary();
        Using();




    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //           if (Input.GetKeyDown(KeyCode.E))
    //           {
    //                    if (collision.gameObject.GetComponent<Item>() != null)
    //                    {            
    //                        AddItemInventary(collision.gameObject.GetComponent<Item>().item, collision.gameObject.GetComponent<Item>().amount);
    //                        Destroy(collision.gameObject);
    //                    }


    //           }

    //}


    public void Using()
    {
        Collider2D[] enimes = Physics2D.OverlapCircleAll(AttackPosition.position, AttaclReang, LayerMask);

        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < enimes.Length; i++)
            {
                if (enimes[i].gameObject.GetComponent<Item>() != null)
                {
                    AddItemInventary(enimes[i].gameObject.GetComponent<Item>().item, enimes[i].gameObject.GetComponent<Item>().amount);
                    Destroy(enimes[i].gameObject);
                }

            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPosition.position, AttaclReang);
    }


    
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (collision.gameObject.GetComponent<Item>() != null)
    //        {
    //            AddItemInventary(collision.gameObject.GetComponent<Item>().item, collision.gameObject.GetComponent<Item>().amount);
    //            Destroy(collision.gameObject);
    //        }


    //    }

    //}


    public void PanelInventary()
     {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;

            if (isOpen && craftManager.isOpenCraft == false)
            {
                PanelInvetary.SetActive(true);
                gameObject.GetComponent<PlayerControler>().enabled = false;
                gameObject.GetComponent<Weapon�otation>().enabled = false;
                //gameObject.GetComponentInChildren<ProtatapeGun>().enabled = false;
                Time.timeScale = 0;
                Cs.GetComponent<GraphicRaycaster>().enabled = true;
               

            }
            else 
            {
                PanelInvetary.SetActive(false);
                gameObject.GetComponent<PlayerControler>().enabled = true;
                gameObject.GetComponent<Weapon�otation>().enabled = true;
                //gameObject.GetComponentInChildren<ProtatapeGun>().enabled = true;
                Time.timeScale = 1;
                Cs.GetComponent<GraphicRaycaster>().enabled = false;
                

            }
        }

       

    }




    public void AddItemInventary(ItemScripteblObject _item, int _amount)
    {
        foreach (InventarySlot slots in slot)// ��� ���� ������ ��� ���� � ���������. 
        {
            if (slots.item == _item) // ���� ������� �� ��������� ������� ����� ������� �� ����� �� ����������� ��������� ����� 
            {
                if (slots.amount + _amount <= _item.MaximumAmout) // �������� ��������� ��������� � �����, ���� ��� ������ ���� �� ���������� ��������� ��� 
                {
                    slots.amount += _amount; // � ��������� � ��������� ����������� ��������� ��� ����� � �����. 
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
        foreach (InventarySlot slots in slot)// ��� ���� ��� ������ ������ � ��� ������ ����� ��������
        {
            if(slots.isEmpty == true) // ���� ���� ������, �� ���� ����� �������� ������. 
            {
                slots.item = _item;  // ������� ������ 
                slots.amount = _amount; // ������� ����������� 
                slots.isEmpty = false; // ������ ������ ���������� 
                slots.SetIcon(_item.icon); // ����� �������� 
                if(slots.amount != 1 )
                {
                    slots.ItemAmountText.text = _amount.ToString();// �����.
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
