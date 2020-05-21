using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RobotScriptsController : MonoBehaviour //Activa y desactiva los scripts asociados a Robot
{
    Rotation rotationCS,rotationCSsq;
    Swipe swipeCS,swipeCSsq;
    RobotCollider rcolliderCS,rcolliderCSsq;
    RobotScriptsController rscriptCTLRsq;
    Wheel wheel_r,wheel_l,wheel_c;

    Camera camara;
    // Start is called before the first frame update
    void Start(){
        wheel_r = GameObject.Find("Permanente/Robot/ThreeWheels/Wheel Right").GetComponent<Wheel>();
        wheel_l = GameObject.Find("Permanente/Robot/ThreeWheels/Wheel Left").GetComponent<Wheel>();
        wheel_c = GameObject.Find("Permanente/Robot/ThreeWheels/WheelCenter").GetComponent<Wheel>();
        rotationCS = gameObject.GetComponent<Rotation>();
        swipeCS = gameObject.GetComponent<Swipe>();
        rcolliderCS = gameObject.GetComponent<RobotCollider>();
        camara = GameObject.Find("/Permanente/Robot/BaseSq/Robot Camera").GetComponent<Camera>();      
        Debug.Log(camara);
    }

    // Update is called once per frame
    void Update(){
        if (SceneManager.GetActiveScene().name == "Simulator - IR" || SceneManager.GetActiveScene().name == "Simulator - Touch"){
            if (GameObject.Find("Robot_Esquema") == null){
                var temp = Instantiate(gameObject);
                temp.name  = "Robot_Esquema";
                rscriptCTLRsq = temp.GetComponent<RobotScriptsController>();
                rotationCSsq = temp.GetComponent<Rotation>();
                swipeCSsq = temp.GetComponent<Swipe>();
                rcolliderCSsq = temp.GetComponent<RobotCollider>();

                rscriptCTLRsq.enabled = false;
                rotationCSsq.enabled = true;
                swipeCSsq.enabled = true;
                rcolliderCSsq.enabled = false;
            }
            rotationCS.enabled = false;
            swipeCS.enabled = false;

            rcolliderCS.enabled = true;
            wheel_r.enabled = false;
            wheel_l.enabled = false;
            wheel_c.enabled = false;
            // custom.enabled = false;
            // robot_tr.Translate(127.4f,5.8f,-76.1f);
            // robot_rb.isKinematic = false;
            camara.gameObject.SetActive(true);                    
        }  
        if (SceneManager.GetActiveScene().name == "CreationSq"){
            rotationCS.enabled = true;
            
            swipeCS.enabled = true;
            rcolliderCS.enabled = false;
            wheel_r.enabled = true;
            wheel_l.enabled = true;
            wheel_c.enabled = true;
            // custom.enabled = true;
            // robot_tr.Translate(-122.0045f,-2.693936f,58.66426f);
            // robot_rb.isKinematic = true;
            camara.gameObject.SetActive(false);                    
        }
    }
}
