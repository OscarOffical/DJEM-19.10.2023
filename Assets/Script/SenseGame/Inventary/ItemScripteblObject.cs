using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripteblObject : ScriptableObject
{
   
    // здесь описываеться общие характеристики объекта в инвентраее, макселмальное количество, как будет отражаььбся в инвентаре и тд. 

    public ItemType  ItemType;// енам созание для выбора объекте 

    public string ItemName; // назваине объекта 
    public int  MaximumAmout = 10; // макс количество в инвентаре
    public string itemDescription;// описатине объекта

    public Sprite icon; 

    public GameObject ItemPrifbs;
}
public enum ItemType
{
    // виды айтемов которые бывают 
    Defult, Food, Weapon, Recovety
}
