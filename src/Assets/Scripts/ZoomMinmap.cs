using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomMinmap : MonoBehaviour {

	public Camera minmapCamera;

	public void SetZoom (float zoom){
		minmapCamera.orthographicSize = zoom;
	}
}
