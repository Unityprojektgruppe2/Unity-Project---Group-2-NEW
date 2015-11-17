using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    private int highscore1;
    private int highscore2;
    private int highscore3;
    [SerializeField]
    Text text1;
    [SerializeField]
    Text text2;
    [SerializeField]
    Text text3;
	// Use this for initialization
	void Awake () {

    }
    void Start()
    {
        LoadScores();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void LoadScores()
    {
        highscore1 = PlayerPrefs.GetInt("Highscore");
        highscore2 = PlayerPrefs.GetInt("Highscore2");
        highscore3 = PlayerPrefs.GetInt("Highscore3");
        text1.text = "Highscore1: " + highscore1;
        text2.text = "Highscore2: " + highscore2;
        text3.text = "Highscore3: " + highscore3;
    }
}
