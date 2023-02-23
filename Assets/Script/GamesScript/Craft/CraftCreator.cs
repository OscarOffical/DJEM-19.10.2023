using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemCraft", menuName = "Craft/New Craft ")]
public class CraftCreator : ScriptableObject
{
    public enum CraftType {Weapen, Armo, Tools, Food, Medicoment, Ammo, Resurs}
    public CraftType type;

    public ItemScripteblObject FinalCraft;
    public int Amount;
    public List<CraftResurs> Creatures;
}


[System.Serializable]
public class CraftResurs
{
    public ItemScripteblObject CraftObjext;
    public int AmountCraftResurs;
}