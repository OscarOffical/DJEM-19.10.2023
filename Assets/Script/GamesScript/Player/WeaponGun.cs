using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : MonoBehaviour
{

   

    public float offset = 0;
    public float rotZ;
    private SpriteRenderer spriteRenderer;




    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        Vector3 LocalScale = Vector3.one;

        if (rotZ > 90 || rotZ < -90)
        {

            LocalScale.y = -1f;
        }
        else
        {

            LocalScale.y = +1f;

        }
        transform.localScale = LocalScale;

    }
}
