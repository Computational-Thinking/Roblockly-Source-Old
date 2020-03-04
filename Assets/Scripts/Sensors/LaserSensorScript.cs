using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;


public class LaserSensorScript : MonoBehaviour {

	public InformationRobot info;

	public GameObject baseRobot;
	private float largoBase;
	private float anchoBase;

	public GameObject laserSensor;
	public float distanceSensor = 0.0f;
	public float error = 0.0f;

	private bool posicionReal = true;
	private GameObject isOk;

	void Start() {
		baseRobot = GameObject.Find ("Robot/BaseSq");
		GameObject go = GameObject.Find ("Robot");
		info = (InformationRobot)go.GetComponent(typeof(InformationRobot));

		isOk = transform.GetChild (transform.childCount - 1).gameObject;

		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;
	}


	void Update() {
		if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase < baseRobot.transform.localScale.z)
			transform.Translate (-0.0125F, 0, 0);
		else if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase > baseRobot.transform.localScale.z)
			transform.Translate (0.0125F, 0, 0);

		if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase < baseRobot.transform.localScale.x)
			transform.Translate (-0.0125F, 0, 0);
		else if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase > baseRobot.transform.localScale.x)
			transform.Translate (0.0125F, 0, 0);

		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;

		if (posicionReal == false) {
			isOk.SetActive (true);
		} else {
			isOk.SetActive (false);
		} 
	
		print ("ERROR: " + error);
	}
		
	public float getDistanceSensor() {
		return this.distanceSensor;
	}

	public float getError() {
		return this.error;
	}

	public void setDistanceSensor(float distance) {
		this.distanceSensor = distance;
	}

	public void setError(float error) {
		this.error = error;
	}


	public bool getPosicionReal() {
		return this.posicionReal;
	}
		

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Base") {
			posicionReal = true;
		}


		if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar" || other.tag == "Touch") {
			posicionReal = false;
			print ("TAG: " + other.tag);
		}
	}
		

	void OnTriggerExit (Collider other) {
		if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar"  || other.tag == "Touch")
			posicionReal = true;

		if (other.tag == "Base")
			posicionReal = false;
	}
}
