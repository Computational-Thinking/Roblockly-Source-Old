using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    //bool disabled = false;

    public string side;
    private GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        //disable();
    }
   /* public void disable()
    {
        disabled = true;
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().enabled = false;
            
        }
    }
    */
    /*public void enable()
    {
        disabled = false;
        //foreach (Transform child in transform)
        //{
        //    child.GetComponent<MeshRenderer>().enabled = true;

        //}
        
    }
*/
    public bool full()
    {
        bool f = true;
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<GridOccupancy>().occupied) { 
                f = false;
                break;
            }
        }
        return f;
    }
    public Vector3 nextFreePos()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<GridOccupancy>().occupied)
            {
                pos = child.transform.position;
                break;
            }
        }
        return pos;
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().enabled = !child.GetComponent<GridOccupancy>().occupied;
        }
    }
    
    public void updateButtons (){

        GameObject go = GameObject.Find("Customization");
        if (go != null)
        {
            if (side == "front")
            {
                buttons = go.GetComponent<ButtonFinder>().frontButtons;
            }
            if (side == "back")
            {
                buttons = go.GetComponent<ButtonFinder>().backButtons;
            }
            if (side == "left")
            {
                buttons = go.GetComponent<ButtonFinder>().leftButtons;
            }
            if (side == "right")
            {
                buttons = go.GetComponent<ButtonFinder>().rightButtons;
            }


            if (full())
            {
                Debug.Log("Lleno: desactivando botones");
                foreach (GameObject g in buttons)
                    g.GetComponent<Button>().interactable = false;
            }
            else
            {
                Debug.Log("no lleno: activando botones");
                foreach (GameObject g in buttons)
                    g.GetComponent<Button>().interactable = true;
            }

        }
        else {
            Debug.Log("Customization object not found");
        }
    }
}
