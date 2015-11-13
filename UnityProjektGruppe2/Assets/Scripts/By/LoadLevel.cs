using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    private bool buttonPressed; //Used to check, if the button has been pressed
    private bool hasRunned; //Used to check if the stat has runned

    // Use this for initialization
    public void Start()
    {
        buttonPressed = false;
        hasRunned = false;

        //For Test!!!
        PlayerPrefs.SetInt("curLevel", 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        buttonPressed = false;
    }

    public void SwapScreen()
    {
        Debug.Log("Im running!!!!!!!!!11");
        if (gameObject.tag == "canButton" && buttonPressed == false)
        {
            //Sets buttonPressed to true, so it only accepts 1 input at a time
            buttonPressed = true;

            Debug.Log("Button pressed");

            //Looks for every Button in the gameObject with a tag "StatShop"
            foreach (GameObject Button in GameObject.FindGameObjectsWithTag("canButton"))
            {
                Debug.Log(Button + " : Was the button pressed");
                Debug.Log("It found some buttons!");

                //Runs through the Buttons children's text transforms.
                foreach (Transform text in transform)
                {
                    Debug.Log("They even had some Texts attached!?");

                    //If's checks which Button was pressed, by its name
                    if (text.name == "Exit" && hasRunned == false)
                    {
                        //Sets hasRunned to true, so it only applies this 1 time
                        hasRunned = true;

                        Debug.Log("Should go to the Main Menu!");

                        Application.LoadLevel("MainMenu");
                    }

                    if (text.name == "Continue" && hasRunned == false)
                    {
                        //Sets hasRunned to true, so it only applies this 1 time
                        hasRunned = true;

                        Debug.Log("Should go to the next level!");

                        Application.LoadLevel("Level1");
                        //Application.LoadLevel("Level" + PlayerPrefs.GetInt("curLevel") + 1);
                        PlayerPrefs.SetInt("curLevel", PlayerPrefs.GetInt("curLevel") + 1);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Didn't find any button!!?");
        }

        hasRunned = false;
    }
}