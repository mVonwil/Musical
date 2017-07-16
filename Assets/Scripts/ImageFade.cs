using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFade : MonoBehaviour {

	public CanvasGroup canvas;
	public float time2Fade = 2;
	
	// Update is called once per frame
	void Update () {
		canvas.alpha -= (Time.deltaTime / time2Fade);
	}
}
