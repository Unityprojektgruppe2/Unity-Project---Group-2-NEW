using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    private int highscore1;
    private int highscore2;
    private int highscore3;
    Text text;
	// Use this for initialization
	void Awake () {
        highscore1 = PlayerPrefs.GetInt("Highscore");
        highscore2 = PlayerPrefs.GetInt("Highscore2");
        highscore3 = PlayerPrefs.GetInt("Highscore3");
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Highscore1: " + highscore1;
        text.text = "Highscore2: " + highscore2;
        text.text = "Highscore3: " + highscore3;
	}
}
