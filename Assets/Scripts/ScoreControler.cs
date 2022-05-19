using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControler : MonoBehaviour
{
    [SerializeField]Text easyScore, mediumScore, hardScore;

    // Start is called before the first frame update
    void Start()
    {
        easyScore.text = "YOUR SCORE: "+Preferences.EasyScoreReadValue();
        mediumScore.text = "YOUR SCORE: " + Preferences.MediumScoreReadValue();
        hardScore.text = "YOUR SCORE: " + Preferences.HardScoreReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
