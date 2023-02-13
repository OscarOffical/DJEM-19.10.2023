using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicWeapan : MonoBehaviour, IShot
{
    public ItemScripteblsObjectWeapen ItemWeapen;
    public Transform pointShot;
    
    public int Magazin;// ���������� ����
    public Image RechargeImage;// �������� �����������
    public float TimeRecharge =100;// ��������� �������� ��� ����������
    public float secondsToEmptyRecgarg;// ����� �����������
    public int Aboima;
    public TMP_Text MagazinText;
    public TMP_Text AboimaText;

    private void Start()
    {
        Magazin = ItemWeapen._maximunMagazin;
        secondsToEmptyRecgarg = ItemWeapen.secondsToEmptyRecgarg;
        RechargeImage.fillAmount = TimeRecharge / 100;
     
        Aboima = ItemWeapen.Aboima;
       
       MagazinText.text = Magazin.ToString();
       AboimaText.text = Aboima.ToString();


    }


    private void Update()
    {
        Shot();
       



    }

    public void Shot()
    {

        MagazinText.text = Magazin.ToString();
        AboimaText.text = Aboima.ToString();

        if (ItemWeapen.StartShot <= 0)
        {

            if (Magazin > 0)// ��������
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(ItemWeapen.PrefabsBullet, pointShot.position, transform.rotation);
                    ItemWeapen.StartShot = ItemWeapen.EndShot;
                    Magazin--;
                }     
            }


            if ( Magazin <= 0 || Input.GetKeyDown(KeyCode.R))//�����������
            {
                Magazin = 0;
                Recharge();    
            }
           
        }
        else
        {
            ItemWeapen.StartShot -= Time.deltaTime;
        }




    }
        

    public void Recharge()
    {
        
            RechargeImage.gameObject.SetActive(true);

            if (TimeRecharge > 0 && Aboima > 0)
            {
                TimeRecharge -= 100 / secondsToEmptyRecgarg * Time.deltaTime;
                RechargeImage.fillAmount = TimeRecharge / 100;
                

            }
            else
            {
                RechargeImage.gameObject.SetActive(false);
                    TimeRecharge = 100;
                if (Aboima > 0)
                {   
                    Aboima--;
                    Magazin = ItemWeapen._maximunMagazin;
                }
            }

    }


}
