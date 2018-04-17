using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    public GameObject deathScreenUI;

    public Text currentScore;
    public Text highScore;

    public void Activate(string deadTime)
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0;

        AudioManager.Instance.sound[0].soundSource.Pause();

        currentScore.text = deadTime;
        highScore.text = PlayerPrefs.GetString("HighScore");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        AudioManager.Instance.PlaySound("ButtonClick");
    }

    public void MainScreen()
    {
        Time.timeScale = 1;

        AudioManager.Instance.PlaySound("ButtonClick");
    }
}
