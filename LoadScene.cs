using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public GameObject loadingPanel;

    public Text progressText;
    public Slider loadSlide;

	public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadProgress(sceneIndex));
    }

    IEnumerator LoadProgress(int sceneIndex)
    {
        loadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            float roundValue = Mathf.CeilToInt(progress * 100);
            Debug.Log(roundValue);

            loadSlide.value = progress;
            progressText.text = string.Format("{0}%", roundValue);

            yield return null;
        }
    }
}
