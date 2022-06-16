using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USSensorDistance : MonoBehaviour
{

    private Ray ray;
    private RaycastHit raycastHit;
    private float distanceHit;
    private bool detection = false;

    public USSensorScript us;

    // Use this for initialization
    void Start() { }

    // En caso de que un rayo detecta algo, se obliga a acabar los dos bucles, ya que sería hacer rayos para nada
    void Update()
    {
        detection = false;

        for (float i = transform.up.x - 0.15f; i < transform.up.x + 0.15f; i += 0.05f)
        {
            for (float k = transform.up.z - 0.15f; k < transform.up.z + 0.15f; k += 0.05f)
            {
                for (float j = -0.15f; j < 0.15f; j += 0.05f)
                {
                    if (!detection)
                    {
                        Vector3 v = new Vector3(i, j, k);
                        // print (v);
                        ray = new Ray(transform.position, v);
                        Debug.DrawRay(transform.position, v.normalized * us.getDistanceSensor(), Color.blue);

                        if (Physics.Raycast(ray, out raycastHit, us.getDistanceSensor()))
                        {
                            if (raycastHit.collider.gameObject.tag != "Suelo")
                            {
                                distanceHit = raycastHit.distance / us.getScaleFactor();
                                detection = true;
                            }
                        }
                        else
                        {
                            distanceHit = 0;
                            detection = false;
                        }
                    }
                }
            }
        }

        if (detection)
        {
            precisionEffect();
            Debug.Log("US devuelve objeto a " + distanceHit);

        }
    }

    public void precisionEffect()
    {
        float distanceReal = distanceHit;

        float error = Random.Range(-us.getError() * us.getDistanceSensor(), us.getError() * us.getDistanceSensor());

        distanceHit += error;
        
        if (distanceHit < 0)
            distanceHit = 0;
        Debug.Log("US devuelve objeto (con error) a " + distanceHit);
    }
    public bool getDetection()
    {
        return this.detection;
    }

    public float getDistanceHit()
    {
        return this.distanceHit;
    }
}
