using System.Collections;
using UToolbox;
using UnityEngine;

namespace UBlocklyGame.Robot
{
    public class RobotController : MonoSingleton<RobotController>{
        private GameObject robot;
        private Rigidbody robot_rb;
        private HingeJoint wheel_c,wheel_r,wheel_l;
        private Rigidbody wheel_c_rb,wheel_r_rb,wheel_l_rb;

        private void Awake(){
            robot = GameObject.Find("/Permanente/Robot");  
            robot_rb = robot.GetComponent<Rigidbody>();

            wheel_r = GameObject.FindGameObjectWithTag("WheelR").GetComponent<HingeJoint>();
            wheel_l = GameObject.FindGameObjectWithTag("WheelL").GetComponent<HingeJoint>();
            wheel_c = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<HingeJoint>();

            wheel_r_rb = GameObject.FindGameObjectWithTag("WheelR").GetComponent<Rigidbody>();
            wheel_l_rb = GameObject.FindGameObjectWithTag("WheelL").GetComponent<Rigidbody>();
            wheel_c_rb = GameObject.FindGameObjectWithTag("WheelCenter").GetComponent<Rigidbody>();
        }
            // private RobotBehavior mBehavior;
        public IEnumerator DoMoveForward(int distance,int time){
            
            robot_rb.constraints = RigidbodyConstraints.FreezeRotation;
            wheel_r_rb.drag = 5;
            wheel_l_rb.drag = 5;
            wheel_c_rb.drag = 5;

            JointMotor motor_r = wheel_r.motor;      
            JointMotor motor_l = wheel_l.motor;      
            JointMotor motor_c = wheel_c.motor;     

            motor_r.targetVelocity = 300*distance;
            motor_l.targetVelocity = -300*distance;
            motor_c.targetVelocity = -300*distance/3;

            motor_r.force = 200*distance;
            motor_l.force = 200*distance;
            motor_c.force = 200*distance/3;

            wheel_r.motor = motor_r; 
            wheel_l.motor = motor_l; 
            wheel_c.motor = motor_c;
            
            wheel_r.useMotor = true;
            wheel_l.useMotor = true;
            wheel_c.useMotor = true;

            if (time != 0) {
                yield return new WaitForSeconds(time);
                wheel_r.useMotor = false;
                wheel_l.useMotor = false;
                wheel_c.useMotor = false;  
            }
            yield return null;
        }
        public IEnumerator DoMoveBackward(int distance,int time){
            
            robot_rb.constraints = RigidbodyConstraints.FreezeRotation;
            wheel_r_rb.drag = 5;
            wheel_l_rb.drag = 5;
            wheel_c_rb.drag = 5;
 
            JointMotor motor_r = wheel_r.motor;      
            JointMotor motor_l = wheel_l.motor;      
            JointMotor motor_c = wheel_c.motor;     

            motor_r.targetVelocity = -300*distance/3;
            motor_l.targetVelocity = 300*distance/3;
            motor_c.targetVelocity = 300*distance;

            motor_r.force = 200*distance/3;
            motor_l.force = 200*distance/3;
            motor_c.force = 200*distance;

            wheel_r.motor = motor_r; 
            wheel_l.motor = motor_l; 
            wheel_c.motor = motor_c;
            
            wheel_r.useMotor = true;
            wheel_l.useMotor = true;
            wheel_c.useMotor = true;

            if (time != 0) {
                yield return new WaitForSeconds(time);
                wheel_r.useMotor = false;
                wheel_l.useMotor = false;
                wheel_c.useMotor = false;  
            }
            yield return null;
        }
 
