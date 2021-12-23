using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Viking_Axes")
		{
			(GameObject.Find("CoinAndObstacle").GetComponent<CoinSpawner>()).coinList.Remove(gameObject.transform);
			Destroy(gameObject);
			ScoreCal.score += 20;
		}
	}
}
