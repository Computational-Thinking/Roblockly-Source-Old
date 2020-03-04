using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject robot;

	public Camera frontCamera;
	public Camera mainCamera;
	public Camera backCamera;
	public Camera leftCamera;
	public Camera rightCamera;
	public Camera topCamera;

	void Start(){
		frontCamera.enabled = false;
		mainCamera.enabled = true;
		backCamera.enabled = false;
		leftCamera.enabled = false;
		rightCamera.enabled = false;
		topCamera.enabled = false;
		robot = GameObject.Find("Permanente/Robot");
	}

	public void BackSide(){

		robot.transform.eulerAngles = new Vector3(0, 180, 0);

		frontCamera.enabled = false;
		mainCamera.enabled = false;
		backCamera.enabled = true;
		leftCamera.enabled = false;
		rightCamera.enabled = false;
		topCamera.enabled = false;

	}

	public void FrontSide(){

		robot.transform.eulerAngles = new Vector3(0, 180, 0);

		frontCamera.enabled = true;
		mainCamera.enabled = false;
		backCamera.enabled = false;
		leftCamera.enabled = false;
		rightCamera.enabled = false;
		topCamera.enabled = false;

	}

	public void MainCamera(){
		frontCamera.enabled = false;
		mainCamera.enabled = true;
		backCamera.enabled = false;
		leftCamera.enabled = false;
		rightCamera.enabled = false;
		topCamera.enabled = false;

	}

	public void LeftCamera(){
		
		robot.transform.eulerAngles = new Vector3(0, 180, 0);

		frontCamera.enabled = false;
		mainCamera.enabled = false;
		backCamera.enabled = false;
		leftCamera.enabled = true;
		rightCamera.enabled = false;
		topCamera.enabled = false;

	}

	public void RightCamera(){

		robot.transform.eulerAngles = new Vector3(0, 180, 0);

		frontCamera.enabled = false;
		mainCamera.enabled = false;
		backCamera.enabled = false;
		leftCamera.enabled = false;
		rightCamera.enabled = true;
		topCamera.enabled = false;
	}

	public void TopCamera(){

		robot.transform.eulerAngles = new Vector3(0, 180, 0);

		frontCamera.enabled = false;
		mainCamera.enabled = false;
		backCamera.enabled = false;
		leftCamera.enabled = false;
		rightCamera.enabled = false;
		topCamera.enabled = true;
	}


	public Camera getCameraActive() {
		if (frontCamera.enabled)
			return frontCamera;
		else if (backCamera.enabled)
			return backCamera;
		else if (leftCamera.enabled)
			return leftCamera;
		else if (rightCamera.enabled)
			return rightCamera;
		else if (mainCamera.enabled)
			return mainCamera;
		else if (topCamera.enabled)
			return topCamera;
		else
			return null;
	}
}
