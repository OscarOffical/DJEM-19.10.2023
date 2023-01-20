using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSours;
    [SerializeField] private AudioClip _button;

    public void PlayClip()
    {
        _audioSours.PlayOneShot(_button);
    }


}
