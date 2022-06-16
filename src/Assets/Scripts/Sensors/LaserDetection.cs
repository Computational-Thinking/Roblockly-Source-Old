using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour {

	private Ray ray;
	private RaycastHit raycastHit;
	private float distanceHit;
	private bool detection = false;

	public LaserSensorScript laser;

	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update () {
		ray = new Ray (transform.position, transform.up);	

		Debug.DrawRay (transform.position, transform.up, Color.red);

		if (Physics.Raycast (ray, out raycastHit, laser.getDistanceSensor ())) {

			detection = true;
			distanceHit = raycastHit.distance;
		
			// Falta lo de la precisión
		} else {
			detection = false;
			distanceHit = 0;
		}
			
		if (detection) {
			precisionEffect ();
			print ("Láser devuelve objeto a " + distanceHit);
		}
	}


	public void precisionEffect() {
		float distanceReal = distanceHit;

		float error = Random.Range (-laser.getError () * laser.getDistanceSensor(), laser.getError () * laser.getDistanceSensor());

		distanceHit += error;

		if (distanceHit < 0)
			distanceHit = 0;

	}
	public bool getDetection(){
		return this.detection;
	}

	public float getDistanceHit(){
		return this.distanceHit;
	}
}
