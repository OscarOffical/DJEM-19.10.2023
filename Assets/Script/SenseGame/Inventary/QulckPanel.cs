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
            // ����� ���������� ���� � ������ ��� �������� �� �������
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;


            // ���� ������ ��������� ����� ������ � ���� ����� currentQuickslotID ����� ���������� �����, �� �������� ��� ������ ���� (������ ���� ��������� �������)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // ���������� � ����� currentQuickslotID ��������
                currentQuickslotID++;
            }
            // ����� ���������� ���� � ������ ��� �������� �� "���������"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // ��� �� ������ � ���������:

        }
        if (mw < -0.1)
        {
            // ����� ���������� ���� � ������ ��� �������� �� �������
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // ���� ������ ��������� ����� ����� � ���� ����� currentQuickslotID ����� 0, �� �������� ��� ��������� ����
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // ��������� ����� currentQuickslotID �� 1
                currentQuickslotID--;
            }
            // ����� ���������� ���� � ������ ��� �������� �� "���������"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // ��� �� ������ � ���������:

        }

        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            // ���� �� �������� �� ������� 1 �� 5 ��...
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                // ��������� ���� ��� ��������� ���� ����� ����� ������� � ��� ��� ������, ��
                if (currentQuickslotID == i)
                {
                    // ������ �������� "selected" �� ���� ���� �� "not selected" ��� ��������
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    }
                }
                // ����� �� ������� �������� � ����������� ����� � ������ ���� ������� �� ��������
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
