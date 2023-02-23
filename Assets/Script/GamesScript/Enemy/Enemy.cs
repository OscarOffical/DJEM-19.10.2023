using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Hp Resurs")]
    [SerializeField] int Health;
    [SerializeField] int AmmountResursDrop; 


    [SerializeField] GameObject _whichResursSpown;
    [SerializeField] Transform _whereSpownResurs;

    [SerializeField] Item _item;
    private void Awake()
    {
        Health = Random.Range(5, 15);
        _item = _whichResursSpown.GetComponent<Item>();
       

        if (Health >= 5 && Health <= 10)
        {
            AmmountResursDrop = Random.Range(1, 4);
            
        }
        else
        {
            AmmountResursDrop = Random.Range(2, 6);
            
        }


    }




    public void TakeDamag(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
           for (int i = 0; i < AmmountResursDrop; i++)
           {
                Instantiate(_whichResursSpown, new Vector2(_whereSpownResurs.position.x, _whereSpownResurs.position.y), Quaternion.identity);
           }
        }
    }
}
