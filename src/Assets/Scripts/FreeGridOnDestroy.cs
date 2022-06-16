using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGridOnDestroy : MonoBehaviour
{
    public GameObject grid;
    // Start is called before the first frame update

    public void freeGrid()
    {
        grid.GetComponent<GridOccupancy>().occupied = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
