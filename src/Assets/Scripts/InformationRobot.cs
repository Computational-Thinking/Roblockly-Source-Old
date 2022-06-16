using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationRobot : MonoBehaviour {


	private bool posibleExportar = true;

	private GameObject baseRobot;
	private GameObject wheel;

	private bool circularRobot = false;

	// Information of the base
	private float length;
	private float width;
	private float height;

	private float radius;


	// Number of wheels
	private int numWheels;
	private double radiusWheel; // Se divide entre 16 por un tema de escala

	public GameObject menuError;
	public GameObject menu;


	// Use this for initialization
	void Start () {
		if (GameObject.Find ("/Permanente/Robot/BaseSq")) {
			baseRobot = GameObject.Find ("/Permanente/Robot/BaseSq");

			length = baseRobot.transform.localScale.z/4;
			width = baseRobot.transform.localScale.x/4;
			height = baseRobot.transform.localScale.y/4;

			numWheels = 3;

		} 

		// Wheels size
		if (GameObject.Find ("/Permanente/Robot/FourWheels/Wheel")) {
			print (true);
			wheel = GameObject.Find ("/Permanente/Robot/FourWheels/Wheel");

			radiusWheel = wheel.transform.localScale.z / 2;

		} else if (GameObject.Find ("/Permanente/Robot/ThreeWheels/WheelCenter")) {
			// Aprovechamos una variable para los dos tipos de rueda que hay
			wheel = GameObject.Find ("/Permanente/Robot/ThreeWheels/WheelCenter");
			radiusWheel = wheel.transform.localScale.z / 8d;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (circularRobot) {
			radius = baseRobot.transform.localScale.x / 2;
			height = baseRobot.transform.localScale.y;

			radiusWheel = wheel.transform.localScale.z / 16;
		
		} else {
			length = baseRobot.transform.localScale.z/4;
			width = baseRobot.transform.localScale.x/4;
			height = baseRobot.transform.localScale.y/4;

			radiusWheel = wheel.transform.localScale.z / 8f;

		}
	}
		


	/**
	 * Función para exportar la configuración 
	 */

	public void exportConfigurationRobot() {
	
		using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"config_robot.txt", false)) {

			if (circularRobot) {
				file.WriteLine ("Robot circular");
				file.WriteLine ("Radio del robot: " + radius);
				file.WriteLine ("Altura del robot: " + height);
			} else {
				file.WriteLine ("Robot rectangular");
				file.WriteLine ("Largo del robot: " + length);
				file.WriteLine ("Anchura del robot: " + width);
				file.WriteLine ("Altura del robot: " + height);
			}

			file.WriteLine ("");
			file.WriteLine ("Número de ruedas: " + numWheels);
			file.WriteLine ("Radio de cada rueda: " + radiusWheel);

			file.WriteLine ("");

		}
	}


	public void exportConfigurationRobotToXml(){

		comprobarSensores ();

		if (posibleExportar) {

			using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"config_robot.xml", false)) {

				file.WriteLine ("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
				file.WriteLine ("<ROBOT>");
				file.WriteLine ("\t<Base>");
				if (circularRobot) {
				
					file.WriteLine ("\t\t<Tipo>Circular</Tipo>");
					file.WriteLine ("\t\t<Radio>" + radius + "</Radio>");
					file.WriteLine ("\t\t<Altura>" + height + "</Altura>");
					// file.WriteLine ("Robot circular");
					// file.WriteLine ("Radio del robot: " + radius);
					// file.WriteLine ("Altura del robot: " + height);
				} else {
					file.WriteLine ("\t\t<Tipo>Rectangular</Tipo>");
					file.WriteLine ("\t\t<Largo>" + length + "</Largo>");
					file.WriteLine ("\t\t<Anchura>" + width + "</Anchura>");
					file.WriteLine ("\t\t<Altura>" + height + "</Altura>");

					/*file.WriteLine ("Robot rectangular");
				file.WriteLine ("Largo del robot: " + length);
				file.WriteLine ("Anchura del robot: " + width);
				file.WriteLine ("Altura del robot: " + height); */
				}

				file.WriteLine ("\t</Base>");


				file.WriteLine ("\t<Ruedas>");

				file.WriteLine ("\t\t<Número>" + numWheels + "</Número>");
				file.WriteLine ("\t\t<Radio>" + radiusWheel + "</Radio>");

				file.WriteLine ("\t</Ruedas>");


				file.WriteLine ("\t<Sensores>");


				ArrayList lasers = new ArrayList ();
				ArrayList uss = new ArrayList ();
				ArrayList irs = new ArrayList ();
				ArrayList touchs = new ArrayList ();
				ArrayList lidars = new ArrayList ();

				GameObject frontSide = GameObject.Find ("/Permanente/Robot/FrontSide");
				GameObject backSide = GameObject.Find ("/Permanente/Robot/BackSide");
				GameObject leftSide = GameObject.Find ("/Permanente/Robot/LeftSide");
				GameObject rightSide = GameObject.Find ("/Permanente/Robot/RightSide");
				GameObject topSide = GameObject.Find ("/Permanente/Robot/TopSide");


				/*********************************************************************************************
			 * Parte delantera
			 ********************************************************************************************/
				file.WriteLine ("\t\t<Parte Frontal>");

				foreach (Transform child in frontSide.transform) {
					if (child.tag == "Laser")
						lasers.Add (child.gameObject);
					else if (child.tag == "US")
						uss.Add (child.gameObject);
					else if (child.tag == "IR")
						irs.Add (child.gameObject);
					else if (child.tag == "Touch")
						touchs.Add (child.gameObject);
				}

				for (int i = 0; i < lasers.Count; i++) {
					GameObject laserGO = (GameObject)lasers [i];
					LaserSensorScript parametros = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));

					file.WriteLine ("\t\t\t<Laser unidireccional " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</Laser " + (i + 1) + ">");
				}

				for (int i = 0; i < uss.Count; i++) {
					GameObject usGO = (GameObject)uss [i];
					USSensorScript parametros = (USSensorScript)usGO.GetComponent (typeof(USSensorScript));

					file.WriteLine ("\t\t\t<US " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</US " + (i + 1) + ">");
				}

				for (int i = 0; i < irs.Count; i++) {
					GameObject irGO = (GameObject)irs [i];
					IRSensorScript parametros = (IRSensorScript)irGO.GetComponent (typeof(IRSensorScript));

					file.WriteLine ("\t\t\t<IR " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					//file.WriteLine ("\t\t\t\t<Precisión>" + parametros.getPecision () + "</Precisión>");
					file.WriteLine ("\t\t\t</IR " + (i + 1) + ">");
				}

				for (int i = 0; i < touchs.Count; i++)
					file.WriteLine ("\t\t\t<Touch " + (i + 1) + ">" + "</Touch " + (i + 1) + ">");


				file.WriteLine ("\t\t</Parte Frontal>");

				lasers.Clear ();
				uss.Clear ();
				irs.Clear ();
				touchs.Clear ();
				lidars.Clear ();

				/*********************************************************************************************
			 * Parte trasera
			 ********************************************************************************************/

				file.WriteLine ("\t\t<Parte Trasera>");

				foreach (Transform child in backSide.transform) {
					if (child.tag == "Laser")
						lasers.Add (child.gameObject);
					else if (child.tag == "US")
						uss.Add (child.gameObject);
					else if (child.tag == "IR")
						irs.Add (child.gameObject);
					else if (child.tag == "Touch")
						touchs.Add (child.gameObject);
				}

				for (int i = 0; i < lasers.Count; i++) {
					GameObject laserGO = (GameObject)lasers [i];
					LaserSensorScript parametros = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));

					file.WriteLine ("\t\t\t<Laser unidireccional " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</Laser " + (i + 1) + ">");
				}

				for (int i = 0; i < uss.Count; i++) {
					GameObject usGO = (GameObject)uss [i];
					USSensorScript parametros = (USSensorScript)usGO.GetComponent (typeof(USSensorScript));

					file.WriteLine ("\t\t\t<US " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</US " + (i + 1) + ">");
				}

				for (int i = 0; i < irs.Count; i++) {
					GameObject irGO = (GameObject)irs [i];
					IRSensorScript parametros = (IRSensorScript)irGO.GetComponent (typeof(IRSensorScript));

					file.WriteLine ("\t\t\t<IR " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					//file.WriteLine ("\t\t\t\t<Precisión>" + parametros.getPecision () + "</Precisión>");
					file.WriteLine ("\t\t\t</IR " + (i + 1) + ">");
				}

				for (int i = 0; i < touchs.Count; i++)
					file.WriteLine ("\t\t\t<Touch " + (i + 1) + ">" + "</Touch " + (i + 1) + ">");


				file.WriteLine ("\t\t</Parte Trasera>");

				lasers.Clear ();
				uss.Clear ();
				irs.Clear ();
				touchs.Clear ();
				lidars.Clear ();


				/*********************************************************************************************
			 * Parte izquierda
			 ********************************************************************************************/

				file.WriteLine ("\t\t<Parte Izquierda>");

				foreach (Transform child in leftSide.transform) {
					if (child.tag == "Laser")
						lasers.Add (child.gameObject);
					else if (child.tag == "US")
						uss.Add (child.gameObject);
					else if (child.tag == "IR")
						irs.Add (child.gameObject);
					else if (child.tag == "Touch")
						touchs.Add (child.gameObject);
				}

				for (int i = 0; i < lasers.Count; i++) {
					GameObject laserGO = (GameObject)lasers [i];
					LaserSensorScript parametros = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));

					file.WriteLine ("\t\t\t<Laser unidireccional " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</Laser " + (i + 1) + ">");
				}

				for (int i = 0; i < uss.Count; i++) {
					GameObject usGO = (GameObject)uss [i];
					USSensorScript parametros = (USSensorScript)usGO.GetComponent (typeof(USSensorScript));

					file.WriteLine ("\t\t\t<US " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</US " + (i + 1) + ">");
				}

				for (int i = 0; i < irs.Count; i++) {
					GameObject irGO = (GameObject)irs [i];
					IRSensorScript parametros = (IRSensorScript)irGO.GetComponent (typeof(IRSensorScript));

					file.WriteLine ("\t\t\t<IR " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					//file.WriteLine ("\t\t\t\t<Precisión>" + parametros.getPecision () + "</Precisión>");
					file.WriteLine ("\t\t\t</IR " + (i + 1) + ">");
				}


				file.WriteLine ("\t\t</Parte Izquierda>");

				lasers.Clear ();
				uss.Clear ();
				irs.Clear ();
				touchs.Clear ();
				lidars.Clear ();


				/*********************************************************************************************
			 * Parte derecha
			 ********************************************************************************************/

				file.WriteLine ("\t\t<Parte Derecha>");

				foreach (Transform child in rightSide.transform) {
					if (child.tag == "Laser")
						lasers.Add (child.gameObject);
					else if (child.tag == "US")
						uss.Add (child.gameObject);
					else if (child.tag == "IR")
						irs.Add (child.gameObject);
					else if (child.tag == "Touch")
						touchs.Add (child.gameObject);
				}

				for (int i = 0; i < lasers.Count; i++) {
					GameObject laserGO = (GameObject)lasers [i];
					LaserSensorScript parametros = (LaserSensorScript)laserGO.GetComponent (typeof(LaserSensorScript));

					file.WriteLine ("\t\t\t<Laser unidireccional " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</Laser " + (i + 1) + ">");
				}

				for (int i = 0; i < uss.Count; i++) {
					GameObject usGO = (GameObject)uss [i];
					USSensorScript parametros = (USSensorScript)usGO.GetComponent (typeof(USSensorScript));

					file.WriteLine ("\t\t\t<US " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</US " + (i + 1) + ">");
				}

				for (int i = 0; i < irs.Count; i++) {
					GameObject irGO = (GameObject)irs [i];
					IRSensorScript parametros = (IRSensorScript)irGO.GetComponent (typeof(IRSensorScript));

					file.WriteLine ("\t\t\t<IR " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					//file.WriteLine ("\t\t\t\t<Precisión>" + parametros.getPecision () + "</Precisión>");
					file.WriteLine ("\t\t\t</IR " + (i + 1) + ">");
				}


				file.WriteLine ("\t\t</Parte Derecha>");

				lasers.Clear ();
				uss.Clear ();
				irs.Clear ();
				touchs.Clear ();
				lidars.Clear ();


				/*********************************************************************************************
			 * Parte de arriba
			 ********************************************************************************************/

				file.WriteLine ("\t\t<Parte Superior>");

				foreach (Transform child in topSide.transform) {
					if (child.tag == "Lidar")
						lidars.Add (child.gameObject);
				}

				for (int i = 0; i < lidars.Count; i++) {
					GameObject lidarGO = (GameObject)lidars [i];
					LidarScript parametros = (LidarScript)lidarGO.GetComponent (typeof(LidarScript));

					file.WriteLine ("\t\t\t<Láser 2D " + (i + 1) + ">");
					file.WriteLine ("\t\t\t\t<Rango>" + parametros.getDistanceSensor () + "</Rango>");
					file.WriteLine ("\t\t\t\t<Error>" + parametros.getError () + "</Error>");
					file.WriteLine ("\t\t\t</Lidar " + (i + 1) + ">");
				}


				file.WriteLine ("\t\t</Parte Superior>");

				lasers.Clear ();
				uss.Clear ();
				irs.Clear ();
				touchs.Clear ();
				lidars.Clear ();


		
				// file.WriteLine("\t\t<Odometro>");
				// file.WriteLine ("\t\t\t<Activo>" + odometro + "</Activo>");
				// file.WriteLine("\t\t</Odometro>");

				file.WriteLine ("\t</Sensores>");
				file.WriteLine ("</Robot>");
			}
		} else {
			menuError.SetActive (true);
			menu.SetActive (false);
		}

		posibleExportar = true;
	}



	void comprobarSensores() {

		ArrayList lasers = new ArrayList ();
		ArrayList uss = new ArrayList ();
		ArrayList irs = new ArrayList ();
		ArrayList touchs = new ArrayList ();
		ArrayList lidars = new ArrayList ();

		GameObject frontSide = GameObject.Find ("/Permanente/Robot/FrontSide");
		GameObject backSide = GameObject.Find ("/Permanente/Robot/BackSide");
		GameObject leftSide = GameObject.Find ("/Permanente/Robot/LeftSide");
		GameObject rightSide = GameObject.Find ("/Permanente/Robot/RightSide");
		GameObject topSide = GameObject.Find ("/Permanente/Robot/TopSide");


		foreach (Transform child in frontSide.transform) {
			if (child.tag == "Laser")
				lasers.Add (child.gameObject);
			else if (child.tag == "US")
				uss.Add (child.gameObject);
			else if (child.tag == "IR")
				irs.Add (child.gameObject);
			else if (child.tag == "Touch")
				touchs.Add (child.gameObject);
		}

		foreach (Transform child in backSide.transform) {
			if (child.tag == "Laser")
				lasers.Add (child.gameObject);
			else if (child.tag == "US")
				uss.Add (child.gameObject);
			else if (child.tag == "IR")
				irs.Add (child.gameObject);
			else if (child.tag == "Touch")
				touchs.Add (child.gameObject);
		}

		foreach (Transform child in rightSide.transform) {
			if (child.tag == "Laser")
				lasers.Add (child.gameObject);
			else if (child.tag == "US")
				uss.Add (child.gameObject);
			else if (child.tag == "IR")
				irs.Add (child.gameObject);
		}

		foreach (Transform child in leftSide.transform) {
			if (child.tag == "Laser")
				lasers.Add (child.gameObject);
			else if (child.tag == "US")
				uss.Add (child.gameObject);
			else if (child.tag == "IR")
				irs.Add (child.gameObject);
		}

		foreach (Transform child in topSide.transform) {
			if (child.tag == "Lidar")
				lidars.Add (child.gameObject);
		}

		/**
		 * LASERS
		 */

		foreach (GameObject child in lasers) {
			LaserSensorScript info = (LaserSensorScript)child.GetComponent<LaserSensorScript> ();

			if (info.getPosicionReal () == false)
				posibleExportar = false;
		}


		/**
		 * US
		 */

		foreach (GameObject child in uss) {
			USSensorScript info = (USSensorScript)child.GetComponent<USSensorScript> ();

			if (info.getPosicionReal () == false)
				posibleExportar = false;
		}


		/**
		 * IRS
		 */

		foreach (GameObject child in irs) {
			IRSensorScript info = (IRSensorScript)child.GetComponent<IRSensorScript> ();

			if (info.getPosicionReal () == false)
				posibleExportar = false;
		}


		/**
		 * TOUCHS
		 */

		foreach (GameObject child in touchs) {
			TouchSensorScript info = (TouchSensorScript)child.GetComponent<TouchSensorScript> ();

			if (info.getPosicionReal () == false)
				posibleExportar = false;
		}


		/**
		 * LIDARS
		 */

		foreach (GameObject child in lidars) {
			LidarScript info = (LidarScript)child.GetComponent<LidarScript> ();

			if (info.getPosicionReal () == false)
				posibleExportar = false;
		}
	}
}