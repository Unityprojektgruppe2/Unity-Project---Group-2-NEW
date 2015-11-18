using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    private bool buttonPressed; //Used to check, if the button has been pressed
    private bool hasRunned; //Used to check if the stat has runned
    public int currentHealth = 100;
    public int enemyDamageModifier = 10;
    private bool runnedHighScore = false;
    private bool scoreSet = false;
    private bool highcal1 = false;
    private bool highcal2 = false;
    private int tempscore = 0;
    private int tempscore2 = 0;


    public void Awake()
    {
    }

    // Use this for initialization
    public void Start()
    {
        buttonPressed = false;
        hasRunned = false;
        runnedHighScore = false;

        //PlayerPrefs.SetInt("curLevel", 0); DO NOT ENABLE
        //PlayerPrefs.SetInt("enemyDmgModifier", enemyDamageModifier); DO NOT ENABLE
    }
	
	// Update is called once per frame
	void Update ()
    {
        buttonPressed = false;
    }

    public void SwapScreen()
    {
        //Debug.Log("Im running!!!!!!!!!11");
        if (gameObject.tag == "canButton" && buttonPressed == false)
        {
            //Sets buttonPressed to true, so it only accepts 1 input at a time
            buttonPressed = true;

            //Debug.Log("Button pressed");

            //Looks for every Button in the gameObject with a tag "StatShop"
            foreach (GameObject Button in GameObject.FindGameObjectsWithTag("canButton"))
            {
                //Debug.Log(Button + " : Was the button pressed");
                //Debug.Log("It found some buttons!");

                //Runs through the Buttons children's text transforms.
                foreach (Transform text in transform)
                {
                    //Debug.Log("They even had some Texts attached!?");

                    //If's checks which Button was pressed, by its name
                    if (text.name == "Exit" && hasRunned == false)
                    {
                        //Sets hasRunned to true, so it only applies this 1 time
                        hasRunned = true;

                        //Debug.Log("Should go to the Main Menu!");

                        if (!runnedHighScore)
                        {
                            int myScore = PlayerPrefs.GetInt("Score");
                            runnedHighScore = true;
                            if (PlayerPrefs.HasKey("Highscore") && scoreSet == false)
                            {
                                
                                if (PlayerPrefs.GetInt("Highscore") < myScore)
                                {
                                    tempscore = PlayerPrefs.GetInt("Highscore");
                                    PlayerPrefs.SetInt("Highscore", myScore);
                                    highcal1 = true;
                                    Debug.Log(PlayerPrefs.GetInt("Highscore"));
                                }

                            }
                            if (PlayerPrefs.HasKey("Highscore2") && scoreSet == false)
                            {
                                if (PlayerPrefs.GetInt("Highscore2") < myScore && PlayerPrefs.GetInt("Highscore2") < PlayerPrefs.GetInt("Highscore"))
                                {
                                    if (highcal1 == true)
                                    {
                                        tempscore2 = PlayerPrefs.GetInt("Highscore2");
                                        PlayerPrefs.SetInt("Highscore2", tempscore);
                                        highcal1 = false;
                                        highcal2 = true;
                                    }
                                    else
                                    {
                                        tempscore2 = PlayerPrefs.GetInt("Highscore2");
                                        PlayerPrefs.SetInt("Highscore2", myScore);
                                        highcal2 = true;
                                    }

                                    Debug.Log(PlayerPrefs.GetInt("Highscore2"));
                                }

                            }
                            if (PlayerPrefs.HasKey("Highscore3") && scoreSet == false)
                            {
                                if (PlayerPrefs.GetInt("Highscore3") < myScore && PlayerPrefs.GetInt("Highscore3") < PlayerPrefs.GetInt("Highscore2"))
                                {

                                    if (highcal2 == true)
                                    {
                                        PlayerPrefs.SetInt("Highscore3", tempscore2);
                                        highcal2 = false;

                                    }
                                    else
                                    {
                                        PlayerPrefs.SetInt("Highscore3", myScore);
                                    }
                                    Debug.Log(PlayerPrefs.GetInt("Highscore3"));
                                }

                            }
                            else
                            {
                                PlayerPrefs.SetInt("Highscore", myScore);
                                PlayerPrefs.SetInt("Highscore2", myScore);
                                PlayerPrefs.SetInt("Highscore3", myScore);
                                //Debug.Log(myScore);
                            }

                            scoreSet = true;
                            PlayerPrefs.SetInt("Score", ScoreManager.score);
                        }

                        Application.LoadLevel("MainMenu");
                    }

                    if (text.name == "Continue" && hasRunned == false)
                    {
                        //Sets hasRunned to true, so it only applies this 1 time
                        hasRunned = true;

                        //Debug.Log("Should go to the next level!");

                        Application.LoadLevel("LoadingScreen");
                        //Application.LoadLevel("Level" + PlayerPrefs.GetInt("curLevel") + 1);
                        PlayerPrefs.SetInt("curLevel", PlayerPrefs.GetInt("curLevel") + 1);
                        currentHealth += 10;
                        //Spawner.enemyStrengthSize++;
                        PlayerPrefs.SetInt("EnemyHealth", currentHealth);
                        PlayerPrefs.SetInt("enemyDmgModifier", PlayerPrefs.GetInt("enemyDmgModifier") + enemyDamageModifier);

                    }
                }
            }
        }
        else
        {
            //Debug.Log("Didn't find any button!!?");
        }

        hasRunned = false;
    }
}