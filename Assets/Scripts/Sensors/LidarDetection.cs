using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidarDetection : MonoBehaviour {

	private Ray ray;
	private RaycastHit raycastHit;
	private float distanceHit;
	private bool detection = false;

	public LidarScript lidar;
	public Transform centerTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		detection = false;

		float distanciaMenor = 100.0f;

		for (float i = -1f; i <= 1f; i += 0.2f) {
			for (float j = -1f; j <= 1f; j += 0.2f) {
				Vector3 v = new Vector3 (i, 0, j);
				ray = new Ray (centerTransform.position, v);

				Debug.DrawRay (centerTransform.position, v, Color.yellow);

				if (Physics.Raycast (ray, out raycastHit, lidar.getDistanceSensor ())) {
					if (raycastHit.collider.gameObject.tag != "Lidar") {
						if (raycastHit.distance < distanciaMenor) {
							distanciaMenor = raycastHit.distance;
							detection = true;
						}
					} 					
				}
			}
		}
		distanceHit = distanciaMenor;


		if (detection) {
			precisionEffect();
			print ("Lidar detecta objeto a " + distanceHit);
		}
	}

	public void precisionEffect() {
		float distanceReal = distanceHit;

		float error = Random.Range (-lidar.getError () * lidar.getDistanceSensor(), lidar.getError () * lidar.getDistanceSensor());

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
