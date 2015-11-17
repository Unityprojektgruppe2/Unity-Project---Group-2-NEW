using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {

    [SerializeField]
    private Slider loadingBar;
    [SerializeField]
    private Text loadingText;

    private AsyncOperation async = null; // When assigned, load is in progress.
    private IEnumerator LoadALevel(string levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        yield return async;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadALevel("Level1"));
    }
	
	// Update is called once per frame
	void Update () {
        if (async != null)
        {
            loadingBar.value = 100 * async.progress;
            loadingText.text = "Loading... " + loadingBar.value + "%";
        }
        //loadingBar.value += 1.00f;
        //loadingText.text = "Loading... " + loadingBar.value + "%";

    }
}
