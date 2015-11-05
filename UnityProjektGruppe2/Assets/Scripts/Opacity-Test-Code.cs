using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    Renderer opacityTest;

	// Use this for initialization
	void Start () {
        opacityTest = GetComponent<Renderer>();
       Color bob = opacityTest.material.color;
        bob.a = 0.5f;
        opacityTest.material.color = bob;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
