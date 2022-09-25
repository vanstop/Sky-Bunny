using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTutorial : MonoBehaviour
{

    public string wasSeen;

    void Start()
    {
        wasSeen = PlayerPrefs.GetString("wasSeen", "false");
        Time.timeScale = 0;
    }

    void Update()
    {
        if(wasSeen == "false")
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                gameObject.SetActive(false);
                PlayerPrefs.SetString("wasSeen", "true");
            }
        }
        else if (wasSeen == "true")
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            PlayerPrefs.SetString("wasSeen", "true");
        }
    }
}
