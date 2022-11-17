using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("screen", 0);
    }

    public void SurvivePlay() 
    {
        SceneManager.LoadScene(2);
    }

    public void StoryPlay() 
    {
        SceneManager.LoadScene(1);

    }

}