        public IEnumerator DoTurn(float angle, string dir){
            float epsilon = 0.5f;

            robot_rb.constraints = RigidbodyConstraints.None;

            wheel_r_rb.drag = 5;
            wheel_l_rb.drag = 5;
            wheel_c_rb.drag = 5;
            
            float scale = wheel_r.transform.localScale.z;

            bool girando = true;
            bool inverted = false;

            JointMotor motor_r = wheel_r.motor;      
            JointMotor motor_l = wheel_l.motor;      
            JointMotor motor_c = wheel_c.motor; 
            
            wheel_r.useMotor = false;
            wheel_l.useMotor = false;
            wheel_c.useMotor = false;

            float initial_angle = (robot.GetComponent<Transform>().eulerAngles.y);
            float final_angle;
            if (dir == "LEFT"){
                final_angle = initial_angle - angle;
                if (final_angle < 0) final_angle += 360;
                Debug.Log("GIRO A LA IZQUIERDA");
            
                Debug.Log ("ANGULO A GIRAR"+angle);
                Debug.Log ("ANGULO INICIAL "+initial_angle);
                Debug.Log ("ANGULO FINAL "+final_angle);
                //rotar

                wheel_l.useMotor = true; wheel_r.useMotor = true; 
                motor_l.targetVelocity = 400*scale; motor_r.targetVelocity = 400*scale; 
                motor_l.force = 650*scale; motor_r.force = 650*scale; 
                wheel_l.motor = motor_l; wheel_r.motor = motor_r; 
                
                //dejar de rotar
                while (girando && angle != 12345){
                    if (final_angle == robot.GetComponent<Transform>().eulerAngles.y) {
				        girando = false;
			        }                   
                    if ((girando) & (final_angle <= epsilon || final_angle >= 360-epsilon)){
                        Debug.Log("Es un ángulo próximo al 0");
                        if (initial_angle > final_angle){ //Ángulo final cercano a 0 por la derecha
                            Debug.Log("Es próximo por la derecha");
                            if (robot.GetComponent<Transform>().eulerAngles.y - epsilon <= final_angle){
				                Debug.Log("El robot está en el umbral, cese del giro");
				                girando = false;
                            }
                        }
                        else{ //Ángulo final cercano a 0 por la izquierda
                            Debug.Log("Es próximo por la izquierda");
                            if (robot.GetComponent<Transform>().eulerAngles.y - epsilon >= final_angle){
				                Debug.Log("El robot está en el umbral, cese del giro");
                                girando = false;
                            }
                        }
			        }
                    if ((girando) & (robot.GetComponent<Transform>().eulerAngles.y < final_angle) & (robot.GetComponent<Transform>().eulerAngles.y <= initial_angle) & (!inverted)){
                    }
                    else{ 
                        if ((girando) & (robot.GetComponent<Transform>().eulerAngles.y > final_angle)){
                            inverted = true;
                        }
                        else{
                            girando = false;
                        } 
                    }
                    yield return new WaitForEndOfFrame();
                }
                if (angle != 12345){
                    Transform fix_turn = robot.GetComponent<Transform>();
                    fix_turn.eulerAngles = new Vector3(fix_turn.eulerAngles.x,final_angle,fix_turn.eulerAngles.z);
                }
            }
            else{
                final_angle = initial_angle + angle;
                if (final_angle >= 360) final_angle -= 360;
                Debug.Log("GIRO A LA DERECHA");
                
                Debug.Log ("ANGULO A GIRAR"+angle);
                Debug.Log ("ANGULO INICIAL "+initial_angle);
                Debug.Log ("ANGULO FINAL "+final_angle);
                //rotar

                wheel_l.useMotor = true; wheel_r.useMotor = true; 
                motor_l.targetVelocity = -400*scale; motor_r.targetVelocity = -400*scale; 
                motor_l.force = 650*scale; motor_r.force = 650*scale; 
                wheel_l.motor = motor_l; wheel_r.motor = motor_r; 

                //dejar de rotar
                while (girando && angle != 12345){
                    if (final_angle == robot.GetComponent<Transform>().eulerAngles.y) {
				        girando = false;
			        }
                    if ((girando) & (final_angle <= epsilon || final_angle >= 360-epsilon)){
                        Debug.Log("Es un ángulo próximo al 0");
                        if (initial_angle > final_angle){ //Ángulo final cercano a 0 por la derecha
                            Debug.Log("Es próximo por la derecha");
                            if (robot.GetComponent<Transform>().eulerAngles.y + epsilon <= final_angle){
                                Debug.Log("El robot está en el umbral, cese del giro");
				                girando = false;
                            }
                        }
                        else{ //Ángulo final cercano a 0 por la izquierda
                            Debug.Log("Es próximo por la izquierda");
                            if (robot.GetComponent<Transform>().eulerAngles.y + epsilon >= final_angle){
				                Debug.Log("El robot está en el umbral, cese del giro");
                                girando = false;
                            }
                        }
			        }
                    if ((girando) & (robot.GetComponent<Transform>().eulerAngles.y > final_angle) & (robot.GetComponent<Transform>().eulerAngles.y >= initial_angle) & (!inverted)){
                    }
                    else{ 
                        if ((girando) & (robot.GetComponent<Transform>().eulerAngles.y < final_angle)){
                            inverted = true;
                        }
                        else{
                            girando = false;
                        } 
                    }
                    yield return new WaitForEndOfFrame();
                }
                if (angle != 12345){
                    Transform fix_turn = robot.GetComponent<Transform>();
                    fix_turn.eulerAngles = new Vector3(fix_turn.eulerAngles.x,final_angle,fix_turn.eulerAngles.z);
                }
            }
            if (angle != 12345){
                wheel_r.useMotor = false;
                wheel_l.useMotor = false;
                wheel_c.useMotor = false; 
            }

            yield return null;
        }
        public IEnumerator DoStop(){
            robot_rb.constraints = RigidbodyConstraints.FreezeRotation;

            wheel_r.useMotor = false; wheel_r_rb.drag = 9999999;
            wheel_l.useMotor = false; wheel_l_rb.drag = 9999999;
            wheel_c.useMotor = false; wheel_c_rb.drag = 9999999;

            yield return new WaitForSeconds(1);
        }
        public bool INFOSensorIR(int index,bool isblack){
            bool dark;
            IRSensorDetection infr = (IRSensorDetection) GameObject.Find("SensorIR"+index).transform.GetChild(2).transform.GetChild(3).GetComponent(typeof(IRSensorDetection));
            if (!infr.getOscuro ()){
                dark = false; 
            }
            else{
                dark = true; 
            }
            Debug.Log("Es "+dark.ToString());
            if (isblack == false){
                dark = !dark;
            }
            return dark;
        }
        public bool INFOSensorTouch(int index,bool iscontact){
            bool contact;
            TouchSensorContact touch = (TouchSensorContact) GameObject.Find("SensorTouch"+index).GetComponent(typeof(TouchSensorContact));
            contact = touch.getContact();
            Debug.Log("TOCANDO"+contact.ToString());
            if(iscontact == false){
                contact = !contact;
            }
            return contact;
        }
        public double INFOSensorUS(int index){
            double distance;
            USSensorDistance us = (USSensorDistance) GameObject.Find("SensorUS"+index).transform.GetChild(16).GetComponent(typeof(USSensorDistance));
            if (us.getDetection ()) {
                distance = (double)us.getDistanceHit ();
            } else
                distance = double.MaxValue;
            return distance;
        }
    }
}