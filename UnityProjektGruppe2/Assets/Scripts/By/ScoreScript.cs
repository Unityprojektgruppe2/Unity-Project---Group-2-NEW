using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    Text text;

    [SerializeField]
    private int myScore;

    void Awake()
    {
        text = GetComponent<Text>();
        //PlayerPrefs.SetInt("Score", 0);
        myScore = PlayerPrefs.GetInt("Score");
        //Debug.Log("score is " + PlayerPrefs.GetInt("Score"));
    }
    void Update()
    {
        
    }

    //Sets the new Score, to the GUI text
    public void ChangeScore()
    {
        myScore = PlayerPrefs.GetInt("Score"); //Finds the current score and stores it in a value
        text.text = "Score: " + myScore; //Adds new text, to the Text object on the GUI
    }
}
