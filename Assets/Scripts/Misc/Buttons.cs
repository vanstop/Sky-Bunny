using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Buttons : MonoBehaviour {

    [SerializeField] bool paused = false;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject panelTutorial;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !panelTutorial.activeInHierarchy)
        {
            if(SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            else if(SceneManager.GetActiveScene().name == "Game" && CameraFollow.Current.gameIsRunning)
            {
                Pause();   
            }
            
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        pausePanel.SetActive(paused);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Share()
    {
        StartCoroutine(TakeSSAndShare());
    }

    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Play Sky Bunny!").SetText("Ola, veja minha pontuação no Sky Bunny.\n jogue e veja se consegue me passar: https://play.google.com/store/apps/details?id=com.GabrielBelarmino.SkyBunny").Share();
    }
}
