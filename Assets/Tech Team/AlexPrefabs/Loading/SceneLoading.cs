using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    void Start()
    {
        // Start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        // Create an async operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("RoseAnya(new)");
        
        while (gameLevel.progress < 1)
        {
            // Take progress bar fill amount = async progress
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    void Update()
    {

    }
}
