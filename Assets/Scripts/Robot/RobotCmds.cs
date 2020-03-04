using System.Collections;
using UBlockly;
using UnityEngine;

namespace UBlocklyGame.Robot
{
    [CodeInterpreter(BlockType = "move_robot_forward")]
    public class Move_Forward_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block){
           string distanceStr = block.GetFieldValue("DISTANCE");
            int distance = int.Parse(distanceStr);
        
            yield return RobotController.Instance.DoMoveForward(distance,0);
        }
    }
    [CodeInterpreter(BlockType = "move_robot_forward_time")]
    public class Move_Forward_Time_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block){
           string distanceStr = block.GetFieldValue("DISTANCE");
            int distance = int.Parse(distanceStr);
            string timeSTR = block.GetFieldValue("TIME");
            int time = int.Parse(timeSTR);
        
            yield return RobotController.Instance.DoMoveForward(distance,time);
        }
    }
    [CodeInterpreter(BlockType = "move_robot_backward_time")]
    public class Move_Backward_Time_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block){
           string distanceStr = block.GetFieldValue("DISTANCE");
            int distance = int.Parse(distanceStr);
            string timeSTR = block.GetFieldValue("TIME");
            int time = int.Parse(timeSTR);
        
            yield return RobotController.Instance.DoMoveBackward(distance,time);
        }
    }
    [CodeInterpreter(BlockType = "move_robot_backward")]
    public class Move_Backward_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block){
           string distanceStr = block.GetFieldValue("DISTANCE");
            int distance = int.Parse(distanceStr);
        
            yield return RobotController.Instance.DoMoveBackward(distance,0);
        }
    }
    [CodeInterpreter(BlockType = "move_turn_robot")]
    
    public class Turn_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block)
        {
            string dir = block.GetFieldValue("DIRECTION");
            yield return RobotController.Instance.DoTurn(12345,dir);
        }
    }
    [CodeInterpreter(BlockType = "move_turn_robot_angle")]
    
    public class Turn_Robot_Angle_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block)
        {
            float angle = float.Parse(block.GetFieldValue("ANGLE"));
            string dir = block.GetFieldValue("DIRECTION");
            yield return RobotController.Instance.DoTurn(angle,dir);
        }
    }
    [CodeInterpreter(BlockType = "move_stop_robot")]
    public class Stop_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block)
        {
            yield return RobotController.Instance.DoStop();
        }
    }
    [CodeInterpreter(BlockType = "sensor_ir_black")]
    public class Detection_Sensor_IR_Black_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            int index = int.Parse(block.GetFieldValue("NUMBER"));
            bool data = RobotController.Instance.INFOSensorIR(index,true);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
    [CodeInterpreter(BlockType = "sensor_ir_white")]
    public class Detection_Sensor_IR_White_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            int index = int.Parse(block.GetFieldValue("NUMBER"));
            bool data = RobotController.Instance.INFOSensorIR(index,false);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
    [CodeInterpreter(BlockType = "sensor_touch_contact")]
    public class Detection_Sensor_Touch_Contact_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            int index = int.Parse(block.GetFieldValue("NUMBER"));
            bool data = RobotController.Instance.INFOSensorTouch(index,true);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
    [CodeInterpreter(BlockType = "sensor_touch_notcontact")]
    public class Detection_Sensor_Touch_NotContact_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            int index = int.Parse(block.GetFieldValue("NUMBER"));
            bool data = RobotController.Instance.INFOSensorTouch(index,false);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
    [CodeInterpreter(BlockType = "sensor_us")]
    public class Detection_Sensor_US_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            int index = int.Parse(block.GetFieldValue("NUMBER"));
            double data = RobotController.Instance.INFOSensorUS(index);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
}
    
