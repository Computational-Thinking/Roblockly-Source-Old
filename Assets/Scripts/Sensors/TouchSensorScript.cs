using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchSensorScript : MonoBehaviour {

	public GameObject touchSensor;
	public GameObject baseRobot;
	private float largoBase;
	private float anchoBase;
	public InformationRobot info;
	private GameObject isOk;
	private bool posicionReal = true;
	public TextMeshProUGUI sensorname;


	// Use this for initialization
	void Start () {
		if (gameObject.transform.parent.parent.name == "Robot"){
			baseRobot = GameObject.Find ("Robot/BaseSq");
			GameObject go = GameObject.Find ("Robot");
			info = (InformationRobot)go.GetComponent(typeof(InformationRobot));

			isOk = transform.GetChild (transform.childCount - 1).gameObject;

			largoBase = baseRobot.transform.localScale.z;
			anchoBase = baseRobot.transform.localScale.x;
			/////Cambiar nombre a los sensoresTouch que se instancian/////
			int count = 0;
			foreach (Transform side in go.transform) {

				foreach (Transform touchSensor in side){

					if(touchSensor.tag == "Touch"){
						count++;
						Debug.Log(count);
					//TO DO: condición para parar el foreach si detecta que el nombre del sensor no está cogido
						if (GameObject.Find("SensorTouch"+count.ToString())==null){
							break;
						}
					}
				}
			}
			gameObject.name = "SensorTouch"+count.ToString();
			sensorname.text = "SensorTouch"+count.ToString();
			/////Cambiar nombre a los sensoresTouch que se instancian/////
		}
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.parent.parent.name == "Robot"){
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
		}
	}



	public bool getPosicionReal() {
		return this.posicionReal;
	}




	void OnTriggerEnter(Collider other) {
		/* if (other.tag != "Base") {
			if (other.tag == "Laser") {
				posicionReal = false;
			} else if (other.tag == "Base") {
			} else {
				posicionReal = true;
			}
		}*/
		if (other.tag == "Base") {
			posicionReal = true;
		}


		if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar" || other.tag == "Touch") {
			posicionReal = false;
			print ("TAG: " + other.tag);
		}
	}


	void OnTriggerExit (Collider other) {
		/*if (other.tag == "Laser") {
			posicionReal = true;
		} else if (other.tag == "Base") {
		} */
		if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar"  || other.tag == "Touch")
			posicionReal = true;

		if (other.tag == "Base") {
			posicionReal = false;
		}
	}
}
