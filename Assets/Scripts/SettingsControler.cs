using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsControler : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    // Start is called before the first frame update
    void Start()
    {
        if (Preferences.EasyReadValue()==1)
        {
            ButtonInteractable(false, true, true);
        }
        if (Preferences.MediumReadValue() == 1)
        {
            ButtonInteractable(true, false, true);
        }
        if (Preferences.HardReadValue() == 1)
        {
            ButtonInteractable(true, true, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectLevel(string level)
    {
        switch (level)
        {
            case "easy":
                ButtonInteractable(false, true, true);
                AssignValue(false, true, true);
                break;
            case "medium":
                ButtonInteractable(true, false, true);
                AssignValue(true, false, true);
                break;
            case "hard":
                ButtonInteractable(true, true, false);
                AssignValue(true, true, false);
                break;
            default:
                break;
        }
    }
    void ButtonInteractable(bool easy, bool medium, bool hard)
    {
        easyButton.interactable = easy;
        mediumButton.interactable = medium;
        hardButton.interactable = hard;
      
    }
    void AssignValue(bool easy, bool medium, bool hard)
    {
        Preferences.EasyAssignValue(BoolValueControl(easy));
        Preferences.MediumAssignValue(BoolValueControl(medium));
        Preferences.HardAssignValue(BoolValueControl(hard));
    }
    byte BoolValueControl(bool value)
    {
        if (value)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
