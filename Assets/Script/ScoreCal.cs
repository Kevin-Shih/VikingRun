using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCal : MonoBehaviour
{
	// Start is called before the first frame update
	public static float score = 0;

    void Start()
    {
		score = 0;
		gameObject.GetComponent<Text>().text = String.Format("Score: {0:d6}", (int)score);
	}

    // Update is called once per frame
    void Update()
    {
		score += Time.deltaTime * 10;
		gameObject.GetComponent<Text>().text = String.Format("Score: {0:d6}", (int)score);
	}
}
