using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip ac;
    public void onClickSoundButton(){
        audiosource.PlayOneShot(ac, 0.5f);
    }
}
