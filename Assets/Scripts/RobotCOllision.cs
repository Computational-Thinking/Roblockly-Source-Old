using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCOllision : MonoBehaviour {

	ArrayList contacts = new ArrayList();

	Collider colliderTouchBySensor;
	GameObject sensorTouch;

	// Collider collider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject frontSide = GameObject.Find ("/Permanente/Robot/FrontSide");
		GameObject backSide = GameObject.Find ("/Permanente/Robot/BackSide");

		foreach (Transform child in frontSide.transform) {
			if (child.tag == "Touch")
				contacts.Add (child.gameObject);
		}

		foreach (Transform child in backSide.transform) {
			if (child.tag == "Touch")
				contacts.Add (child.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			if (contact.thisCollider.gameObject.tag == "Contacto") {

				colliderTouchBySensor = contact.otherCollider;
				sensorTouch = contact.thisCollider.gameObject;

				TouchSensorContact touchContact = (TouchSensorContact)contact.thisCollider.gameObject.GetComponent (typeof(TouchSensorContact));
				touchContact.setContact (true);
			}
		}
	}

	void OnCollisionExit (Collision collision) {
		if (collision.collider == colliderTouchBySensor) {
			colliderTouchBySensor = null;

			TouchSensorContact touchContact = (TouchSensorContact)sensorTouch.GetComponent (typeof(TouchSensorContact));
			touchContact.setContact (false);
		}
	}
}
