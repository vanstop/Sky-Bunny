using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSystem : MonoBehaviour {

    public static HUDSystem Current;

    [SerializeField] GameObject wings;

    [SerializeField] Transform player;

    [SerializeField] Text pointsText;
    [SerializeField] Text coinsText;

    [SerializeField] Text finalPointsText;
    [SerializeField] Text HighscoreText;

    public int points;
    public int coins;
    int totalCoins;
    public static int Highscore;

    void Awake()
    {
        Current = this;
    }

    void Start () {
        coins = 0;
        points = 0;
        Highscore = PlayerPrefs.GetInt("Highscore");
        totalCoins = PlayerPrefs.GetInt("Coins");
    }

    void Update () {

        if (points < (int)(player.position.y * 30))
        {
            points = (int)(player.position.y * 30);
        }

        pointsText.text = points.ToString();
        finalPointsText.text = "Points: " + points.ToString();

        coinsText.text = coins.ToString();
        DataController.Current.Coins = coins + totalCoins;

        if (Player.Current.hasRevive)
        {
            wings.SetActive(true);
        }
        else
        {
            wings.SetActive(false);
        }

        if (points > Highscore)
        {
            Highscore = points;
            DataController.Current.Highscore = Highscore;
        }
        HighscoreText.text = "Highscore: " + Highscore.ToString();
	}
}
