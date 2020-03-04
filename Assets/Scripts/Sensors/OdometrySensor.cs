using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdometrySensor : MonoBehaviour {

	private double radio = 0.0F;
	private double distanciaGradual = 0.0F;

	private double distanciaRecorrida = 0.0F;
	private double anguloAnterior = 0.0F;

	// Use this for initialization
	void Start () {
		radio = transform.localScale.x / 2;
		distanciaGradual = (2 * Mathf.PI * radio) / 360;
		anguloAnterior = transform.eulerAngles.x;

		print ("Radio: " + radio + " Distancia gradual: " + distanciaGradual + "Angulo anterior: " + anguloAnterior);

	}
	
	// Update is called once per frame
	void Update () {

		// print ("Ángulo anterior: " + anguloAnterior);
		// print ("Ángulo actual: " + transform.eulerAngles.x);

		if (anguloAnterior <= transform.eulerAngles.x) {
			double diferencia = transform.eulerAngles.x - anguloAnterior;
			distanciaRecorrida += diferencia * distanciaGradual;
		} 

		else if (anguloAnterior < 100 && transform.eulerAngles.x > 250) {
			double dist = anguloAnterior + (360 - transform.eulerAngles.x);
			distanciaRecorrida += dist * distanciaGradual;
		}

		else if (anguloAnterior > 250 && transform.eulerAngles.x < 100) {
			double dist = transform.eulerAngles.x + (360 - anguloAnterior);
			distanciaRecorrida += dist * distanciaGradual;
		}

		else {
			double diferencia = anguloAnterior - transform.eulerAngles.x;
			distanciaRecorrida += diferencia * distanciaGradual;
		}

		anguloAnterior = transform.eulerAngles.x;

		print ("Distancia recorrida hasta el momento: " + distanciaRecorrida);
	}
}
