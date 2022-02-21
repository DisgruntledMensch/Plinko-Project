using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAudio : MonoBehaviour
{
   public GameObject victory;
    public AudioClip bgm;
    public AudioClip win;
    AudioSource audio;

    //play BGM
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = bgm;
        audio.loop = true;
        audio.Play();
    }
    void Update()
    {
        //Play win sound
        if(victory.activeSelf)
        {
            audio.Pause();
            audio.clip = win;
            audio.Play();
           
        }
        
    }
}
