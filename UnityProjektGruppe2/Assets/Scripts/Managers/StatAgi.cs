using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatAgi : MonoBehaviour
{
    Text text;
    private int agi;
    // Use this for initialization
    void Awake()
    {
        text = GetComponent<Text>();
        agi = PlayerPrefs.GetInt("Agility");
        AgiStat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AgiStat()
    {
        agi = PlayerPrefs.GetInt("Agility");
        text.text = "Agility: " + agi;
    }
}
