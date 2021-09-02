using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sound : MonoBehaviour
{
    public Button On;
    public Button Off;
   AudioSource audioSource;
    void Start()
    {
     audioSource = Camera.main.GetComponent<AudioSource>();
    }
    public void MusicOn()
    {
     audioSource.Play();
    }
    public void MusicOff()
    {
       audioSource.Pause();
    }
}
