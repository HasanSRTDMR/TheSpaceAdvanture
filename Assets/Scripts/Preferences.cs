using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string mediumScore = "mediumScore";
    public static string hardScore = "hardScore";

    public static string soundOpen = "soundOpen";

    public static void EasyAssignValue(int easy)
    {
        PlayerPrefs.SetInt(Preferences.easy, easy);
    }
    public static int EasyReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.easy);
    }
    public static void MediumAssignValue(int medium)
    {
        PlayerPrefs.SetInt(Preferences.medium, medium);
    }
    public static int MediumReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.medium);
    }
    public static void HardAssignValue(int hard)
    {
        PlayerPrefs.SetInt(Preferences.hard, hard);
    }
    public static int HardReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.hard);
    }

    //
    public static void EasyScoreAssignValue(int easyScore)
    {
        PlayerPrefs.SetInt(Preferences.easyScore, easyScore);
    }
    public static int EasyScoreReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.easyScore);
    }
    public static void MediumScoreAssignValue(int mediumScore)
    {
        PlayerPrefs.SetInt(Preferences.mediumScore, mediumScore);
    }
    public static int MediumScoreReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.mediumScore);
    }
    public static void HardScoreAssignValue(int hardScore)
    {
        PlayerPrefs.SetInt(Preferences.hardScore, hardScore);
    }
    public static int HardScoreReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.hardScore);
    }
    //
    public static void SoundOpenAssignValue(int soundOpen)
    {
        PlayerPrefs.SetInt(Preferences.soundOpen, soundOpen);
    }
    public static int SoundOpenReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.soundOpen);
    }

    public static bool HaveRecord()
    {
        if (PlayerPrefs.HasKey(easy)|| PlayerPrefs.HasKey(medium) || PlayerPrefs.HasKey(hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HaveSoundOpedRecord()
    {
        if (PlayerPrefs.HasKey(soundOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
