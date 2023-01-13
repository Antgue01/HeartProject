using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    AsyncOperation scene;
    private void Start()
    {
        StartCoroutine(Load());        
    }
    public void ChangeScene()
    {
        scene.allowSceneActivation = true;
    }
    IEnumerator Load()
    {
        scene = SceneManager.LoadSceneAsync(1);
        scene.allowSceneActivation = false;
        yield return null;
    }
}
