using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour
{
	public Rigidbody rb;

	public Transform frontLeftWheel;
	public Transform frontRightWheel;

	public float speed = 50;
	public float maxSteerAngle = 30;

	private float motorForce = 0;

	void Start() {
		rb.GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		motorForce = Input.GetAxis ("Vertical") * speed;
		rb.AddForce (0, 0, -motorForce);

		float rotation = Input.GetAxis ("Horizontal") * maxSteerAngle;

		frontLeftWheel.localEulerAngles = new Vector3 (0, rotation, 0);
		frontRightWheel.localEulerAngles = new Vector3 (0, rotation + 180, 0);
	}
}