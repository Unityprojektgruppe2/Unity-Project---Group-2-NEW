using UnityEngine;
using System.Collections;

public class SizeAndShape : MonoBehaviour {

    // The buildings Vector
    [SerializeField]
    private GameObject building;

    //The buttons variables
    private Vector2 pos;
    private float width;
    private float heigth;

    // Use this for initialization
    void Start ()
    {
        building.GetComponent<RectTransform>();
        pos = building.transform.position;

        transform.position = pos;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
