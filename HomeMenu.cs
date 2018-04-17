using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenu : MonoBehaviour {

    public GameObject settingPanel;
    public GameObject creditPanel;
    public GameObject homePanel;

	public void StartGame()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();
    }
    
    public void SettingsOption()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        homePanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void Credits()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        homePanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void VisitWebsite()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        Application.OpenURL("http://victoralvizo.weebly.com/");
    }

    public void BackButton()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        if (settingPanel.gameObject.activeInHierarchy)
        {
            settingPanel.SetActive(false);
        }
        else
        {
            creditPanel.SetActive(false);
        }

        homePanel.SetActive(true);
    }

    public void TotalReset()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        PlayerPrefs.DeleteKey("HighScore");
    }

    public void QuitGame()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();

        Application.Quit();
    }
}
