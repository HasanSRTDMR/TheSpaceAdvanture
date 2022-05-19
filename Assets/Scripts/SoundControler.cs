using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public static SoundControler instance;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

   void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
      
    }
    public void PlaySound(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
