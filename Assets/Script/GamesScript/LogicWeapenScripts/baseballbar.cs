using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseballbar : MonoBehaviour
{
    public ItemScripteblsObjectWeapen ItemWeapen;
    public Transform AttackPosition;
    public float AttaclReang;
    public float Damag;
    public Animator Animators;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ItemWeapen.StartShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Animators.SetTrigger("attack");
                Collider2D[] enimes = Physics2D.OverlapCircleAll(AttackPosition.position, AttaclReang);
                
                for (int i = 0; i < enimes.Length; i++)
                {
                    
                }



                ItemWeapen.StartShot = ItemWeapen.EndShot;
            }

        }
        else
        {
            ItemWeapen.StartShot -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPosition.position, AttaclReang);
    }
}
