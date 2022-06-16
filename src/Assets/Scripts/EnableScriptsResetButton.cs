using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableScriptsResetButton : MonoBehaviour
{
    public ResetTransform rtrscript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Simulator - IR" || SceneManager.GetActiveScene().name == "Simulator - Touch" || SceneManager.GetActiveScene().name == "Simulator - US"){
            rtrscript.enabled = true;
        }
        if (SceneManager.GetActiveScene().name == "CreationSq"){
            rtrscript.enabled = false;
        }
    }
}
