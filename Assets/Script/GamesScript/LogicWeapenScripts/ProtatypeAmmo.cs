using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtatypeAmmo : MonoBehaviour
{

    public int damag;
    public float speed;

    public float DestriyTime= 2;


    public ProtatapeGun pg;

   
    void Start()
    {
        Invoke("DestoroyAmmo", DestriyTime);
    }

    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public  void DestoroyAmmo()
    {
        Destroy(gameObject);
    }

    
}
