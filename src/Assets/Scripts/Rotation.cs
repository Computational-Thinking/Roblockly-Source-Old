﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Available on CreationSq scene

public class Rotation : MonoBehaviour {
	public Material r_color;
	Renderer robot_cl;
    public Camera main;
    float rotationValue = 2F;
    Transform robot_tr;	
	Rigidbody robot_rb, wheel_r, wheel_l, wheel_c,robot_cp;
    public bool rotationAllowed = true;
    private bool rotateLeft = false, rotateRight = false;
    private Button rightButton, leftButton;
	void Start(){
		
		if (gameObject.name == "Robot_Esquema"){
			robot_tr = gameObject.GetComponent<Transform>();
			robot_tr.localScale = robot_tr.localScale * 6;
			robot_tr.localPosition = new Vector3(10005.5f,10001,10054);
			robot_tr.localEulerAngles = new Vector3(0,180,0);

			robot_cp = gameObject.GetComponent<Rigidbody>();
            gameObject.GetComponent<Swipe>().enabled = false;

            robot_cp.constraints = RigidbodyConstraints.None;
            leftButton = GameObject.FindGameObjectWithTag("LeftRotationButton").GetComponent<Button>();
            rightButton = GameObject.FindGameObjectWithTag("RightRotationButton").GetComponent<Button>();
            AddRightButtonEvents();
            AddLeftButtonEvents();




            //conectar los botones

        }
	}
    void OnEnable(){
		
		if (gameObject.name == "Robot"){

			//Activando sensor_id del robot de creationSQ 
			GameObject sensor_id;
			for (int i = 2; i < 7; i++){
				for (int j = 2; j < gameObject.transform.GetChild(i).childCount; j++){
					sensor_id = gameObject.transform.GetChild(i).GetChild(j).GetChild(0).gameObject;
					sensor_id.SetActive(true);	
				}
			}
			//Activando sensor_id del robot de creationSQ 
			robot_cl = GameObject.Find("Permanente/Robot/BaseSq").GetComponent<Renderer>();
			robot_cl.sharedMaterial = r_color;

			robot_tr = gameObject.GetComponent<Transform>();
			robot_tr.localScale = robot_tr.localScale / 12;
			robot_tr.localPosition = new Vector3(-122.0045f,-2.693936f,58.66426f);
			robot_tr.localEulerAngles = new Vector3(0,180,0);

			robot_rb = gameObject.GetComponent<Rigidbody>();
			robot_rb.isKinematic = true; 
			robot_rb.useGravity = false;
			//Quitar restricciones de FreezePosition y Rotation
			robot_rb.constraints = RigidbodyConstraints.None; 


			//Ruedas

			wheel_r = GameObject.FindGameObjectWithTag("WheelR").GetComponent<Rigidbody>();
			wheel_l = GameObject.FindGameObjectWithTag("WheelL").GetComponent<Rigidbody>();
			wheel_c = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<Rigidbody>();
			//Comentar para probar ajuste de ruedas
			wheel_r.isKinematic = true;
			wheel_l.isKinematic = true;
			wheel_c.isKinematic = true;
			//Comentar para probar ajuste de ruedas

			main = GameObject.Find("Robot Camera").GetComponent<Camera>();
			main.rect = new Rect(0,0,1,1);
			main.depth = 1;
		}
	}
    void AddRightButtonEvents()
    {
        EventTrigger eventTrigger = rightButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { OnRightButtonDown((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { OnRightButtonUp((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerUpEntry);
    }

    public void OnRightButtonDown(PointerEventData data)
    {
        rotateRight = true;
        rotateLeft = false;
    }

    public void OnRightButtonUp(PointerEventData data)
    {
        rotateRight = false;
        rotateLeft = false;

    }

    void AddLeftButtonEvents()
    {
        EventTrigger eventTrigger = leftButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { OnLeftButtonDown((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { OnLeftButtonUp((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerUpEntry);
    }

    public void OnLeftButtonDown(PointerEventData data)
    {
        rotateRight = false;
        rotateLeft = true;

        
    }

    public void OnLeftButtonUp(PointerEventData data)
    {
        rotateRight = false;
        rotateLeft = false;

    }

    void Update() {
        //Fixed
        
		if (main == null){
			main = GameObject.Find("Robot Camera").GetComponent<Camera>();
		}
        if (rotationAllowed) {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, rotationValue, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, -rotationValue, 0, Space.World);
            }
        }
        if (gameObject.name == "Robot_Esquema")
        {
            if (rotateRight)
                transform.Rotate(0, -rotationValue, 0, Space.World);
            if (rotateLeft)
                transform.Rotate(0, rotationValue, 0, Space.World);
        }
            /*
            if (main.enabled && Input.GetKey (KeyCode.LeftArrow)) {
                transform.Rotate (0, rotationValue, 0, Space.World);
            }

            if (main.enabled && Input.GetKey (KeyCode.RightArrow)) {
                transform.Rotate (0, -rotationValue, 0, Space.World);
            }
            */

        }

	public void subirRobot(){
		transform.Translate (0, 0.05F, 0);
	}

	public void bajarRobot(){
		transform.Translate (0, -0.05F, 0);
	}
}