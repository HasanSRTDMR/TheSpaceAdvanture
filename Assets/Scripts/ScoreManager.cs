using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText,gameOverScoreText,goldText;

    [HideInInspector] public int score;
    int gold;
    int totalScore;
    int highScore;
    bool scoreControl=true;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = " X " + gold;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreControl)
        {
        score = (int)Camera.main.transform.position.y;
            totalScore = score + (gold * 10);
        scoreText.text = "SCORE: " + totalScore;
        }
    }
    public void GetGold()
    {

        FindObjectOfType<SoundsControler>().SoundGold();
        gold++;
        goldText.text = " X " + gold;
        
    }
    public void GameOver()
    {
        if (Preferences.EasyReadValue()==1)
        {
            highScore = Preferences.EasyScoreReadValue();
            if (totalScore>highScore)
            {
                Preferences.EasyScoreAssignValue(totalScore);
            }
        }
        if (Preferences.MediumReadValue() == 1)
        {
            highScore = Preferences.MediumScoreReadValue();
            if (totalScore > highScore)
            {
                Preferences.MediumScoreAssignValue(totalScore);
            }
        }
        if (Preferences.HardReadValue() == 1)
        {
            highScore = Preferences.HardScoreReadValue();
            if (totalScore > highScore)
            {
                Preferences.HardScoreAssignValue(totalScore);
            }
        }
        scoreControl = false;
        gameOverScoreText.text= "SCORE: " + totalScore;
    }
}
