using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatDef : MonoBehaviour
{
    Text text;
    private int def;
    
    // Use this for initialization
    void Awake()
    {
        text = GetComponent<Text>();
        def = PlayerPrefs.GetInt("Defence");
        DefStat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DefStat()
    {
        def = PlayerPrefs.GetInt("Defence");
        text.text = "Defence: " + def;
    }
}