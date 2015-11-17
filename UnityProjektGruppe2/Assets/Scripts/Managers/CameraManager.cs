using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DisableOrientation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void DisableOrientation()
    {
        Screen.autorotateToPortrait = false; //No auto rotation to portrait
        Screen.autorotateToPortraitUpsideDown = false; //No auto rotation to portrait (inverse)
        Screen.orientation = ScreenOrientation.Landscape; //Sets orientation to landscape
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Sets the screen timeout to neversleep (Keep Awake)
    }
}
