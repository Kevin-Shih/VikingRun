using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontDestroyOnLoad : MonoBehaviour
{
	private static GameObject _instance = null;

	private void Awake()
	{
		if(_instance != null)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			_instance = this.gameObject;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
		
		DontDestroyOnLoad(this);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
