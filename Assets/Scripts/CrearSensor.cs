using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrearSensor : MonoBehaviour {


	private LaserSensorScript laser;
	private USSensorScript us;
	private IRSensorScript ir;
	private TouchSensorScript touch;
	// private TouchSensorScript touch;
	private LidarScript lidar;

	public OptionsSensorFront options;

	public GameObject menuAdd;
	public GameObject menuConfigLaser;
	public GameObject menuConfigIR;
	public GameObject menuConfigUS;
	public GameObject menuConfigTouch;
	public GameObject menuConfigLidar;

	public GameObject laserPrefab;
	public GameObject usPrefab;
	public GameObject irPrefab;
	public GameObject touchPrefab;
	public GameObject lidarPrefab;


	// Parte del top
	public Transform placeTop;
	public Transform parentTop;

	// Parte frontal
	public Transform parentFront;
	public Transform placeFront;
	public Transform placeFrontIR;


	// Parte trasera
	public Transform parentBack;
	public Transform placeBack;
	public Transform placeBackIR;


	// Parte izquierda
	public Transform parentLeft;
	public Transform placeLeft;
	public Transform placeLeftIR;



	// Parte derecha
	public Transform parentRight;
	public Transform placeRight;
	public Transform placeRightIR;



	public Slider rangeLaser;
	public Slider precisionLaser;

	private TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		placeTop = GameObject.Find("Permanente/Robot/TopSide/TopTransform").GetComponent<Transform>();
		parentTop = GameObject.Find("Permanente/Robot/TopSide").GetComponent<Transform>();
		
		parentFront = GameObject.Find("Permanente/Robot/FrontSide").GetComponent<Transform>();
		placeFront = GameObject.Find("Permanente/Robot/FrontSide/FrontTransform").GetComponent<Transform>();
		placeFrontIR = GameObject.Find("Permanente/Robot/FrontSide/FrontTransformIR").GetComponent<Transform>();
		
		parentBack = GameObject.Find("Permanente/Robot/BackSide").GetComponent<Transform>();
		placeBack = GameObject.Find("Permanente/Robot/BackSide/BackTransform").GetComponent<Transform>();
		placeBackIR = GameObject.Find("Permanente/Robot/BackSide/BackTransformIR").GetComponent<Transform>();
		
		parentLeft = GameObject.Find("Permanente/Robot/LeftSide").GetComponent<Transform>();
		placeLeft = GameObject.Find("Permanente/Robot/LeftSide/LeftTransform").GetComponent<Transform>();
		placeLeftIR = GameObject.Find("Permanente/Robot/LeftSide/LeftTransformIR").GetComponent<Transform>();
		
		parentRight = GameObject.Find("Permanente/Robot/RightSide").GetComponent<Transform>();
		placeRight = GameObject.Find("Permanente/Robot/RightSide/RightTransform").GetComponent<Transform>();
		placeRightIR = GameObject.Find("Permanente/Robot/RightSide/RightTransformIR").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {}


	public void crearLaserFront() {
		GameObject laserGO = (GameObject)Instantiate (laserPrefab, placeFront.position, placeFront.rotation, parentFront);
		options.setGo (laserGO);

		print ("GO: " + laserGO);

		laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));

		print ("Script: " + laser);
		options.setLaserScript (laser);


		menuAdd.SetActive (false);
		menuConfigLaser.SetActive (true);
		// laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
	}


	public void crearLaserBack() {
		GameObject laserGO = (GameObject)Instantiate (laserPrefab, placeBack.position, placeBack.rotation, parentBack);
		options.setGo (laserGO);

		laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
		options.setLaserScript (laser);


		menuAdd.SetActive (false);
		menuConfigLaser.SetActive (true);
		// laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
	}


	public void crearLaserLeft() {
		GameObject laserGO = (GameObject)Instantiate (laserPrefab, placeLeft.position, placeLeft.rotation, parentLeft);
		options.setGo (laserGO);

		laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
		options.setLaserScript (laser);


		menuAdd.SetActive (false);
		menuConfigLaser.SetActive (true);
		// laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
	}



	public void crearLaserRight() {
		GameObject laserGO = (GameObject)Instantiate (laserPrefab, placeRight.position, placeRight.rotation, parentRight);
		options.setGo (laserGO);

		laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
		options.setLaserScript (laser);


		menuAdd.SetActive (false);
		menuConfigLaser.SetActive (true);
		// laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
	}


	/****************************************************************************************
	 * SENSOR IR
	 ***************************************************************************************/

	public void crearIRFront() {
		options.enabled = true;

		GameObject irGO = (GameObject)Instantiate (irPrefab, placeFrontIR.position, placeFrontIR.rotation, parentFront);
		options.setGo (irGO);

		ir = (IRSensorScript) irGO.GetComponent (typeof(IRSensorScript));
		options.setIRScript (ir);

		text = GameObject.Find(ir.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);

		menuAdd.SetActive (false);
		menuConfigIR.SetActive (true);
		// laser = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));
	}


	public void crearIRBack() {
		GameObject irGO = (GameObject)Instantiate (irPrefab, placeBackIR.position, placeBackIR.rotation, parentBack);
		options.setGo (irGO);

		ir = (IRSensorScript) irGO.GetComponent (typeof(IRSensorScript));
		options.setIRScript (ir);

		text = GameObject.Find(ir.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigIR.SetActive (true);
	}


	public void crearIRLeft() {
		GameObject irGO = (GameObject)Instantiate (irPrefab, placeLeftIR.position, placeLeftIR.rotation, parentLeft);
		options.setGo (irGO);

		ir = (IRSensorScript) irGO.GetComponent (typeof(IRSensorScript));
		options.setIRScript (ir);

		text = GameObject.Find(ir.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigIR.SetActive (true);
	}



	public void crearIRRight() {
		GameObject irGO = (GameObject)Instantiate (irPrefab, placeRightIR.position, placeRightIR.rotation, parentRight);
		options.setGo (irGO);

		ir = (IRSensorScript) irGO.GetComponent (typeof(IRSensorScript));
		options.setIRScript (ir);

		text = GameObject.Find(ir.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigIR.SetActive (true);
	}


	/****************************************************************************************
	 * SENSOR US
	 ***************************************************************************************/

	public void crearUSFront() {
		GameObject usGO = (GameObject)Instantiate (usPrefab, placeFront.position, placeFront.rotation, parentFront);
		options.setGo (usGO);

		us = (USSensorScript) usGO.GetComponent (typeof(USSensorScript));
		options.setUSScript (us);

		text = GameObject.Find(us.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigUS.SetActive (true);
	}


	public void crearUSBack() {
		GameObject usGO = (GameObject)Instantiate (usPrefab, placeBack.position, placeBack.rotation, parentBack);
		options.setGo (usGO);

		us = (USSensorScript) usGO.GetComponent (typeof(USSensorScript));
		options.setUSScript (us);

		text = GameObject.Find(us.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigUS.SetActive (true);
	}


	public void crearUSLeft() {
		GameObject usGO = (GameObject)Instantiate (usPrefab, placeLeft.position, placeLeft.rotation, parentLeft);
		options.setGo (usGO);

		us = (USSensorScript) usGO.GetComponent (typeof(USSensorScript));
		options.setUSScript (us);

		text = GameObject.Find(us.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigUS.SetActive (true);
	}


	public void crearUSRight() {
		GameObject usGO = (GameObject)Instantiate (usPrefab, placeRight.position, placeRight.rotation, parentRight);
		options.setGo (usGO);

		us = (USSensorScript) usGO.GetComponent (typeof(USSensorScript));
		options.setUSScript (us);

		text = GameObject.Find(us.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);


		menuAdd.SetActive (false);
		menuConfigUS.SetActive (true);
	}



	/****************************************************************************************
	 * SENSOR CONTACTO
	 ***************************************************************************************/

	public void crearTouchFront() {
		GameObject touchGO = (GameObject)Instantiate (touchPrefab, placeFront.position, placeFront.rotation, parentFront);
		options.setGo (touchGO);
		
		touch = (TouchSensorScript) touchGO.GetComponent (typeof(TouchSensorScript));
		options.setUSScript (us);
		
		text = GameObject.Find(touch.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);

		menuAdd.SetActive (false);
		menuConfigTouch.SetActive (true);

	}


	public void crearTouchBack() {
		GameObject touchGO = (GameObject)Instantiate (touchPrefab, placeBack.position, placeBack.rotation, parentBack);
		options.setGo (touchGO);
		
		touch = (TouchSensorScript) touchGO.GetComponent (typeof(TouchSensorScript));
		options.setUSScript (us);
		
		text = GameObject.Find(touch.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
		text.color = new Color(0,100,0,255);

		menuAdd.SetActive (false);
		menuConfigTouch.SetActive (true);
	}


	/****************************************************************************************
	 * SENSOR LIDAR
	 ***************************************************************************************/

	public void crearLidarTop() {
		GameObject lidarGO = (GameObject)Instantiate (lidarPrefab, placeTop.position, placeTop.rotation, parentTop);
		options.setGo (lidarGO);

		lidar = (LidarScript) lidarGO.GetComponent (typeof(LidarScript));
		options.setLidarScript (lidar);


		menuAdd.SetActive (false);
		menuConfigLidar.SetActive (true);
	}

}
