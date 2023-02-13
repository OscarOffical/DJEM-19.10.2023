using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemWeapen", menuName = "Weapen/new Weapen")]
public class ItemScripteblsObjectWeapen : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] string _description;
    public int _maximunMagazin;
    public float StartShot;
    public float EndShot;
    public GameObject PrefabsWeapen;
    public GameObject PrefabsBullet;
    public Sprite IconMagazin;
    public float secondsToEmptyRecgarg;// Время перезарядки
    public int Aboima;
}
