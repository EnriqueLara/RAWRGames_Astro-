using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameEnums;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    private int _minSceneIndex;
    [SerializeField]
    private int _maxSceneIndex;

    private Dictionary<int, string> sceneList = new Dictionary<int, string>();

    

    public void SetSceneIndex(int _min, int _max)
    {
        _minSceneIndex = _min;
        _maxSceneIndex = _max;
    }

    

    public void CheckScene()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                GameManager.instance.SetGameStatus(GameStatus.InMainMenu);
                break;
            case "DemoGameplay":
                GameManager.instance.SetGameStatus(GameStatus.InGame);
                break;
        }
    }
    public void LoadFirstScene()
    {
        sceneList.Clear();
        //genera el numero random
        int index = Random.Range(_minSceneIndex, _maxSceneIndex + 1);
        int numOfScenes = (_maxSceneIndex + 1) - _minSceneIndex;
        sceneList.Add(index, "asd");
        SceneManager.LoadScene(index);
    }
    //public void LoadRandomScene()
    //{
    //    //genera el numero random
    //    int index = Random.Range(_minSceneIndex, _maxSceneIndex + 1);
    //    int numOfScenes = (_maxSceneIndex + 1) - _minSceneIndex;
    //    Debug.Log(index);

    //    //si el nivel es mayor a 50 te regresa al menu
    //    if(GameManager.instance.levelController.GetCurrentLevel() > 50)
    //    {
    //        GameManager.instance.levelController.ResetCurrentLevel();
    //        SceneManager.LoadScene("MainMenu");
    //    }
    //    //checa y setea el nuevo nivel mas alto
    //    GameManager.instance.levelController.SetW1MaxLevelReached(
    //    GameManager.instance.levelController.CheckLevel(GameManager.instance.levelController.GetCurrentLevel(), 
    //    GameManager.instance.levelController.GetW1MaxLevelReached())); 
    //    //se repitieron todods los niveles y se va a repetir otra vez hasta llegar a 50
    //    if (sceneList.Count >= numOfScenes)
    //    {
    //        sceneList.Clear();
    //        Debug.Log("se repitieron todos los numeros");
    //        if(sceneList.Count<numOfScenes)
    //        LoadRandomScene();
    //    }
    //    if (sceneList.ContainsKey(index))
    //    {
    //        Debug.Log("Se repitio el numero: " + index.ToString());
    //        //LoadRandomScene();
    //    }
    //    else//cambio de escena
    //    {
    //        GameManager.instance.levelController.SetCurrentLevelPlus1();
    //        Debug.Log(index.ToString());
    //        sceneList.Add(index, "asd");
    //        SceneManager.LoadScene(index);
    //    }
    //}

    public void ClearSceneDictionary()
    {
        sceneList.Clear();
    }

}
