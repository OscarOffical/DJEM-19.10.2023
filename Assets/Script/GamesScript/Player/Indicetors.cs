using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Indicetors : MonoBehaviour
{
    public PlayerControler playerControler;
    public Image healthBar, foodBar, waterBar, staminaBar;
    public float healthAmount = 100;
    public float foodAmount = 100;
    public float waterAmount = 100;
    public float StaminaAmount;

    

    public float secondsToEmptyFood = 10f*60f;
    public float secondsToEmptyWater = 5f*60f;
    public float secondsToEmptyHealth = 60f;
    // Start is called before the first frame update
    void Start()
    {
        StaminaAmount += playerControler._stamina;

        healthBar.fillAmount = healthAmount / 100;
        foodBar.fillAmount = foodAmount / 100;
        waterBar.fillAmount = waterAmount / 100;
        staminaBar.fillAmount = StaminaAmount;
    }

    // Update is called once per frame
    void Update()
    {

        StaminaAmount = playerControler._stamina;

        if (foodAmount > 0)
        {
            foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
            foodBar.fillAmount = foodAmount / 100;
        }
        if (waterAmount > 0)
        {
            waterAmount -= 100 / secondsToEmptyWater * Time.deltaTime;
            waterBar.fillAmount = waterAmount / 100;
        }

        if (foodAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }
        if (waterAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }
        healthBar.fillAmount = healthAmount / 100;

        if(StaminaAmount > 0)
        {
            staminaBar.fillAmount = StaminaAmount/ 100;

        }
    }



    public void ChangeInicetors(float RecoveryFood, float RecoveryHealth, float RecoveryWater)
    {
        float _tempFood = foodAmount + RecoveryFood;
        float _tempHealth = healthAmount + RecoveryHealth;
        float _tempWater  = waterAmount + RecoveryWater;


        if(_tempFood >= 100 || _tempHealth >= 100 || _tempWater >= 100)
        {
            foodAmount = 100f;
            waterAmount = 100f;
            healthAmount = 100f;

        }else
        {
            foodAmount += RecoveryFood;
            waterAmount += RecoveryWater;
            healthAmount += RecoveryHealth;
        }

        

    }
}
