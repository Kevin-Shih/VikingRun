using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MonsterController : MonoBehaviour
{
	Transform viking;
	Rigidbody monsterRigidbody;
	ScoreCal start;
	public bool first = true;
	float countdown = 1.3f;
	// Start is called before the first frame update
	void Start()
    {
		viking = GameObject.Find("Viking_Axes").transform;
		monsterRigidbody = gameObject.GetComponent<Rigidbody>();
		start = GameObject.Find("Score").GetComponent<ScoreCal>();
	}

    // Update is called once per frame
    void Update()
    {
		if (first && start.start)
		{
			transform.position = new Vector3(viking.position.x, 1.5f, viking.position.z) - viking.forward * 15f;
			transform.rotation = viking.rotation;
		}
		if (!first)
		{
			countdown -= Time.deltaTime;
			if (countdown <= 0)
			{
				GameObject.Find("Viking_Axes").GetComponent<VikingController>().seized = false;
			}
			
		}
        
    }

	public void Seize()
	{
		first = false;
		monsterRigidbody.velocity = transform.forward * 20f;
	}
}
