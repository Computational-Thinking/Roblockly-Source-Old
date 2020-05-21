using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOccupancy : MonoBehaviour
{
    public bool occupied = false;
    private Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //if (collision.gameObject.tag == "IR")
        //{

            //If the GameObject has the same tag as specified, output this message in the console
        //this.GetComponent<Renderer>().material.color = new Color(0.6f,0.6f,0.6f);
        //Debug.Log("Collision enter");
        occupied = true;
        col = collision;
        collision.gameObject.GetComponent<FreeGridOnDestroy>().grid = gameObject;
        //}
    }
    void OnTriggerExit(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //if (collision.gameObject.tag == "IR")
        //{

            //If the GameObject has the same tag as specified, output this message in the console
        //this.GetComponent<Renderer>().material.color = Color.white;
        //Debug.Log("Collision exit");
        occupied = false;
        //}
    }
    /*public bool isOccupied()
    {
        if (sensor == null)
        {
            Debug.Log(this.name + "  no collider");
            return false;
        }
        else
        {
            Debug.Log(sensor.name);
            return occupied;
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        if (col == null)
        {
            //this.GetComponent<Renderer>().material.color = Color.white;
            //Debug.Log("Collision exit");
            occupied = false;
        }
    }
}
