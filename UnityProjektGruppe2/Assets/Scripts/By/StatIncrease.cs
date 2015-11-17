using UnityEngine;
using System.Collections;

public class StatIncrease : MonoBehaviour {

    //Stats which is increased by a value, set in Start()
    private int _addStr;
    private int _addAgi;
    private int _addDef;

    [SerializeField]
    private GameObject _shopStrength;

    [SerializeField]
    private ScoreScript _myScore;

    //Takes the Current stat from the player and stores in a variable
    private int currentStat;

    //A variable, which stores the new stat for the player
    private int newStat;

    //Finds the nameTag of the building clicked
    private string building;


    private bool buttonPressed; //Used to check, if the button has been pressed
    private bool hasRunned; //Used to check if the stat has runned


    void Awake ()
    {
        //For Tests!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //Also resets the stats, if running in debug in unity! Run these ones, and they are reset
        //PlayerPrefs.GetInt("Strength");
        //PlayerPrefs.GetInt("Agility");
        //PlayerPrefs.GetInt("Defence");
        //PlayerPrefs.GetInt("Score");

    }

    // Use this for initialization
    public void Start ()
    {
        buttonPressed = false; //Makes sure no button has been pressed
        hasRunned = false; //Makes sure no statIncreases has been runned

        //Shows the currentScore
        _myScore.ChangeScore();
        _addStr = 10;
        _addAgi = 10;
        _addDef = 10;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        //Debug.Log("Im runnnnnnnnning!!!!!");
        buttonPressed = false;
    }

