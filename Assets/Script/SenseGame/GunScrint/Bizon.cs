using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bizon : MonoBehaviour
{
    [SerializeField]private GameObject sp;

    [SerializeField] private Transform kf;

    [SerializeField] private float _startTime;
    [SerializeField] private float _endTime;



    void Start()
    {
        
    }

    
    void Update()
    {
       if(_startTime <= 0)
       {
            if(Input.GetMouseButtonDown(0)) 
            {
                Instantiate(sp, kf.position, transform.rotation);
                _startTime = _endTime;
            }
       }else
       {
            _startTime -= Time.deltaTime;
       }
            
        

    }
}
