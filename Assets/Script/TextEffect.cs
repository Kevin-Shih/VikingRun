using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		CanvasRenderer canvasRenderer = gameObject.GetComponent<CanvasRenderer>();
		canvasRenderer.SetAlpha(Mathf.Abs(Mathf.Cos(Time.time)));
    }
}
