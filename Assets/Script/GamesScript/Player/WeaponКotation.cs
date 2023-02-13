using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponКotation : MonoBehaviour
{

    private Camera _camera;
    private Vector3 pos;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }



    void Update()
    {
        pos = _camera.WorldToScreenPoint(transform.position);
        FlipHero();

    }
    private void FlipHero()
    {
        if (Input.mousePosition.x < pos.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.mousePosition.x > pos.x)
        {    
            GetComponent<SpriteRenderer>().flipX = false;
        }



    }

}




