using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class USSensorScript : MonoBehaviour
{


    // public MovementSensor movement;

    // La distancia del sensor es:
    // El tamaño del robot es 0.25m en todos lados
    // El sensor US tiene escala 0.25 DENTRO del robot
    // El rango de medida del sensor debe ser respecto al tamaño del robot no del sensor (Por lo que se debe multiplicar por 2 los metros que se especifiquen por parte del usuario, si fuese por 4 se haría la medida sobre 2m)

    public float distanceSensor = 2.5f;
    public float error = 0.0f;
    public GameObject USSensor;




    public GameObject baseRobot;
    private float largoBase;
    private float anchoBase;
    private float escalaRobot;
    private float largoRealRobot = 0.5f;
    private float scaleFactor;

    public InformationRobot info;

    private bool posicionReal = true;
    private GameObject isOk;
    public TextMeshProUGUI sensorname;



    // Use this for initialization
    void Start()
    {
        if (gameObject.transform.parent.parent.name == "Robot")
        {
            baseRobot = GameObject.Find("Robot/BaseSq");
            GameObject go = GameObject.Find("Robot");
            escalaRobot = go.transform.localScale.x;
            
            info = (InformationRobot)go.GetComponent(typeof(InformationRobot));

            isOk = transform.GetChild(transform.childCount - 2).gameObject;


            largoBase = baseRobot.transform.localScale.z;
            anchoBase = baseRobot.transform.localScale.x;
            scaleFactor = escalaRobot * largoBase / largoRealRobot;
            /////Cambiar nombre a los sensoresTouch que se instancian/////
            int count = 0;
            foreach (Transform side in go.transform)
            {

                foreach (Transform touchSensor in side)
                {

                    if (touchSensor.tag == "US")
                    {
                        count++;
                        Debug.Log(count);
                        if (GameObject.Find("SensorUS" + count.ToString()) == null)
                        {
                            break;
                        }
                    }
                }
            }
            gameObject.name = "SensorUS" + count.ToString();
            sensorname.text = "SensorUS" + count.ToString();
            /////Cambiar nombre a los sensoresTouch que se instancian/////
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.parent.name == "Robot")
        {

            if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase < baseRobot.transform.localScale.z)
                transform.Translate(-0.0125F, 0, 0);
            else if ((this.transform.parent.tag == "FrontSide" || this.transform.parent.tag == "BackSide") && largoBase > baseRobot.transform.localScale.z)
                transform.Translate(0.0125F, 0, 0);

            if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase < baseRobot.transform.localScale.x)
                transform.Translate(-0.0125F, 0, 0);
            else if ((this.transform.parent.tag == "LeftSide" || this.transform.parent.tag == "RightSide") && anchoBase > baseRobot.transform.localScale.x)
                transform.Translate(0.0125F, 0, 0);

            escalaRobot = gameObject.transform.parent.parent.transform.localScale.x;
            largoBase = baseRobot.transform.localScale.z;
            anchoBase = baseRobot.transform.localScale.x;
            scaleFactor = escalaRobot * largoBase / largoRealRobot;
            if (posicionReal == false)
            {
                isOk.SetActive(true);
            }
            else
            {
                isOk.SetActive(false);
            }
        }
    }

    void GetBigger()
    {
        transform.localScale += new Vector3(0, 0.05F, 0.05F);
    }

    void getSmaller()
    {
        transform.localScale -= new Vector3(0, 0.05F, 0.05F);

    }
    public float getScaleFactor()
    {
        return scaleFactor;

    }


    void ConfigurateSensor(float distanceSensorConfig, float errorConfig)
    {
        this.distanceSensor = distanceSensorConfig;
        this.error = errorConfig;
    }


    public float getDistanceSensor()
    {
        return this.distanceSensor * scaleFactor; 
    }

    public float getError()
    {
        return this.error;
    }


    public void setDistanceSensor(float distance)
    {
        this.distanceSensor = distance;
    }

    public void setError(float error)
    {
        this.error = error;
    }




    public bool getPosicionReal()
    {
        return this.posicionReal;
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            posicionReal = true;
        }


        if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar" || other.tag == "Touch")
        {
            posicionReal = false;
            print("TAG: " + other.tag);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Laser" || other.tag == "US" || other.tag == "IR" || other.tag == "Lidar" || other.tag == "Touch")
            posicionReal = true;


        if (other.tag == "Base")
        {
            posicionReal = false;
        }

    }
}
