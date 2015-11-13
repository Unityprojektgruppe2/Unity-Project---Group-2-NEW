using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField]
    private Transform transformToRotate;

    [SerializeField]
    private float spdRotation;

    private Vector3 newRotation;

	// Use this for initialization
	void Start ()
    {
        spdRotation = 0.7f;
        transformToRotate.GetComponent<Transform>();

        newRotation = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transformToRotate.Rotate(newRotation * (spdRotation * Time.deltaTime));
	}
}
