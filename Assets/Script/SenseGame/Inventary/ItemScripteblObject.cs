using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripteblObject : ScriptableObject
{
   
    // ����� ������������ ����� �������������� ������� � ����������, ������������� ����������, ��� ����� ����������� � ��������� � ��. 

    public ItemType  ItemType;// ���� ������� ��� ������ ������� 

    public string ItemName; // �������� ������� 
    public int  MaximumAmout = 10; // ���� ���������� � ���������
    public string itemDescription;// ��������� �������

    public Sprite icon; 

    public GameObject ItemPrifbs;
}
public enum ItemType
{
    // ���� ������� ������� ������ 
    Defult, Food, Weapon, Recovety
}
