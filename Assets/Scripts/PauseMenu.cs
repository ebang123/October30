using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseMenu : MonoBehaviour {

    public static bool PauseGame = false;
    public GameObject PauseGameUI;
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}

    public void Resume()
    {
        PauseGameUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        PauseGame = false;
    }

    void Pause()
    {
        PauseGameUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void MainMenu()
    {
        
        SceneManager.LoadScene("Main");
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
