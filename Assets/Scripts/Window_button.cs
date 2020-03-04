using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Window_button : MonoBehaviour{
    private GameObject canvas;
    // Start is called before the first frame update
    void Start(){
        canvas = GameObject.FindWithTag("ButtonMaxMin");
    }

    // Update is called once per frame

    void Update(){//Activa y desactiva el canvas de cambiar tamaño de ventana
     
        if (SceneManager.GetActiveScene().name == "Simulator - IR" || SceneManager.GetActiveScene().name == "Simulator - Touch" || SceneManager.GetActiveScene().name == "Simulator - US"){
            canvas.SetActive(true);
        }
    
        if (SceneManager.GetActiveScene().name == "CreationSq"){
            canvas.SetActive(false);
        }
    }
}
