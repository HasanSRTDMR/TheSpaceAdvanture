using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public GameObject uIElements;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameFinish()
    {
        gameOverPanel.SetActive(true);
        FindObjectOfType<SoundsControler>().SoundGameOver();
        FindObjectOfType<PlayerMovement>().GameOver();
        FindObjectOfType<MoveTheCamera>().GameOver();
        FindObjectOfType<ScoreManager>().GameOver();
        FindObjectOfType<Platform>().GameOver();
        FindObjectOfType<PlatformDeath>().GameOver();
        UIClose();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void UIOpen()
    {
        uIElements.SetActive(true);
    }
    public void UIClose()
    {
        uIElements.SetActive(false);
    }
}
