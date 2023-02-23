using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class FillCraftDitals : MonoBehaviour
{
    public CraftCreator currentCraftitem;
    public CraftManager craftManager;
    public GameObject CraftResursPrefab;
    public string craftPanelName;

    private void Start()
    {
        craftManager = FindObjectOfType<CraftManager>();
    }
    public void fillCraftDitals()
    {
        for (int i = 0; i < GameObject.Find(craftPanelName).transform.childCount; i++)
        {
            Destroy(GameObject.Find(craftPanelName).transform.GetChild(i).gameObject);
        }
        craftManager.IconCraftItem.sprite = currentCraftitem.FinalCraft.icon;
        craftManager.nameCraftItem.text = currentCraftitem.FinalCraft.name;
        craftManager.DescriptionCraftItem.text = currentCraftitem.FinalCraft.itemDescription;

         for(int i= 0; i< currentCraftitem.Creatures.Count; i++)
         {
            GameObject craftResursG0 = Instantiate(CraftResursPrefab, GameObject.Find(craftPanelName).transform );
            CraftDetelsAmount craftDetelsAmount = craftResursG0.GetComponent<CraftDetelsAmount>();
            craftDetelsAmount.AmountResurs.text = currentCraftitem.Creatures[i].AmountCraftResurs.ToString();
            craftDetelsAmount.ItemTypeResurs.text = currentCraftitem.Creatures[i].CraftObjext.ItemName;
         }
    }
}
