using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseballbar : MonoBehaviour
{
    public ItemScripteblsObjectWeapen ItemWeapen;
    public Transform AttackPosition;
    public float AttaclReang;
    public LayerMask LayerMask;
    public int Damag;
    public Animator Animators;

  

    // Update is called once per frame
    void Update()
    {

        if (ItemWeapen.StartShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Animators.SetTrigger("attack");
                ItemWeapen.StartShot = ItemWeapen.EndShot;
            }

        }
        else
        {
            ItemWeapen.StartShot -= Time.deltaTime;
        }

    }

    public void OnAttack()
    {
        Collider2D[] enimes = Physics2D.OverlapCircleAll(AttackPosition.position, AttaclReang, LayerMask);

        for (int i = 0; i < enimes.Length; i++)
        {
            enimes[i].GetComponent<Enemy>().TakeDamag(Damag);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPosition.position, AttaclReang);
    }
}
