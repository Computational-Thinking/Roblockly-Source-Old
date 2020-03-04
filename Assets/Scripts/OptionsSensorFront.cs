using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsSensorFront : MonoBehaviour {


	public CameraScript cameraScript;
	private Camera camera;
	private GameObject go;

	private LaserSensorScript laser;
	private IRSensorScript ir;
	private USSensorScript us;
	private LidarScript lidar;


	public GameObject menuAdd;
	public GameObject menuConfigLaser;
	public GameObject menuConfigIR;
	public GameObject menuConfigUS;
	public GameObject menuConfigTouch;
	public GameObject menuConfigLidar;
	public GameObject menuBase;

	// Sliders láser
	public Slider rangeLaser;
	public Slider precisionLaser;

	public Slider rangeIR;
	public Slider precisionIR;

	public Slider rangeUS;
	public Slider precisionUS;

	public Slider rangeLidar;
	public Slider precisionLidar;
	private TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		rangeLaser.minValue = 1f;
		rangeLaser.maxValue = 10f;
		precisionLaser.minValue = 0f;
		precisionLaser.maxValue = 1f;

		// La precisión funciona de otra forma, por lo que se guarda el valor de 0 a 100
		rangeIR.minValue = 0.1f;
		rangeIR.maxValue = 0.8f;
		precisionLaser.minValue = 0f;
		precisionIR.maxValue = 100f;


		rangeUS.minValue = 1.0f;
		rangeUS.maxValue = 2.5f;
		precisionUS.minValue = 0f;
		precisionUS.maxValue = 1f;


		rangeLidar.minValue = 1.0f;
		rangeLidar.maxValue = 10.0f;
		precisionLidar.minValue = 0.0f;
		precisionLidar.maxValue = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		camera = cameraScript.getCameraActive ();

		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				go = hit.transform.gameObject;

				GameObject parent = go.transform.parent.gameObject;

				print (go.name + " TAG: " + go.tag);

				// EN caso de que sea la onda US (Tiene un gameobject vacío debido para que se aumente el tamaño por un lado)
				if (parent.tag == "Onda") {
					parent = parent.transform.parent.gameObject;
					go = parent;
					parent = go.transform.parent.gameObject;
				} 


				if (go.tag == "Onda") {
					go = parent.transform.gameObject;
					parent = parent.transform.parent.gameObject;
				}


				if (parent.tag == "FrontSide")
					cameraScript.FrontSide ();
				else if (parent.tag == "BackSide")
					cameraScript.BackSide ();
				else if (parent.tag == "LeftSide")
					cameraScript.LeftCamera ();
				else if (parent.tag == "RightSide")
					cameraScript.RightCamera ();
				else if (parent.tag == "TopSide")
					cameraScript.TopCamera ();

				if (go.tag == "US" || go.tag == "Touch" || go.tag == "Laser" || go.tag == "IR" || go.tag == "Lidar"){
					text = GameObject.Find(go.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
					text.color = new Color(0,100,0,255);
				}
				// Debug.Log(go.name);

				if (go.tag == "Laser") {
					laser = (LaserSensorScript)go.GetComponent (typeof(LaserSensorScript));

					rangeLaser.value = laser.getDistanceSensor ();
					precisionLaser.value = laser.getError ();

					menuAdd.SetActive (false);
					menuConfigLaser.SetActive (true);
					menuConfigIR.SetActive (false);
					menuConfigUS.SetActive (false);
					menuConfigTouch.SetActive (false);
					menuConfigLidar.SetActive (false);
					//menuBase.SetActive (false);
				} else if (go.tag == "IR") {
					ir = (IRSensorScript)go.GetComponent (typeof(IRSensorScript));

					rangeIR.value = ir.getDistanceSensor ();
                    precisionIR.value = 100;

					menuAdd.SetActive (false);
					menuConfigLaser.SetActive (false);
					menuConfigIR.SetActive (true);
					menuConfigUS.SetActive (false);
					menuConfigTouch.SetActive (false);
					menuConfigLidar.SetActive (false);

					//menuBase.SetActive (false);
				} else if (go.tag == "US") {
					us = (USSensorScript)go.GetComponent (typeof(USSensorScript));

					rangeUS.value = us.getDistanceSensor ();
					precisionUS.value = us.getError ();

					menuAdd.SetActive (false);
					menuConfigLaser.SetActive (false);
					menuConfigIR.SetActive (false);
					menuConfigUS.SetActive (true);
					menuConfigTouch.SetActive (false);
					menuConfigLidar.SetActive (false);

					// menuBase.SetActive (false);
				} else if (go.tag == "Touch") {
					menuAdd.SetActive (false);
					menuConfigLaser.SetActive (false);
					menuConfigIR.SetActive (false);
					menuConfigUS.SetActive (false);
					menuConfigTouch.SetActive (true);
					menuConfigLidar.SetActive (false);
					// menuBase.SetActive (false);
				} else if (go.tag == "Lidar") {
					lidar = (LidarScript)go.GetComponent (typeof(LidarScript));

					rangeLidar.value = lidar.getDistanceSensor ();
					precisionLidar.value = lidar.getError ();

					menuAdd.SetActive (false);
					menuConfigLaser.SetActive (false);
					menuConfigIR.SetActive (false);
					menuConfigUS.SetActive (false);
					menuConfigTouch.SetActive (false);
					menuConfigLidar.SetActive (true);
					//menuBase.SetActive (false);
				}

			}
		}

		if (go != null) {
			if (go.tag == "IR") {
				if (Input.GetKey (KeyCode.W)) {
					go.transform.Translate (0, 0.005F, 0);// position += new Vector3(0, 0.005F, 0);
				}

				if (Input.GetKey (KeyCode.S)) {
					go.transform.Translate (0, -0.005F, 0); //transform.position += new Vector3(0, -0.005F, 0);
				}

				if (Input.GetKey (KeyCode.A)) {
					go.transform.Translate (-0.005F, 0, 0); //transform.position += new Vector3(-0.005F, 0, 0);
				}

				if (Input.GetKey (KeyCode.D)) {
					go.transform.Translate (0.005F, 0, 0); // transform.position += new Vector3(0.005F, 0, 0);
				}
			} else if (go.tag == "Lidar") {
				if (Input.GetKey (KeyCode.W)) {
					go.transform.Translate (0, 0, -0.005F);// position += new Vector3(0, 0.005F, 0);
				}

				if (Input.GetKey (KeyCode.S)) {
					go.transform.Translate (0, 0, 0.005F); //transform.position += new Vector3(0, -0.005F, 0);
				}

				if (Input.GetKey (KeyCode.A)) {
					go.transform.Translate (0.005F, 0, 0); //transform.position += new Vector3(-0.005F, 0, 0);
				}

				if (Input.GetKey (KeyCode.D)) {
					go.transform.Translate (-0.005F, 0, 0); // transform.position += new Vector3(0.005F, 0, 0);
				}
		
			} else if (go.tag == "US" || go.tag == "Touch" || go.tag == "Laser") {
				if (Input.GetKey (KeyCode.W)) {
					go.transform.Translate (0, 0.005F, 0);// position += new Vector3(0, 0.005F, 0);
				}

				if (Input.GetKey (KeyCode.S)) {
					go.transform.Translate (0, -0.005F, 0); //transform.position += new Vector3(0, -0.005F, 0);
				}

				if (Input.GetKey (KeyCode.A)) {
					go.transform.Translate (0, 0, 0.005F); //transform.position += new Vector3(-0.005F, 0, 0);
				}

				if (Input.GetKey (KeyCode.D)) {
					go.transform.Translate (0, 0, -0.005F); // transform.position += new Vector3(0.005F, 0, 0);
				}
			} 
		}
	}


	public void setSlidersLaserToGameObject(){
		if (go.tag == "Laser") {
			laser.setDistanceSensor (rangeLaser.value);
			laser.setError (precisionLaser.value);
		} else if (go.tag == "IR") {
			ir.setDistanceSensor (rangeIR.value);
			
		} else if (go.tag == "US") {
			us.setDistanceSensor (rangeUS.value);
			us.setError (precisionUS.value);

			// us.actualizarOnda ();
		} else if (go.tag == "Lidar") {
			lidar.setDistanceSensor (rangeLidar.value);
			lidar.setError (precisionLidar.value);

			// lidar.actualizarOnda ();
		}
		if (go.tag == "US" || go.tag == "Touch" || go.tag == "IR"){
			text = GameObject.Find(go.name + "/Canvas/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
			text.color = new Color(255,255,0,255);
		}
		go = null;
	}


	public void eliminarSensor(){
		Destroy (go);
	}


	/* public void ModificarOnda() {
		if (go.tag == "US")
			us.cambiarOnda ();
		else if (go.tag == "Lidar")
			lidar.cambiarOnda ();

	} */


	public void setGo(GameObject go) {
		this.go = go;
	}


	public GameObject getGo() {
		return this.go;
	}	


	public void setLaserScript (LaserSensorScript laser) {
		this.laser = laser;
	}

	public void setIRScript (IRSensorScript ir) {
		this.ir = ir;
	}

	public void setUSScript(USSensorScript us) {
		this.us = us;
	}

	public void setLidarScript (LidarScript lidar) {
		this.lidar = lidar;
	}
}

