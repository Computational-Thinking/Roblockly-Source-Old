using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Window_button : MonoBehaviour{
    private GameObject canvas;
    //private GameObject ublocklyCanvas;
    //private GameObject ublocklyCam;

    // Start is called before the first frame update
    void Start(){
        canvas = GameObject.FindWithTag("ButtonMaxMin");
      //  ublocklyCanvas = GameObject.FindWithTag("UBlocklyCanvas");
      //  ublocklyCam = GameObject.FindWithTag("UBlocklyCam");

    }

    // Update is called once per frame

    void Update(){//Activa y desactiva el canvas de cambiar tamaño de ventana
     
        if (SceneManager.GetActiveScene().name == "Simulator - IR" || SceneManager.GetActiveScene().name == "Simulator - Touch" || SceneManager.GetActiveScene().name == "Simulator - US"){
        //    ublocklyCanvas.SetActive(true);
        //    ublocklyCam.SetActive(true);
            canvas.SetActive(true);
            

        }
    
        if (SceneManager.GetActiveScene().name == "CreationSq"){
            canvas.SetActive(false);
          //  ublocklyCanvas.SetActive(false);
          //  ublocklyCam.SetActive(false);
        }
    }
}
