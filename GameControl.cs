using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance = null;

    public Text timerText;

    public bool isDead = false;

    private bool maxTime = false;

	void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(Timer());
	}

    public void Death()
    {
        isDead = true;
        timerText.color = Color.red;

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetString("HighScore", timerText.text);
        }

        int currentScore = BreakScore(timerText.text);
        int maxScore = BreakScore(PlayerPrefs.GetString("HighScore"));

        if(currentScore > maxScore)
        {
            PlayerPrefs.SetString("HighScore", timerText.text);
        }

        GameObject.Find("Canvas").GetComponent<DeathMenu>().Activate(timerText.text);
    }

    IEnumerator Timer()
    {
        while (!isDead && !maxTime)
        {
            yield return new WaitForSeconds(1);

            ChangeText();
        }
    }

    int BreakScore(string setScore)
    {
        if(setScore.Length == 4)
        {
            setScore = string.Format("{0}{1}", setScore, '\0');
        }

        int seconds = int.Parse(setScore.Substring(2, 3));
        int minutes = int.Parse(setScore.Substring(0, 1));

        return minutes + seconds;
    }

    void ChangeText()
    {
        StringBuilder changeTime = new StringBuilder(timerText.text);

        int seconds = int.Parse(timerText.text.Substring(2, 3));
        int minutes = int.Parse(timerText.text.Substring(0, 1));

        seconds++;

        if(seconds == 60)
        {
            minutes++;

            if(minutes == 10)
            {
                changeTime = new StringBuilder("10:00");
                maxTime = true;

                timerText.color = Color.yellow;
            }
            else
            {
                string tempString = minutes.ToString();
                char[] tempChar = tempString.ToCharArray();

                changeTime[0] = tempChar[0];
                changeTime[2] = '0';
                changeTime[3] = '0';
            }

        }else if(seconds < 10)
        {
            string tempString = seconds.ToString();
            char[] tempChar = tempString.ToCharArray();

            changeTime[3] = tempChar[0];
        }
        else
        {
            string tempText = changeTime.ToString();
            tempText = string.Format("{0}:{1}{2}", minutes, seconds, '\0');

            changeTime = new StringBuilder(tempText);
        }

        timerText.text = changeTime.ToString();
    }
}
