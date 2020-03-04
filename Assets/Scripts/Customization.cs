using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour {

	public Transform frontTransform;
	public Transform backTransform;
	public Transform leftTransform;
	public Transform rightTransform;
	public Transform topTransform;

	public Transform frontIRTransform;
	public Transform backIRTransform;
	public Transform leftIRTransform;
	public Transform rightIRTransform;
	private Button botonplus_largo,botonminus_largo,botonplus_ancho,botonminus_ancho,botonplus_alto,botonminus_alto;

	//Botones de personalización chasis y ruedas
	// void OnEnable(){ 
	// 	if (gameObject.transform.parent.name != "Robot(Clone)"){
	// 		botonplus_largo = GameObject.Find("ButtonLength+").GetComponent<Button>();
	// 		botonplus_largo.onClick.AddListener(AumentarLargo);

	// 		botonminus_largo = GameObject.Find("ButtonLength-").GetComponent<Button>();
	// 		botonminus_largo.onClick.AddListener(DisminuirLargo);


	// 		botonplus_ancho = GameObject.Find("ButtonWidth+").GetComponent<Button>();
	// 		botonplus_ancho.onClick.AddListener(AumentarAncho);

	// 		botonminus_ancho = GameObject.Find("ButtonWidth-").GetComponent<Button>();
	// 		botonminus_ancho.onClick.AddListener(DisminuirAncho);


	// 		botonplus_alto = GameObject.Find("ButtonHeight+").GetComponent<Button>();
	// 		botonplus_alto.onClick.AddListener(AumentarAlto);

	// 		botonminus_alto = GameObject.Find("ButtonHeight-").GetComponent<Button>();
	// 		botonminus_alto.onClick.AddListener(DisminuirAlto);
	// 	}
	// }
	public void AumentarLargo() {

		if (transform.localScale.z < 3) {
			transform.localScale += new Vector3(0, 0, 0.1F);
			frontTransform.Translate (-0.0125F, 0, 0);
			backTransform.Translate (-0.0125F, 0, 0);
			frontIRTransform.Translate (0, 0, -0.0125F);
			backIRTransform.Translate (0, 0, -0.0125F);
		}
	}

	public void DisminuirLargo() {
		if (transform.localScale.z >= 1.5) {
			transform.localScale -= new Vector3 (0, 0, 0.1F);
			frontTransform.Translate (0.0125F, 0, 0);
			backTransform.Translate (0.0125F, 0, 0);
			frontIRTransform.Translate (0, 0, 0.0125F);
			backIRTransform.Translate (0, 0, 0.0125F);
		}
	}

	public void AumentarAncho() {
		if (transform.localScale.x < 2) {
			transform.localScale += new Vector3(0.1F, 0, 0);
			leftTransform.Translate (-0.0125F, 0, 0);
			rightTransform.Translate (-0.0125F, 0, 0);
			leftIRTransform.Translate (0, 0, -0.0125F);
			rightIRTransform.Translate (0, 0, -0.0125F);
		}
	}
	
	public void DisminuirAncho() {
		if (transform.localScale.x >= 0.7) {
			transform.localScale -= new Vector3 (0.1F, 0, 0);
			leftTransform.Translate (0.0125F, 0, 0);
			rightTransform.Translate (0.0125F, 0, 0);
			leftIRTransform.Translate (0, 0, 0.0125F);
			rightIRTransform.Translate (0, 0, 0.0125F);
		}
	}

	/* Aumentar y disminuir el alto en la base cuadrada ya que su x, y & z */
	public void AumentarAlto() {
		if (transform.localScale.y < 1.6) {
			transform.localScale += new Vector3 (0, 0.1F, 0);
			transform.Translate (0, 0.0125F, 0);

			topTransform.Translate (0, 0.025F, 0);
		}
	}

	public void DisminuirAlto() {

		if (transform.localScale.y >= 0.9) {
			transform.localScale -= new Vector3 (0, 0.1F, 0);
			transform.Translate (0, -0.0125F, 0);

			topTransform.Translate (0, -0.025F, 0);
		} else {
			print ("No se puede reducir la altura más");
		}
	}

	/* Aumenta y disminuye el alto en la base circular ya que su x, y & z tienen el valor 1 */
	public void AumentarAltoCircular() {
		transform.localScale += new Vector3(0, 0.05F, 0);
		transform.Translate(0, 0.0125F, 0);
	}

	public void DisminuirAltoCircular() {
		transform.localScale -= new Vector3(0, 0.05F, 0);
		transform.Translate(0, -0.0125F, 0);
	}



	public void AumentarRadio(){
		transform.localScale += new Vector3 (0.1F, 0, 0.1F);
	}

	public void DisminuirRadio(){

		if (transform.localScale.z >= 1.1) {
			transform.localScale -= new Vector3 (0.1F, 0, 0.1F);
		} else {
			print ("No se puede reducir el radio más");
		}
	}
}
