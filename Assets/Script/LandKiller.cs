using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandKiller : MonoBehaviour
{
	public static List<Transform> roadList; //要另外放 不然每次都建新的
	// Start is called before the first frame update
	void Start()
    {
		roadList = new List<Transform>();
		roadList.Add(GameObject.Find("big_module_01").transform);
		roadList.Add(GameObject.Find("road_init_0").transform);
		roadList.Add(GameObject.Find("road_init_1").transform);
    }

    // Update is called once per frame
    void Update()
    {
		if (roadList.Count > 6)
		{
			Destroy(roadList[0].gameObject);
			roadList.RemoveAt(0);
		}
    }
}
