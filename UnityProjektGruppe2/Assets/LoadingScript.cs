using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour {


    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.

    private AsyncOperation async = null; // When assigned, load is in progress.
    private IEnumerator LoadALevel(string levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        yield return async;
    }
    void OnGUI()
    {
        if (async != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);
            GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
        }
    }

    // Use this for initialization
    void Start () {
        LoadALevel("Level1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
