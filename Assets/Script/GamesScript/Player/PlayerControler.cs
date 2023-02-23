using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{

    private float _moveInputX;
    private float _moveInputY;
    [SerializeField] private float _speed = 6F;
    private  Rigidbody2D player;



    [SerializeField] public float _stamina = 5;
    private  bool RecoveryStamin;
  



    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Run();
        ResetStamin();

    }


    void FixedUpdate()
    {
        Walking();
    }

    

    private  void Walking()
    {
        _moveInputX = Input.GetAxis("Horizontal");
        _moveInputY = Input.GetAxis("Vertical");
        player.velocity = new Vector2(_moveInputX * _speed, _moveInputY * _speed);
    }


    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_stamina >= 0)
            {
                
                _speed = 12;
                _stamina -= 1 * Time.deltaTime;

            }
            else if (_stamina < 0)
            {
                _speed = 1;
            }

            RecoveryStamin = false;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            _speed = 6;

            RecoveryStamin = true;
            
        }

    }


    private void ResetStamin()
    {
        if (RecoveryStamin == true)
        {
            if (_stamina <= 5)
            {
                _stamina += 1 * Time.deltaTime;
            }

        }
    }






}
