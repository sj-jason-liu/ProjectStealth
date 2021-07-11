using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;

    void Start()
    {
        _progressBar.fillAmount = 0;
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOper = SceneManager.LoadSceneAsync("Main");
        while(!asyncOper.isDone)
        {
            _progressBar.fillAmount = asyncOper.progress;
            yield return new WaitForEndOfFrame();
        }   
    }
}
