using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision.gameObject);
		/*foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.relativeVelocity.magnitude > 2)
			audioSource.Play();*/
	}

	void OnCollisionStay(Collision collision) {
		Debug.Log ("Se queda");
	}

	void OnCollisionExit(Collision collision) {
		Debug.Log ("Salida: " + collision.gameObject);
 	}
}
