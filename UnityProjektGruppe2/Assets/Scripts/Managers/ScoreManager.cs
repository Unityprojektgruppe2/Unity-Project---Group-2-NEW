using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public static int score;
    [SerializeField]
    public static int highScore = 0;
    [SerializeField]
    public static int highScore2 = 0;
    [SerializeField]
    public static int highScore3 = 0;

    Text text;


    void Awake()
    {
        text = GetComponent<Text>();

        score = PlayerPrefs.GetInt("Score");

        if (PlayerPrefs.HasKey("Score"))
        {
            //If its lvl 1
            //if (Level)
            //{

            //} 
            //score = 0;

            //If not
            //    else
            //{
            //    score = PlayerPrefs.GetInt("Score");
            //}
        }
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore2 = PlayerPrefs.GetInt("Highscore");
        }
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore3 = PlayerPrefs.GetInt("Highscore");
        }

    }


    void Update()
    {
        text.text = "" + score;
    }
    /// <summary>
    /// To save the Score call this Method when switching to the town Scene
    /// </summary>
    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
