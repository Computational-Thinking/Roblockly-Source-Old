using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensorContact : MonoBehaviour {

	private bool contact = false;

	// Use this for initialization
	void Update () {
		// print ("Hay contacto: " + contact);
	}

	// Detecta si está colisionando con algo
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name != "Robot") {
			contact = true;
		}
	} 

	// Detecta si ha dejado de colisionar con algo
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name != "Robot")
			contact = false;
	}

	 
	public void setContact(bool contact) {
		this.contact = contact;
	}

	public bool getContact () {
		return this.contact;
	}
}
