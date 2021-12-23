using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MonsterController : MonoBehaviour
{
	Transform viking;
	Rigidbody monsterRigidbody;
	public bool first = true;
	float countdown = 1.3f;
	// Start is called before the first frame update
	void Start()
    {
		viking = GameObject.Find("Viking_Axes").transform;
		monsterRigidbody = gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		if (first)
		{
			transform.position = new Vector3(viking.position.x, 1.5f, viking.position.z) - viking.forward * 15f;
			transform.rotation = viking.rotation;
		}
		else
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
		if (first)
		{
			transform.position = new Vector3(viking.position.x, 1.5f, viking.position.z) - viking.forward * 15f;
			transform.rotation = viking.rotation;
		}
		first = false;
		monsterRigidbody.velocity = transform.forward * 20f;
	}
}
