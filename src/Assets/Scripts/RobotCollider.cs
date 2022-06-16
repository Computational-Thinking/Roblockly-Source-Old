using UnityEngine;
// Available on Simulator scene
public class RobotCollider : MonoBehaviour {
	public Camera main;
	// public TMP_Text t;
	Transform robot_tr;
	Rigidbody robot_rb, wheel_r, wheel_l, wheel_c;
	Rigidbody ruedas;

	void Start(){
		main = GameObject.Find("Robot Camera").GetComponent<Camera>();
		main.rect = new Rect(0.65f,-0.45f,1,0.8f);
		Debug.Log("Start");

	}
	void OnEnable(){
		Debug.Log("OnEnable");

		robot_tr = gameObject.GetComponent<Transform>();
		robot_tr.localScale = robot_tr.localScale * 12;   
    	robot_tr.position = new Vector3(131.4f,8.5f,-76.1f);
      	robot_tr.eulerAngles = new Vector3(0,0,0);

		robot_rb = gameObject.GetComponent<Rigidbody>();
		robot_rb.isKinematic = false;
		robot_rb.useGravity = true;
		robot_rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; 
		
		//Ruedas

		wheel_r = GameObject.FindGameObjectWithTag("WheelR").GetComponent<Rigidbody>();
		wheel_l = GameObject.FindGameObjectWithTag("WheelL").GetComponent<Rigidbody>();
		wheel_c = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<Rigidbody>();
	
		wheel_r.isKinematic = false;
		wheel_l.isKinematic = false;
		wheel_c.isKinematic = false;
	
		if (main != null){
			main.rect = new Rect(0.65f,-0.45f,1,0.8f);
		}

		//Quitando sensor_id del robot del entorno 
		GameObject sensor_id;
		for (int i = 2; i < 7; i++){
			for (int j = 2; j < gameObject.transform.GetChild(i).childCount; j++){
				sensor_id = gameObject.transform.GetChild(i).GetChild(j).GetChild(0).gameObject;
				sensor_id.SetActive(false);	
			}
		}
		//Quitando sensor_id del robot del entorno 
		
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.gameObject.CompareTag("CoinYellow")){
			transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.yellow;
			Transform tr = transform.GetChild (1);
			for (int i = 0; i < tr.childCount; i++) {
				tr.GetChild (i).GetChild (1).GetComponent<Renderer> ().material.color = Color.yellow;
			}
			collider.gameObject.SetActive (false);
		// 	t.gameObject.SetActive(true);
		// 	t.color = Color.yellow;
		// 	t.outlineWidth = 0.2f;

		// 	t.gameObject.SetActive (true);
		// 	t.gameObject.SetActive (false);
		}

		if(collider.gameObject.CompareTag("CoinBlue")){
			transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.cyan;
			collider.gameObject.SetActive (false);
			// t.gameObject.SetActive(true);
			// t.color = Color.cyan;
			// t.outlineWidth = 0.2f;

			// t.gameObject.SetActive (true);
			// t.gameObject.SetActive (false);
		}
	}
}
