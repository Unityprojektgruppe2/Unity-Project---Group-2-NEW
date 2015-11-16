using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatDef : MonoBehaviour {


    Text text;
    private int def;
    // Use this for initialization
    void Awake()
    {
        def = PlayerPrefs.GetInt("Defence");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DefStat()
    {
        text.text = "Defence: " + def;
    }
}
