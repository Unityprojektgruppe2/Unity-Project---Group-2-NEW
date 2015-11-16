using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatStre : MonoBehaviour {

    Text text;
    private int stre;
    // Use this for initialization
    void Awake()
    {
        stre = PlayerPrefs.GetInt("Strength");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StrStat()
    {
        text.text = "Strength: " + stre;
    }
}
