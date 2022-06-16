using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatorMenu : MonoBehaviour {


	public void StartSimulation () {
		SceneManager.LoadScene ("Simulator");
	}

	public void Quit() {
		SceneManager.LoadScene ("Prueba");
		//Application.Quit ();
	}
}