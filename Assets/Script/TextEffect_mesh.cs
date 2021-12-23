using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect_mesh : MonoBehaviour
{
	TextMesh canvasRenderer;
	// Start is called before the first frame update
	void Start()
	{
		canvasRenderer = gameObject.GetComponent<TextMesh>();
	}

	// Update is called once per frame
	void Update()
	{

		canvasRenderer.color = new Color(0, 255, 255, Mathf.Abs(Mathf.Cos(2 * Time.time) * 0.5f) + 0.5f);
	}
}
