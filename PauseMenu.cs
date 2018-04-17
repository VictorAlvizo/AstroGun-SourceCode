using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool shakeCam = true;

    public Text volumeText;
    public Slider volumeSlider;

    public GameObject pauseMenuUI;

    private bool isPaused = false;
    private bool muteSound = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioManager.Instance.PlaySound("ButtonClick");

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;

        AudioManager.Instance.sound[0].soundSource.UnPause();

        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;

        AudioManager.Instance.sound[0].soundSource.Pause();

        isPaused = true;
    }

    public void ShakeCam()
    {
        AudioManager.Instance.PlaySound("ButtonClick");

        if (shakeCam)
        {
            shakeCam = false;
        }
        else
        {
            shakeCam = true;
        }
    }

    public void MuteToggle()
    {
        if (muteSound)
        {
            muteSound = false;

            AudioManager.Instance.MuteSound(0);
        }
        else
        {
            muteSound = true;

            AudioManager.Instance.MuteSound(1);
        }
    }

    public void AdjustVolume()
    {
        string newText = string.Empty;

        if(volumeSlider.value == 100)
        {
            newText = "Volume:100%";
        }
        else
        {
            float roundValue = Mathf.CeilToInt(volumeSlider.value * 100);
            newText = string.Format("Volume:{0}%", roundValue);
        }

        volumeText.text = newText;

        AudioManager.Instance.ChangeVolume(volumeSlider.value);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySound("ButtonClick");

        Time.timeScale = 1;
    }
}
