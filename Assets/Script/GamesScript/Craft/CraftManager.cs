using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CraftManager : MonoBehaviour
{
    public GameObject CraftPanel;
    public bool isOpenCraft;

    public InventaryManger inventaryManger;
    public GameObject QueckPanel;



    public List<CraftCreator> AllCraft;
    public Transform CraftItemPAnel;
    public GameObject CraftButtonPrafabs;

    public Image IconCraftItem;
    public TMP_Text nameCraftItem;
    public TMP_Text DescriptionCraftItem;

    
    void Start()
    {
          CraftPanel.SetActive(false);
        inventaryManger = GetComponent<InventaryManger>();
         
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventaryManger.isOpen == false)
            {
                isOpenCraft = !isOpenCraft;

                if(isOpenCraft )
                {
                    CraftPanel.SetActive(true);
                    QueckPanel.SetActive(false);
                }
                else
                {
                    CraftPanel.SetActive(false);
                    QueckPanel.SetActive(true);
                }
            }
            else
            {
                return;
            }
               
        }
    }


    public void LoadCraft(string CraftType)
    {
        for(int i = 0; i<CraftItemPAnel.GetChildCount(); i++)
        {
            Destroy(CraftItemPAnel.GetChild(i).gameObject);
        }
        foreach (CraftCreator cso in AllCraft)
        {
            if (cso.type.ToString().ToLower() == CraftType.ToLower())
            {
                GameObject CraftItemButtom = Instantiate(CraftButtonPrafabs, CraftItemPAnel);
                CraftItemButtom.GetComponent<Image>().sprite = cso.FinalCraft.icon;
                CraftItemButtom.GetComponent<FillCraftDitals>().currentCraftitem = cso;
            }
        }
    }
}
