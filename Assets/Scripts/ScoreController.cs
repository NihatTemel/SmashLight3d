using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{

    [SerializeField] GameObject HighScoreLine;
    [SerializeField] TMP_Text HighScoreText;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text ScoreTextEnd;
    [SerializeField] Transform Player;

    int score = 0;

    void Start()
    {
        HighScoreText.text = "" + PlayerPrefs.GetInt("highscore");
        var pos = HighScoreLine.transform.position;
        pos.x = PlayerPrefs.GetInt("highscore");
        HighScoreLine.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.x > score) 
        {
            score++;
            if (PlayerPrefs.GetInt("highscore") < score) 
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }

        ScoreText.text = "Score " + score;
        ScoreTextEnd.text = "Score " + score;
    }
}
