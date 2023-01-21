using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelOpption : MonoBehaviour
{
    [SerializeField] public OpenPanelSound _openPanel;
    [SerializeField] public GameObject _sound;
    

    public void panelSound()
    {
        if (_openPanel.Switches == false)
        {
            _sound.SetActive(false);
        }
    }
}
