using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maximize_OnClick : MonoBehaviour
{
    public Camera cam_;
    // Start is called before the first frame update
    void Start(){
		cam_ = GameObject.Find("Robot Camera").GetComponent<Camera>();
    }

    public void MinOrMax(){
        Debug.Log("Entra a MinOrMax");
        if (cam_.rect == new Rect(0.65f,-0.45f,1,0.8f)){
            Debug.Log("Pequeño");
            cam_.rect = new Rect(0,0,1,1);  
        }
        else{
            Debug.Log("Grande");
            cam_.rect = new Rect(0.65f,-0.45f,1,0.8f);  
        }
    }
}
