using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string prevScene;
    [SerializeField] string nextScene;

    public void GoToScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
    public void GoToSceneString(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(prevScene);
    }

}
