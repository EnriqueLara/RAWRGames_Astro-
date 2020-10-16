using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEnums;

public class OxygenSystem : MonoBehaviour
{
    public static OxygenSystem instance;
    //public Button playButton;
    //public Text text;
    //public Text countText;
    //public float seconds;
    //private ulong lastTimeRecorded;
    //public bool isGameOpen;

    //private float count;

    //
    private float oxygen;
    [SerializeField]
    private float maxOxygen;
    private ulong lastTimeRecordedForOxygen;
    [SerializeField]
    private float regenerationSpeed;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private SceneManagement sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.LoadGameStatus();
        lastTimeRecordedForOxygen = ulong.Parse(PlayerPrefs.GetString("LastTime"));
        LoadOxygen();
        if (gameManager.GetGameStatus() == GameStatus.Close)
        {
            AddOxygen(lastTimeRecordedForOxygen, regenerationSpeed);
        }
        sceneManager.CheckScene();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameManager.GetGameStatus() == GameStatus.InMainMenu)
        {
            AddOxygen(regenerationSpeed);
        }
        if (gameManager.GetGameStatus() == GameStatus.InGame)
        {
            RestOxygen();
        }
    }

    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //your app is NO LONGE$$anonymous$$in the background
            LoadOxygen();
            if (gameManager.GetGameStatus() == GameStatus.Close)
            {
                sceneManager.CheckScene();
                LoadOxygen();
                lastTimeRecordedForOxygen = ulong.Parse(PlayerPrefs.GetString("LastTime"));
                AddOxygen(lastTimeRecordedForOxygen, regenerationSpeed);
                
            }
            
        }
        else
        {
            //your app is now in the background
            if(gameManager.GetGameStatus() != GameStatus.InGame)
            {

                gameManager.SetGameStatus(GameStatus.Close);
                gameManager.SaveGameStatus();
            }
            SaveOxygen();
        }
    }
    public int GetOxygen()
    {
        return (int)oxygen;
    }
    public void SaveOxygen()
    {
        PlayerPrefs.SetFloat("Oxygen", oxygen);
        lastTimeRecordedForOxygen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastTime", lastTimeRecordedForOxygen.ToString());
        gameManager.SaveGameStatus();   
    }
    public void LoadOxygen()
    {
        oxygen = PlayerPrefs.GetFloat("Oxygen");
    }
    public void RestOxygen()
    {
        oxygen -= Time.deltaTime * 3;
        if (oxygen < 0)
            oxygen = 0;
    }
    public void AddOxygen(ulong time, float _speed)
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - time);
        ulong m = diff / TimeSpan.TicksPerSecond;

        oxygen += m * _speed;
        if (oxygen > maxOxygen)
            oxygen = maxOxygen;
        
    }
    public void AddOxygen(float _speed)
    {
        oxygen += Time.deltaTime * _speed;
        if (oxygen > maxOxygen)
            oxygen = maxOxygen;
    }






    //public void ButtonClick()
    //{
    //    lastTimeRecorded = (ulong)DateTime.Now.Ticks;
    //    PlayerPrefs.SetString("lastTimeRecorded", lastTimeRecorded.ToString());
    //    playButton.interactable = false;
    //}

    //public void AddSec()
    //{
    //    ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeRecordedForOxygen);
    //    ulong m = diff / TimeSpan.TicksPerSecond;

    //    count += m * .5f;
    //}
    //public void RestSec()
    //{
    //    count -= Time.deltaTime * 2;
    //}

    //public bool isButtonReady()
    //{
    //    ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeRecorded);
    //    ulong m = diff / TimeSpan.TicksPerSecond;
    //    float secondsLeft = (seconds - m);

    //    if (secondsLeft < 0)
    //    {
    //        text.text = "Play";
    //        return true;
    //    }
    //    else
    //        return false;       
    //}
    //private string SetTimer()
    //{
    //    ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeRecorded);
    //    ulong m = diff / TimeSpan.TicksPerSecond;
    //    float secondsLeft = (seconds - m);

    //    string timer = "";
    //    int hours = ((int)secondsLeft / 3600);
    //    secondsLeft -= hours * 3600;
    //    int minutes = ((int)secondsLeft / 60);
    //    secondsLeft -= minutes * 60;

    //    timer = hours.ToString("0") + "hrs " + minutes.ToString("00") + "m " + secondsLeft.ToString() + "s";
    //    return timer;
    //}
}
