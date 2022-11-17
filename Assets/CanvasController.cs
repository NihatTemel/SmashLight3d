using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMP_Text BallText;

    [SerializeField] GameObject PlayerBall;
    [SerializeField] GameObject Boy;
    [SerializeField] GameObject Panel;

    [SerializeField] int TotalBall = 25;

    [SerializeField] Image FadeImg;
    void Start()
    {
        FadeImg.DOFade(0, 1);

       /* if (PlayerPrefs.GetInt("screen") == 0) 
        {
            PlayerPrefs.SetInt("screen", 1);
          //  Screen.SetResolution(Screen.currentResolution.width/2 , Screen.currentResolution.height/2, true);
        }*/
        Time.timeScale = 1;
        PlayerPrefs.SetInt("ball", TotalBall);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BallText.text = "" + PlayerPrefs.GetInt("ball");
    }


    public void ResGame() 
    {
        Time.timeScale = 1;
        FadeImg.DOFade(1, 1);
        Invoke("LateLoad", 1);
    }

    void LateLoad() 
    {
        if(SceneManager.GetActiveScene().buildIndex==2)
        SceneManager.LoadScene(2);
        else
        {
        SceneManager.LoadScene(3);

        }

    }

    public void GoMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void NextLevel() 
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") );
        FadeImg.DOFade(1, 1);
        Invoke("LateLoad", 1);

    }

    public void PlayGame() 
    {
        Debug.Log("play game");
        Boy.GetComponent<BoyController>().enabled = true;
        PlayerBall.GetComponent<PlayerController>().enabled = true;
        Panel.SetActive(false);
    }


}
