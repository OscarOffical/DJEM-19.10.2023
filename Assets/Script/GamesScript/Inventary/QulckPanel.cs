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
    public GameObject PrefabsMagazin; // картинка мазагина
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
            // Ѕерем предыдущий слот и мен€ем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;


            // ≈сли крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считаетс€ нулевым)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // ѕрибавл€ем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Ѕерем предыдущий слот и мен€ем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
            ShowItemHand();

            // „то то делаем с предметом:

        }
        if (mw < -0.1)
        {
            // Ѕерем предыдущий слот и мен€ем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // ≈сли крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // ”меньшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Ѕерем предыдущий слот и мен€ем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // „то то делаем с предметом:
            ActionSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventarySlot>();
            ShowItemHand();

        }

        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                // провер€ем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentQuickslotID == i)
                {
                    // —тавим картинку "selected" на слот если он "not selected" или наоборот
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
                // »наче мы убираем свечение с предыдущего слота и светим слот который мы выбираем
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
            // ѕримен€ем изменени€ к здоровью (будущем к голоду и жажде) 
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


                PrefabsMagazin.gameObject.GetComponent<Image>().sprite = AllWeapen.GetChild(i).gameObject.GetComponent<LogicWeapan>().ItemWeapen.IconMagazin; // прогужает картину магазина. 
                PrefabsMagazin.gameObject.SetActive(true); // включает картинк.
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
