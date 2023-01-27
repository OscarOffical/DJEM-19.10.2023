using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponКotation : MonoBehaviour
{
    public float offset = 180f;

    void Start()
    {
        
    }

   
    void Update()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y , difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ );
    }
}
