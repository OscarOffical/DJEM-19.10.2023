using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUseing : MonoBehaviour
{
    public Transform Inventary; 
    public DragAndDrop[] DragAndDrop;
    public QulckPanel qulckPanel;

    public int idSlot;

    public void Use()
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
            

        

       
    }

    

