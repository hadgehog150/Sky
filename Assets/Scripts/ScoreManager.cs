using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] Text scoreDisplay1, scoreDisplay2;
    [SerializeField] Text HighScoreText;
    private bool newRec;

    [SerializeField] int highscore;

    private void FixedUpdate()
    {
        scoreDisplay1.text = score.ToString();
        scoreDisplay2.text = "Score: " + score.ToString();
        highscore = (int)score;
        scoreDisplay1.text = highscore.ToString();
        if (PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
            newRec = true;
        }

        if (newRec)
        {
            HighScoreText.text = "New record: " + PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            HighScoreText.text = "Record: " + PlayerPrefs.GetInt("score").ToString();
        }
    }
}