    // Skal kører når der clickes på knappen !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
    public void Increase()
    {
        //Checks that the players score is bigger than 0
        if (PlayerPrefs.GetInt("Score") > 0)
        {
            //Checks if the player is click'ing on a button tagged "StatShop"
            if (gameObject.tag == "StatShop" && buttonPressed == false)
            {
                //Sets buttonPressed to true, so it only accepts 1 input at a time
                buttonPressed = true;

                //Debug.Log("Button pressed");
                
                //Looks for every Button in the gameObject with a tag "StatShop"
                foreach (GameObject Button in GameObject.FindGameObjectsWithTag("StatShop"))
                {
                    //Debug.Log(Button + " : Was the button pressed");
                    //Debug.Log("It found some buttons!");

                    //Runs through the Buttons children's text transforms.
                    foreach (Transform text in transform)
                    {
                        //Debug.Log("They even had some Texts attached!?");

                        //If's checks which Button was pressed, by its name
                        if (text.name == "Strength" && hasRunned == false)
                        {
                            //Sets hasRunned to true, so it only applies this 1 time
                            hasRunned = true;

                            //Gets the current Strength from the player, and stores it in a variable currentStat
                            currentStat = PlayerPrefs.GetInt("Strength");

                            //Checks If the current stat is less or equal to the score_value
                            if (currentStat <= PlayerPrefs.GetInt("Score"))
                            {
                                //Debug.Log("Strenth Shop, has been clicked");
                                //Debug.Log("Player's current Strength is " + currentStat);

                                //Runs the functions AddIncrease, and stores the added values in the variable newStat
                                newStat = AddIncrease(currentStat, _addStr);

                                //Debug.Log("Stat is increased to " + newStat);

                                //Subtracts the current Strength_value from the score
                                PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") - currentStat));

                                //Sets the newStat for the player
                                PlayerPrefs.SetInt("Strength", newStat);

                                //Debug.Log((PlayerPrefs.GetInt("Strength") + " is now the players Strength"));
                            }
                        }
                        //If's checks which Button was pressed, by its name
                        if (text.name == "Agility" && hasRunned == false)
                        {
                            //Sets hasRunned to true, so it only applies this 1 time
                            hasRunned = true;

                            //Gets the current Agility from the player, and stores it in a variable currentStat
                            currentStat = PlayerPrefs.GetInt("Agility");

                            //Checks If the current stat is less or equal to the score_value
                            if (currentStat <= PlayerPrefs.GetInt("Score"))
                            {
                                //Debug.Log("Agility Shop, has been clicked");
                                //Debug.Log("Player's current Agility is " + currentStat);

                                //Runs the functions AddIncrease, and stores the added values in the variable newStat
                                newStat = AddIncrease(currentStat, _addAgi);

                                //Debug.Log("Stat is increased to " + newStat);

                                //Subtracts the current Agility_value from the score
                                PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") - currentStat));

                                //Sets the newStat for the player
                                PlayerPrefs.SetInt("Agility", newStat);

                                //Debug.Log((PlayerPrefs.GetInt("Agility") + " is now the players Agility"));
                            }
                        }
                        //If's checks which Button was pressed, by its name
                        if (text.name == "Defence" && hasRunned == false)
                        {
                            //Sets hasRunned to true, so it only applies this 1 time
                            hasRunned = true;

                            //Gets the current Defence from the player, and stores it in a variable currentStat
                            currentStat = PlayerPrefs.GetInt("Defence");

                            //Checks If the current stat is less or equal to the score_value
                            if (currentStat <= PlayerPrefs.GetInt("Score"))
                            {
                                //Debug.Log("Defence Shop, has been clicked");
                                //Debug.Log("Player's current Defence is " + currentStat);

                                //Runs the functions AddIncrease, and stores the added values in the variable newStat
                                newStat = AddIncrease(currentStat, _addDef);

                                //Debug.Log("Stat is increased to " + newStat);

                                //Subtracts the current Defence_value from the score
                                PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") - currentStat));

                                //Sets the newStat for the player
                                PlayerPrefs.SetInt("Defence", newStat);

                                //Debug.Log((PlayerPrefs.GetInt("Defence") + " is now the players Defence"));
                            }
                        }

                        //Runs the function ChangeScore, in the ScoreScript.
                        _myScore.ChangeScore();
                        //Old calc and score Increase
                        //#region
                        //if (text.name == "Agility" && hasRunned == false)
                        //{
                        //    //Sets hasRunned to true, so it only applies this 1 time
                        //    hasRunned = true;

                        //    //Debug.Log("Agility Shop, has been clicked");

                        //    //Gets the current Agility from the player, and stores it in a variable currentStat
                        //    currentStat = PlayerPrefs.GetInt("Agility");

                        //    Debug.Log("Player's current Agility is " + currentStat);

                        //    //Runs the functions AddIncrease, and stores the added values in the variable newStat
                        //    newStat = AddIncrease(currentStat, _addAgi);

                        //    //Debug.Log("Stat is increased to " + newStat);

                        //    //Sets the newStat for the player
                        //    PlayerPrefs.SetInt("Agility", newStat);

                        //    Debug.Log((PlayerPrefs.GetInt("Agility") + " is now the players Agility"));
                        //}

                        //if (text.name == "Defence" && hasRunned == false)
                        //{
                        //    //Sets hasRunned to true, so it only applies this 1 time
                        //    hasRunned = true;

                        //    //Debug.Log("Defence Shop, has been clicked");

                        //    //Gets the current Defence from the player, and stores it in a variable currentStat
                        //    currentStat = PlayerPrefs.GetInt("Defence");

                        //    Debug.Log("Player's current Defence is " + currentStat);

                        //    //Runs the functions AddIncrease, and stores the added values in the variable newStat
                        //    newStat = AddIncrease(currentStat, _addDef);

                        //    //Debug.Log("Stat is increased to " + newStat);

                        //    //Sets the newStat for the player
                        //    PlayerPrefs.SetInt("Defence", newStat);

                        //    Debug.Log((PlayerPrefs.GetInt("Defence") + " is now the players Defence"));
                        //}
                        //#endregion
                    }
                }
            }
            else
            {
                Debug.Log("Didn't find any StatShops!!?");
            }
            //Makes that statShop available again
            hasRunned = false;
        }
    }

    //Adds two variables(oldStat and the increaseVal) and returns the result addedStat
    public int AddIncrease(int _oldStat, int _increaseVal)
    {
        int addedStat = _oldStat + _increaseVal;
        return addedStat;
    }
}
