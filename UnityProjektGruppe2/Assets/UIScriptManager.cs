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
        Application.LoadLevel("Level1");
    }
    private void onClick()
    {

    }
}
