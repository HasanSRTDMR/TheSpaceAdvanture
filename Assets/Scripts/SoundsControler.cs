using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsControler : MonoBehaviour
{
    public AudioClip jump, gameOver, gold;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent < AudioSource >();
    }

   
    public void SoundJump()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }
    public void SoundGameOver()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
    public void SoundGold()
    {
        audioSource.clip = gold;
        audioSource.Play();
    }
}
