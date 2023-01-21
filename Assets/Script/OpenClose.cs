using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] private GameObject _panelSetting;
    [SerializeField] private bool Switch=false;

    [SerializeField] private GameObject _panelMustBeClosed_1;
    [SerializeField] private GameObject _panelMustBeClosed_2;

    public void OpenPanel()
    {
        if (Switch == false)
        {
            Switch = true;
        }
        else if (Switch == true)
        {
            Switch = false;
        }
        _panelSetting.SetActive(Switch);

    }

    public bool Switches
    {
        get => Switch;
    }

    public void ClosePanel()
    {
        if(Switch == true) 
        {
            _panelMustBeClosed_1.SetActive(false);
            _panelMustBeClosed_2.SetActive(false);
        }
    }

}
