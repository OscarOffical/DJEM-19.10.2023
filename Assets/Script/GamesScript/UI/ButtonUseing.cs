using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUseing : MonoBehaviour
{
    public Transform Inventary; 
    public DragAndDrop[] DragAndDrop;
    public QulckPanel qulckPanel;
    public InventarySlot[] qulckPanels;
    public GameObject InfoPanel;
    public InventaryManger inventoryManager;

    public int idSlot;

    public void Use()
    {    

        
     
            if (Inventary.GetChild(idSlot).GetComponent<InventarySlot>().item.ItemType == ItemType.Food)
            { 


                if (Inventary.GetChild(idSlot).GetComponent<InventarySlot>().item != null)
                {

                    if (Inventary.GetChild(idSlot).GetComponent<InventarySlot>().item.isConsumeable == true)
                    {
                        qulckPanel.ChangeCharacteristics();

                        if (Inventary.GetChild(idSlot).GetComponent<InventarySlot>().amount <= 1)
                        {
                            DragAndDrop[idSlot].NullifySlotData();
                        }
                        else
                        {
                            Inventary.GetChild(idSlot).GetComponent<InventarySlot>().amount--;
                            Inventary.GetChild(idSlot).GetComponent<InventarySlot>().ItemAmountText.text = Inventary.GetChild(idSlot).GetComponent<InventarySlot>().amount.ToString();
                        }
                    }
                }   
            }
            else if (Inventary.GetChild(idSlot).GetComponent<InventarySlot>().item.ItemType == ItemType.Weapon) 
            {
            for (int i = 0; i < qulckPanels.Length; i++)
            {
                if (qulckPanels[i].item == null)
                {
                    qulckPanels[i].item = Inventary.GetChild(idSlot).GetComponent<InventarySlot>().item;
                    qulckPanels[i].amount = Inventary.GetChild(idSlot).GetComponent<InventarySlot>().amount;
                    qulckPanels[i].isEmpty = Inventary.GetChild(idSlot).GetComponent<InventarySlot>().isEmpty;
                    qulckPanels[i].SetIcon(qulckPanels[i].item.icon);
                    DragAndDrop[idSlot].NullifySlotData();
                
                    qulckPanels[i].iconGO = Inventary.GetChild(idSlot).GetComponent<InventarySlot>().iconGO;
                    InfoPanel.SetActive(false);
                }else
                {
                    continue;
                }
            }

            }



         
    }
       
}

    

