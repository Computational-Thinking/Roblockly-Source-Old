using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class LidarScript : MonoBehaviour {
	public InformationRobot info;

	public GameObject baseRobot;
	private float largoBase;
	private float anchoBase;
	private float altoBase;

	public GameObject lidarSensor;
	private GameObject isOk;

	public float distanceSensor = 0.0f;
	public float error = 0.0f;

	private bool posicionReal = true;



	// Use this for initialization
	void Start () {
		baseRobot = GameObject.Find ("Robot/BaseSq");
		GameObject go = GameObject.Find ("Robot");
		info = (InformationRobot)go.GetComponent(typeof(InformationRobot));

		isOk = transform.GetChild (transform.childCount - 2).gameObject;

		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;
		altoBase = baseRobot.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if ((this.transform.parent.tag == "TopSide") && largoBase < baseRobot.transform.localScale.z)
			transform.Translate (0, 0, 0.0125F);
		else if ((this.transform.parent.tag == "TopSide") && largoBase > baseRobot.transform.localScale.z)
			transform.Translate (0, 0, -0.0125F);

		if ((this.transform.parent.tag == "TopSide") && altoBase < baseRobot.transform.localScale.y)
			transform.Translate (0, 0.025F, 0);
		else if ((this.transform.parent.tag == "TopSide") && altoBase > baseRobot.transform.localScale.y)
			transform.Translate (0, -0.025F, 0);
		

		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;
		altoBase = baseRobot.transform.localScale.y;

		if (posicionReal == false) {
			isOk.SetActive (true);
		} else {
			isOk.SetActive (false);
		}
	}


	/**
	 * Métodos getter para las variables
	 */

	public float getDistanceSensor() {
		return distanceSensor;
	}

	public float getError() {
		return error;
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

		if (other.tag == "Base") {
			posicionReal = false;
		}
	}
}
