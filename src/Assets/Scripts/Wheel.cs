
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wheel : MonoBehaviour {

	public GameObject baseRobot;

	private float largoBase;
	private float anchoBase;

	public GameObject wheel;

	private bool odometro;
	private double diametro;
	private double perimetro;
	private int rotaciones;

	private Button botonplus,botonminus;

	// private HingeJoint joint;
	//Personalización de las ruedas
	// void OnEnable(){ 
	// 	if (gameObject.transform.parent.parent.name != "Robot(Clone)"){
	// 		botonplus = GameObject.Find("ButtonSize+").GetComponent<Button>();
	// 		botonplus.onClick.AddListener(AumentarTam);

	// 		botonminus = GameObject.Find("ButtonSize-").GetComponent<Button>();
	// 		botonminus.onClick.AddListener(DisminuirTam);

	// 		// joint = gameObject.GetComponent<HingeJoint>();
	// 	}
	// }

	void Start() {
		baseRobot = GameObject.Find ("Robot/BaseSq");
		GameObject go = GameObject.Find ("Robot");

		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;
	}

	// Funciones para aumentar o disminuir el tamaño de las ruedas

	public void AumentarTam() {
		if (transform.localScale.y < 1.15)
			transform.localScale += new Vector3(0, 0.05F, 0.05F);
	}
		
	public void DisminuirTam(){

		if (transform.localScale.y > 0.70)
			transform.localScale -= new Vector3(0, 0.05F, 0.05F);
	}


	// Activa el odometro de las ruedas o no

	public void activarOdometro (){
		odometro = true;
	}

	public void desactivarOdometro (){
		odometro = false;
	}


	// Update 
	void Update (){

		if (this.tag == "WheelCenter") {
			if (largoBase < baseRobot.transform.localScale.z){
				transform.Translate (0, 0, -0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,-0.0125F);
			}
			else if (largoBase > baseRobot.transform.localScale.z){
				transform.Translate (0, 0, 0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,0.0125F);
			}
			
		} else if (this.tag == "WheelL") {
			// LARGO
			if (largoBase < baseRobot.transform.localScale.z){
				transform.Translate (0, 0, 0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,0.0125F);
			}
			else if (largoBase > baseRobot.transform.localScale.z){
				transform.Translate (0, 0, -0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,-0.0125F);
			}

			// ANCHO
			if (anchoBase < baseRobot.transform.localScale.x){
				transform.Translate(0.0125F, 0, 0);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0.0125F,0,0);
			}
			else if (anchoBase > baseRobot.transform.localScale.x){
				transform.Translate(-0.0125F, 0, 0);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(-0.0125F,0,0);
			}

		} else if (this.tag == "WheelR") {
			// LARGO
			if (largoBase < baseRobot.transform.localScale.z){
				transform.Translate (0, 0, -0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,-0.0125F);
			}
			else if (largoBase > baseRobot.transform.localScale.z){
				transform.Translate (0, 0, 0.0125F);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0,0,0.0125F);
			}

			// ANCHO
			if (anchoBase < baseRobot.transform.localScale.x){
				transform.Translate(0.0125F, 0, 0);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(0.0125F,0,0);
			}
			else if (anchoBase > baseRobot.transform.localScale.x){
				transform.Translate(-0.0125F, 0, 0);
				// joint.connectedAnchor = joint.connectedAnchor + new Vector3(-0.0125F,0,0);
			}
		}



		largoBase = baseRobot.transform.localScale.z;
		anchoBase = baseRobot.transform.localScale.x;

	
		diametro = transform.localScale.y;
		perimetro = diametro * Mathf.PI;
	}
}
