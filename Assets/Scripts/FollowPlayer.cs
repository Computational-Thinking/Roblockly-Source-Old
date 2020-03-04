using UnityEngine.SceneManagement;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	private Camera cam;

	private void Start()
	{
		cam = GameObject.Find("Robot Camera").GetComponent<Camera>();
		cam.enabled = true;
		Debug.Log("HELLO");
		Debug.Log(cam);
		// cam.enabled = true;
	}
	void Update(){
		if (SceneManager.GetActiveScene().name == "Simulator"){
			cam.enabled = true;
		}
		else{
			cam.enabled = false;
		}
	}
	void FixedUpdate () {
		
		Vector3 offset = new Vector3();

		if (player.eulerAngles.y < 360) {
			if (player.eulerAngles.y > 270) {
				Vector2 offangle = Vector2.Lerp(new Vector2(270f, 0f), new Vector2(360f, 1f), player.eulerAngles.y/100f -2.7f);
				offset = Vector3.Lerp(new Vector3(20, 5f, 0f), new Vector3 (0f, 5f, -20f), offangle.y);
				
			} else if (player.eulerAngles.y > 180) {
				Vector2 offangle = Vector2.Lerp(new Vector2(180f, 0f), new Vector2(270f, 1f), player.eulerAngles.y/100f - 1.8f);
				offset = Vector3.Lerp (new Vector3 (0, 5f, 20f), new Vector3 (20f, 5f, 0f), offangle.y);

			} else if (player.eulerAngles.y > 90) {
				
				Vector2 offangle = Vector2.Lerp(new Vector2(90f, 0f), new Vector2(180f, 1f), player.eulerAngles.y/100f - 0.9f);
				offset = Vector3.Lerp(new Vector3(-20, 5f, 0f), new Vector3 (0f, 5f, 20f), offangle.y);
			
			} else if (player.eulerAngles.y > 0) {
				
				Vector2 offangle = Vector2.Lerp(new Vector2(0f, 0f), new Vector2(90f, 1f), player.eulerAngles.y/100f);
				offset = Vector3.Lerp(new Vector3(0, 5f, -20f), new Vector3 (-20f, 5f, 0f), offangle.y);

			} else {
				Debug.Log ("Ángulo no válido");
			}
					
		}

		transform.position = player.position + offset;
		transform.rotation = player.rotation;
	}
}
