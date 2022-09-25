using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour {

    public static DataController Current;

    [SerializeField] GameObject highscoreMenu;

    public int Highscore;
    public int Coins;

    void Awake()
    {
        Current = this;
    }

    void Start () {
        Highscore = PlayerPrefs.GetInt("Highscore", 0);
        Coins = PlayerPrefs.GetInt("Coins", 0);
    }

    void Update()
    {
        if(highscoreMenu != null)
        {
            highscoreMenu.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Highscore", Highscore);
        PlayerPrefs.SetInt("Coins", Coins);
    }

    public void ResetData()
    {
        Highscore = 0;
        Coins = 0;
        PlayerPrefs.SetInt("Highscore", Highscore);
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.SetString("wasSeen", "false");
    }   
}
