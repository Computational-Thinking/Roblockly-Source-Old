using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angulos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print ("Ángulos de x: " + transform.localEulerAngles.x);
	}
}
