using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class IRSensorScript : MonoBehaviour {

	public GameObject baseRobot;
	private float largoBase;
	private float anchoBase;

	public InformationRobot info;
	private GameObject isOk;

	public float distanceSensor = 0.0f;
	public float precision = 0.0f;

	public GameObject IRSensor;

	public Slider rango;
	//public Slider precisionInput;

	private bool posicionReal = true;
	public TextMeshProUGUI sensorname;




	// Establecemos los valores máximos y mínimo de los valores del sensor
	void Start() {
			
		if (gameObject.transform.parent.parent.name == "Robot"){

			baseRobot = GameObject.Find ("Robot/BaseSq");
			GameObject go = GameObject.Find ("Robot");
			info = (InformationRobot)go.GetComponent(typeof(InformationRobot));
			
			isOk = transform.GetChild (transform.childCount - 1).gameObject;
			
			//Arreglado fallo con Slider
			rango = GameObject.Find ("SliderRangeIR").GetComponent<Slider>();
			//precisionInput = GameObject.Find ("SliderPrecisionIR").GetComponent<Slider>();


			rango.minValue = 0.1f*12.5f;
			rango.maxValue = 0.8f*12*5f;

			//precisionInput.minValue = 0;
			//precisionInput.maxValue = 100;

			largoBase = baseRobot.transform.localScale.z;
			anchoBase = baseRobot.transform.localScale.x;

			/////Cambiar nombre a los sensoresIR que se instancian/////
			int count = 0;
			foreach (Transform side in go.transform) {

				foreach (Transform irSensor in side){

					if(irSensor.tag == "IR"){
						count++;
						Debug.Log(count);
						if (GameObject.Find("SensorIR"+count.ToString())==null){
							break;
						}
					}
				}
			}
			gameObject.name = "SensorIR"+count.ToString();
			sensorname.text = "SensorIR"+count.ToString();
            Debug.Log("nombre del sensor: " + sensorname.text);
			/////Cambiar nombre a los sensoresIR que se instancian/////
		}
	}

	// Actualizamos en todo momentos los valores internos del sensor (Rango y precisión) con respecto a los Sliders
	void Update () {
		if (gameObject.transform.parent.parent.name == "Robot"){

			if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase < baseRobot.transform.localScale.z)
				transform.Translate (0, 0, -0.0125F);
			else if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase > baseRobot.transform.localScale.z)
				transform.Translate (0, 0, 0.0125F);

			if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase < baseRobot.transform.localScale.x)
				transform.Translate (0, 0, -0.0125F);
			else if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase > baseRobot.transform.localScale.x)
				transform.Translate (0, 0, 0.0125F);

			largoBase = baseRobot.transform.localScale.z;
			anchoBase = baseRobot.transform.localScale.x;

			if (posicionReal == false) {
				isOk.SetActive (true);
			} else {
				isOk.SetActive (false);
			} 
		}
	}
		

	public float getDistanceSensor() {
		return this.distanceSensor;
	}

	/*public float getPecision() {
		return this.precision;
	}*/


	public void setDistanceSensor(float distance) {
		this.distanceSensor = distance;
	}

	/*public void setPrecision(float precision) {
		this.precision = precision;
	}*/


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
