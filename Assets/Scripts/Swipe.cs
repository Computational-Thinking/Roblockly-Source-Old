using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool rotationAllowed = true;
    private Camera cam;

    private void Start()
    {
       
    }
    void Update()
    {
        if (this.transform.name == "Robot_Esquema")
            cam = GameObject.FindWithTag("UBlocklyCam").GetComponent<Camera>();
        else
            cam = Camera.main;
        if (Input.touchCount == 1 && rotationAllowed)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);
            Vector3 pos = cam.WorldToScreenPoint(this.transform.position);
            float dist = Vector2.Distance(new Vector2(pos.x, pos.y), touch0.position);
            if (dist < 200) { 
                // APPLY ROTATION
                if (touch0.phase == TouchPhase.Moved)
                {
                    this.transform.Rotate(0f, -touch0.deltaPosition.x * 0.5f, 0f);
                }
            }
                
        }
        
    }
}
