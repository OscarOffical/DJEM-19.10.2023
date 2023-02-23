using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCreat : MonoBehaviour
{
    [SerializeField] Transform Inventary;
   
    [SerializeField] DragAndDrop[] dragAndDrop;
    [SerializeField] InventarySlot inventarySlot;


    public DeleteItemYesAndNo deleteItemYesAndNo;
    public int IdUseingSlot;
    public GameObject WindowDelete;
    public InventaryManger inventaryManger;


   


    public void Creat()
    {
        
        if (Inventary.GetChild(IdUseingSlot).GetComponent<InventarySlot>())
        {
            //dragAndDrop[IdUseingSlot].NullifySlotData();
         
                WindowDelete.SetActive(true);
                deleteItemYesAndNo.IDSlot = IdUseingSlot;
                inventaryManger.enabled = false ;
           




        }
    }
    
}
