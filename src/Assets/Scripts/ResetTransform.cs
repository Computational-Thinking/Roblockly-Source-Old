using UnityEngine;
using UBlockly;

public class ResetTransform : MonoBehaviour
{
    public Material r_color;
    Renderer robot_cl;
    Transform robot_tr;
    private HingeJoint wheel_c,wheel_r,wheel_l;
    private Rigidbody wheel_c_rb,wheel_r_rb,wheel_l_rb,robot_rb;

    // Start is called before the first frame update
    void Start(){
        robot_cl = GameObject.Find("Permanente/Robot/BaseSq").GetComponent<Renderer>();

        robot_tr = GameObject.Find("Permanente/Robot").GetComponent<Transform>();
        robot_rb = GameObject.Find("Permanente/Robot").GetComponent<Rigidbody>();

        wheel_r = GameObject.FindGameObjectWithTag("WheelR").GetComponent<HingeJoint>();
        wheel_l = GameObject.FindGameObjectWithTag("WheelL").GetComponent<HingeJoint>();
        wheel_c = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<HingeJoint>();

        wheel_r_rb = GameObject.FindGameObjectWithTag("WheelR").GetComponent<Rigidbody>();
        wheel_l_rb = GameObject.FindGameObjectWithTag("WheelL").GetComponent<Rigidbody>();
        wheel_c_rb = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<Rigidbody>();
    }
    public void ResetPosRot(){
    	robot_tr.position = new Vector3(131.4f,8.5f,-76.1f);
      	robot_tr.eulerAngles = new Vector3(0,0,0);
        
        CSharp.Interpreter.Stop();        
        robot_rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; 

        wheel_r.useMotor = false; wheel_r_rb.drag = 9999999;
        wheel_l.useMotor = false; wheel_l_rb.drag = 9999999;
        wheel_c.useMotor = false; wheel_c_rb.drag = 9999999;

        robot_cl.sharedMaterial = r_color;

    }
}
