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

    public Sprite icon;// то как бкжет выгдядеть обьект в инвенторе  

    public GameObject ItemPrifbs;// префаб обекта, который должен выподать их инвенторя.
}
public enum ItemType
{
    // виды айтемов которые бывают 
    Defult, Food, Weapon, Recovety
}
