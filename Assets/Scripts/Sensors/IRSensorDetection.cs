using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRSensorDetection : MonoBehaviour {

	private Ray sensor;
	private RaycastHit hit;
	private float distanceHit;
	private bool detection;

	public IRSensorScript irSensor;

	private bool oscuro = false;
	private bool oscuroReal = false;
	float grayscale = 0.0F;
	GameObject Robot;
	private void Awake(){
		Robot = GameObject.Find ("/Permanente/Robot");
	}
	// Use this for initialization
	void Start () {	
		
	}
	
	// Update is called once per frame
	void Update () {
		sensor = new Ray (transform.position, -transform.right);

		Debug.DrawRay (transform.position, -transform.right, Color.green);

		if (Physics.Raycast (sensor, out hit, irSensor.getDistanceSensor())) {

			detection = true;
			distanceHit = hit.distance;

			GameObject obj = hit.collider.gameObject;
			Color color = obj.GetComponent<Renderer> ().material.GetColor ("_Color");
			grayscale = color.grayscale;

			if (grayscale <= 0.5)
				oscuro = true;
			else
				oscuro = false;

			//precisionEffect ();
		}

		if (oscuro && detection)
			print ("El sensor IR está detectando algo oscuro.");
		else if (!oscuro && detection)
			print ("El sensor IR está detectando algo claro.");

		detection = false;
	}


	
	/*void precisionEffect () {
		int value = Random.Range (1, 100);

		if (value > irSensor.getPecision ())
			if (oscuro)
				oscuro = false;
			else
				oscuro = true;
	}
    */
	public bool getDetection(){
		return this.detection;
	}

	public bool getOscuro(){
		return this.oscuro;
	}
}
