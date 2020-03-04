using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPermanente : MonoBehaviour
{
    static PruebaPermanente Element;
    void Start(){
        if (Element != null){
            GameObject.Destroy(gameObject);      
        }
        else{
            GameObject.DontDestroyOnLoad(gameObject);
            Element = this;
        }
    }
}


