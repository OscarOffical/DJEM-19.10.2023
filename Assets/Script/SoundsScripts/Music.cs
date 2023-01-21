using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSourse;
    [SerializeField] private Scrollbar _volume;


    private void Start()
    {
        _volume.value = 1;
    }
    public void VolumeControl()
    {
        

        if (_musicSourse.volume >= 0 && _musicSourse.volume <= 1)
        {
            _musicSourse.volume = _volume.value;

        }else
        {
            _musicSourse.volume = 0;
        }

    }

}
