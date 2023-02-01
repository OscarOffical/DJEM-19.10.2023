using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QulckPanel : MonoBehaviour
{
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    

   

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
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    }
                }
                // »наче мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                }
            }
        }



    }
}
