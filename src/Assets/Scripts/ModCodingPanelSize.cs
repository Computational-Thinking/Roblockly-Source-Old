using UnityEngine;

public class ModCodingPanelSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform codingpaneltr;
    void Start(){
        codingpaneltr = GameObject.Find("Workspace/CodingPanel").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeitBigger(){
        if(codingpaneltr.localScale.x < 1.33){
            codingpaneltr.localScale += new Vector3(0.11f,0.11f,0);
        }
    }
    public void MakeitSmaller(){
        if(codingpaneltr.localScale.x > 0.66){
            codingpaneltr.localScale -= new Vector3(0.11f,0.11f,0);
        } 
    }
}
