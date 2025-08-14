using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice_Trigger : MonoBehaviour
{
    public AudioSource turnLeftVoice;
    public AudioSource turnRightVoice;
    public AudioSource hypassVoice;
    public AudioSource EndVoice;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("left"))
        {
            PlayVoice(turnLeftVoice);
        }
        else if (col.gameObject.CompareTag("right"))
        {
            PlayVoice(turnRightVoice);
        }
        else if (col.gameObject.CompareTag("hipass"))
        {
            PlayVoice(hypassVoice);
        }
        else if (col.gameObject.CompareTag("Finish"))
        {
            PlayVoice(EndVoice);
        }
    }


    private void PlayVoice(AudioSource voice)
    {
        if (!voice.isPlaying)
        {
            voice.Play();
        }
    }
}
