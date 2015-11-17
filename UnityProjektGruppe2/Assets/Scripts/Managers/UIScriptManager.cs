using UnityEngine;
using System.Collections;

public class UIScriptManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGameClicked()
    {
        PlayerPrefs.SetInt("Agility", 10);
        PlayerPrefs.SetInt("Strength", 10);
        PlayerPrefs.SetInt("Defence", 10);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("EnemyHealth", 0);
        PlayerPrefs.SetInt("enemyDmgModifier", 0);
        PlayerPrefs.SetInt("curLevel", 0);

        Application.LoadLevel("City");
    }
    public void ExitGameClicked()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore",0);
        PlayerPrefs.SetInt("Highscore2",0);
        PlayerPrefs.SetInt("Highscore3",0);
    }

    private void onClick()
    {

    }
}
