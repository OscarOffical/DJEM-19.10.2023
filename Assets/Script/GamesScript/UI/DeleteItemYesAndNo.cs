using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemYesAndNo : MonoBehaviour
{
    public GameObject WindowDelete;
    public DragAndDrop[] dragAndDrop;
    public int IDSlot;
    public bool IsOpenDeleteWindow;
    [SerializeField] GameObject AdditionalInformation;
    public InventaryManger inventaryManger;
   



    public void DeleteYes()
    {
        dragAndDrop[IDSlot].NullifySlotData();
        
        WindowDelete.SetActive(false);
        AdditionalInformation.gameObject.SetActive(false);
        inventaryManger.enabled = true;
       
    }

    public void DeleteNo()
    {
      
        WindowDelete.SetActive(false);
        inventaryManger.enabled = true;
    }
}
