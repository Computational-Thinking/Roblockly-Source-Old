using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisableButton : MonoBehaviour
{
    public GameObject grid;
  
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (grid.GetComponent<GridManager>().full())
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
