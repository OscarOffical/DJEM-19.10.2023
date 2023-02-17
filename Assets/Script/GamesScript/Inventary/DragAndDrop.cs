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




    public GameObject AdditionalInformation;// ����� �������������� ����������.
    public bool isOpenes = true;
    public TMP_Text NameItem;
    public TMP_Text DescriptionItem;
    public ButtonUseing buttonUseing;




    private void Start()
    {
        //��������� ��� "PLAYER" �� ������� ���������!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // ������� ������ InventorySlot � ����� � ��������
        oldSlot = transform.GetComponentInParent<InventarySlot>();
       
        qulckpanel = FindObjectOfType<QulckPanel>();

        buttonUseing = FindObjectOfType<ButtonUseing>();

        

       


    }
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ���� ������, �� �� �� ��������� �� ��� ���� return;
        if (oldSlot.isEmpty)
            return;
        GetComponent<RectTransform>().anchoredPosition += eventData.delta;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        //������ �������� ����������
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // ������ ��� ����� ������� ������ �� ������������ ��� ��������
        GetComponentInChildren<Image>().raycastTarget = false;
        // ������ ��� DraggableObject �������� InventoryPanel ����� DraggableObject ��� ��� ������� ������� ���������
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
        // ������ �������� ����� �� ����������
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // � ����� ����� ����� ����� �� ������
        GetComponentInChildren<Image>().raycastTarget = true;

        //��������� DraggableObject ������� � ���� ������ ����
        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        //���� ����� �������� ��� �������� �� ����� UIPanel, ��...
        if (eventData.pointerCurrentRaycast.gameObject.name == "UIPanel")
        {
            // ������ �������� �� ��������� - ������� ������ ������ ����� ����������
            GameObject itemObject = Instantiate(oldSlot.item.ItemPrifbs, player.position + Vector3.up + player.forward, Quaternion.identity);
            // ������������� ���������� �������� ����� ����� ���� � �����
            itemObject.GetComponent<Item>().amount = oldSlot.amount;
            // ������� �������� InventorySlot
            NullifySlotData();

           

        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventarySlot>() != null)
        {
            //���������� ������ �� ������ ����� � ������
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventarySlot>());
            qulckpanel.CheckItemHand();
        }

       




    }
    public void NullifySlotData()
    {
        // ������� �������� InventorySlot
        oldSlot.item = null; // ����� ����������� ������ 
        oldSlot.amount = 0;// ���������� � ��������� ����� ����
        oldSlot.isEmpty = true;// ���� ����������� ������ 
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);// ���� ������� ����� 0 
        oldSlot.iconGO.GetComponent<Image>().sprite = null; // �������� ���
        oldSlot.ItemAmountText.text = "";// ������ ���������
    }
    void ExchangeSlotData(InventarySlot newSlot)
    {
        // �������� ������ ������ newSlot � ��������� ����������
        ItemScripteblObject item = newSlot.item; 
        int amount = newSlot.amount;
        bool isEmpty = newSlot.isEmpty;
        GameObject iconGO = newSlot.iconGO;
        TMP_Text itemAmountText = newSlot.ItemAmountText;



        // ���������� ���������
        if(item == null)
        {
            if(oldSlot.item.MaximumAmout > 1 && oldSlot.amount > 1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    newSlot.item = oldSlot.item;
                    newSlot.amount = Mathf.CeilToInt((float)oldSlot.amount / 2); // ���������� � ������� �������
                    newSlot.isEmpty = false;
                    newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);
                    newSlot.ItemAmountText.text = newSlot.amount.ToString();
                    oldSlot.amount = Mathf.FloorToInt((float)oldSlot.amount / 2); // ���������� � ������� �������
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
        }else if (newSlot.item != null ) // ���������� ���������.
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

        // �������� �������� newSlot �� �������� oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;

        if (oldSlot.isEmpty == false)// ���� � ����� ��� ������� ������ ��� ������ ������.
        {
            newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);// ������� �������� � ������ ���� 
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

        // �������� �������� oldSlot �� �������� newSlot ����������� � ����������
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
