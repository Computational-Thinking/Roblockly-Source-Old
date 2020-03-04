using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinmapScript : MonoBehaviour {

	public Transform robot;

	void Start(){
		robot = GameObject.Find("Permanente/Robot").GetComponent<Transform>();
	}
	void LateUpdate (){
	
		Vector3 newPosition = robot.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
	}
}
