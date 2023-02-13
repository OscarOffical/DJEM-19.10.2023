using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QulckPanel : MonoBehaviour
{
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public InventaryManger inventoryManager;
    public InventarySlot[] InventarySlot;
    public Indicetors Indicetors;
    public InventarySlot ActionSlot = null;
    public Transform AllWeapen;


    [Header("Magazin")]
    public GameObject PrefabsMagazin; // �������� ��������
    public GameObject TeXtMagazin;
 


    private void Start()
    {
        PrefabsMagazin.gameObject.SetActive(false);
        TeXtMagazin.gameObject.SetActive(false);
    }



    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");

        if (mw > 0.1)
        {
            // ����� ���������� ���� � ������ ��� �������� �� �������
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;


            // ���� ������ ��������� ����� ������ � ���� ����� currentQuickslotID ����� ���������� �����, �� �������� ��� ������ ���� (������ ���� ��������� �������)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // ���������� � ����� currentQuickslotID ��������
                currentQuickslotID++;
            }
            // ����� ���������� ���� � ������ ��� �������� �� "���������"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
            ShowItemHand();

            // ��� �� ������ � ���������:

        }
        if (mw < -0.1)
        {
            // ����� ���������� ���� � ������ ��� �������� �� �������
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // ���� ������ ��������� ����� ����� � ���� ����� currentQuickslotID ����� 0, �� �������� ��� ��������� ����
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // ��������� ����� currentQuickslotID �� 1
                currentQuickslotID--;
            }
            // ����� ���������� ���� � ������ ��� �������� �� "���������"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // ��� �� ������ � ���������:
            ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
            ShowItemHand();

        }

        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            // ���� �� �������� �� ������� 1 �� 5 ��...
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                // ��������� ���� ��� ��������� ���� ����� ����� ������� � ��� ��� ������, ��
                if (currentQuickslotID == i)
                {
                    // ������ �������� "selected" �� ���� ���� �� "not selected" ��� ��������
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                        ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
                        ShowItemHand(); 
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                        ActionSlot = null;
                        HidItemHand();
                    }
                }
                // ����� �� ������� �������� � ����������� ����� � ������ ���� ������� �� ��������
                else
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
                    ShowItemHand();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().item != null)
            {
                if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().item.isConsumeable == true  && !inventoryManager.isOpen  && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
                {
                    
                   
                    StartCoroutine(WaitingTime());

                    
                    
                    
                }
            }
        }

        IEnumerator WaitingTime()
        {
            yield return new WaitForSeconds(1f);
            // ��������� ��������� � �������� (������� � ������ � �����) 
            ChangeCharacteristics();

            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().amount <= 1)
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDrop>().NullifySlotData();
            }
            else
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().amount--;
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().ItemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>().amount.ToString();
            }
        }



      





    }
    public void ChangeCharacteristics()
    {
        for(int i = 0; i>= InventarySlot.Length; i++)
        {
            Indicetors.ChangeInicetors(InventarySlot[i].item.changeFood, InventarySlot[i].item.ChangeHealth, InventarySlot[i].item.ChangeWater);
        }
    }


    public void CheckItemHand()
    {
        if (ActionSlot != null)
        {
            ShowItemHand();
        }
        else
        {
            HidItemHand();
        }
    }
    

    public void ShowItemHand()
    {
        HidItemHand();
        if (ActionSlot.item == null)
        {
            return;
        }
        for (int i = 0; i < AllWeapen.childCount; i++)
        {
            if(ActionSlot.item.name == AllWeapen.GetChild(i).name)
            {
                AllWeapen.GetChild(i).gameObject.SetActive(true);


                PrefabsMagazin.gameObject.GetComponent<Image>().sprite = AllWeapen.GetChild(i).gameObject.GetComponent<LogicWeapan>().ItemWeapen.IconMagazin; // ��������� ������� ��������. 
                PrefabsMagazin.gameObject.SetActive(true); // �������� �������.
                TeXtMagazin.gameObject.SetActive(true);

            }            
        }
        
    }
    public void HidItemHand()
    {
        for (int i = 0; i < AllWeapen.childCount; i++)
        {
            AllWeapen.GetChild(i).gameObject.SetActive(false);
            PrefabsMagazin.gameObject.SetActive(false);
            TeXtMagazin.gameObject.SetActive(false);
          


        }
    }

}
