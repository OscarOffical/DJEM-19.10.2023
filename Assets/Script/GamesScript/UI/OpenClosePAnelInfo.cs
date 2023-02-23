using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenClosePAnelInfo : MonoBehaviour
{

    public DragAndDrop dragAndDrop;
    public GameObject AdditionalInformation;// пнель дополнительной информации.
    public bool isOpenes = true;
    public TMP_Text NameItem;
    public TMP_Text DescriptionItem;


    [Header("Button Info")]
    public ButtonUseing buttonUseing;
    public ButtonCreat buttonCreat;
    
    void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
        buttonUseing = FindObjectOfType<ButtonUseing>();
        buttonCreat = FindObjectOfType<ButtonCreat>();
   
    }

    public void OpenClose()
    {
        
        isOpenes = !isOpenes;
       
        if (!isOpenes)
        {
            AdditionalInformation.SetActive(true);
            
            //buttonUseing.idSlot = id;
            ////buttonCreat.IdUseingSlot = dragAndDrop.oldSlot.IdSlot;
            ////isOpenes = true;
        }else
        {

            NameItem.text = dragAndDrop.oldSlot.item.name;
            DescriptionItem.text = dragAndDrop.oldSlot.item.name;
            AdditionalInformation.SetActive(false);
        }
    }
}
