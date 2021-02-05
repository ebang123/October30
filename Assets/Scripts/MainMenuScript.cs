using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour

{

    
    private IEnumerator WaitForSceneLoad() 
    {
         yield return new WaitForSeconds(3); 
         SceneManager.LoadScene("Stroop");

    }

    public void PlayGameBins() 
    {
        new WaitForSeconds(3);
        SceneManager.LoadScene("StarterScene");
    }

    public void PlayGameLau() {
        new WaitForSeconds(3);
        SceneManager.LoadScene("stroopifinity");
    }
    public void PlayGame()
    {
        
        StartCoroutine(WaitForSceneLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }




}
