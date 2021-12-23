using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
	CanvasRenderer canvasRenderer;
	// Start is called before the first frame update
	void Start()
    {
		canvasRenderer = gameObject.GetComponent<CanvasRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		
		canvasRenderer.SetAlpha(Mathf.Abs(Mathf.Cos(Time.time)));
    }
}
