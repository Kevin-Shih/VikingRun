using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
	public static float starttime=0;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerEnter(Collider other) //trigger scorecal
	{
		starttime = Time.time;
		GameObject.Find("Score").GetComponent<ScoreCal>().start = true;
	}
}
