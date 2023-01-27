using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtatapeGun : MonoBehaviour
{
    public  GameObject Bul;

    public Transform pointShot;

    public  float TimeStartShot = 0;
    public float TimeEndShot =3;


   



    public  void Update()
    {
        Shot();
    }

    public void Shot()
    {
         if(TimeStartShot <= 0)
         {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bul, pointShot.position, transform.rotation);

                TimeStartShot = TimeEndShot; 
            }
            
         }else
         {
            TimeStartShot -= Time.deltaTime;
         }
    }


}
