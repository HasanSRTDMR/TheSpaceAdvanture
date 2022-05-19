using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{

    [SerializeField] Button sound;
    [SerializeField] Sprite[] soundImage;
    void Start()
    {
        if (!Preferences.HaveRecord())
        {
            Preferences.EasyAssignValue(1);
        }
        if (!Preferences.HaveSoundOpedRecord())
        {
            Preferences.SoundOpenAssignValue(1);
        }
        SoundPreferencesConrol();

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Score()
    {
        SceneManager.LoadScene("Score");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Sound()
    {
        if (Preferences.SoundOpenReadValue()==1)
        {
            SoundControler.instance.PlaySound(false);
            Preferences.SoundOpenAssignValue(0);
            sound.image.sprite= soundImage[0];
        }
        else
        {
            SoundControler.instance.PlaySound(true);
            Preferences.SoundOpenAssignValue(1);
            sound.image.sprite = soundImage[1];            
        }
    }
    public void SoundPreferencesConrol()
    {
        if (Preferences.SoundOpenReadValue()==1)
        {
            sound.image.sprite = soundImage[1];
            SoundControler.instance.PlaySound(true);
        }
        else
        {
            sound.image.sprite = soundImage[0];
            SoundControler.instance.PlaySound(false);
        }
    }
}
