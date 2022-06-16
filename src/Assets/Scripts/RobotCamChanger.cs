using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCamChanger : MonoBehaviour
{
    public GameObject[] pos;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        
    }
    public void ChangeCamPos()
    {
        index = (index + 1) % pos.Length;
        this.transform.position = pos[index].transform.position;
        this.transform.rotation = pos[index].transform.rotation;

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
