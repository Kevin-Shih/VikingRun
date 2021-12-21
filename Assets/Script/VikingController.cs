using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class VikingController : MonoBehaviour
{
	[SerializeField] float movingForce = 10f;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] float jumpForce = 10f;
	Rigidbody vikingRigidbody;
	Animator animator;
	public bool isJump = true;
	public bool run = false;
	void Awake()
	{

	}
	// Start is called before the first frame update
	void Start()
    {
		vikingRigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {

		//transform.localPosition += movingDirection * Time.deltaTime * movingSpeed;

		run = false;
		if (Input.GetKey(KeyCode.W))
		{
			transform.localPosition += transform.forward * Time.deltaTime * movingForce * 1.5f;
			run = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			/*if (!isJump)
			{
				vikingRigidbody.AddRelativeForce(Vector3.left * Time.deltaTime * movingForce);
				run = true;
			}*/
			//vikingRigidbody.AddRelativeForce(Vector3.left * Time.deltaTime * movingForce);
			transform.localPosition += transform.right * Time.deltaTime * -1 * movingForce;
			run = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			/*if (!isJump)
			{
				vikingRigidbody.AddRelativeForce(Vector3.right * Time.deltaTime * movingForce);
				run = true;
			}*/
			//vikingRigidbody.AddRelativeForce(Vector3.right * Time.deltaTime * movingForce);
			transform.localPosition += transform.right * Time.deltaTime * movingForce;
			run = true;
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			//vikingRigidbody.AddRelativeTorque(Vector3.down * Time.deltaTime * rotateForce);
			transform.Rotate(Vector3.down, rotateSpeed);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			//vikingRigidbody.AddRelativeTorque(Vector3.up * Time.deltaTime * rotateForce);
			transform.Rotate(Vector3.up , rotateSpeed);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			if (!isJump)
			{
				//vikingRigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
				vikingRigidbody.velocity = new Vector3(vikingRigidbody.velocity.x, jumpForce, vikingRigidbody.velocity.z);
				isJump = true;
			}
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}

		
		animator.SetBool("Run",run);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (isJump)
		{
			vikingRigidbody.velocity = new Vector3(vikingRigidbody.velocity.x, 0, vikingRigidbody.velocity.z);
			isJump = false;
		}
	}
	void OnCollisionStay(Collision collision)
	{
		isJump = false;
	}
}
/*if (Input.GetMouseButtonDown(0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if(Physics.Raycast(ray, out raycastHit))
			{
				Debug.Log(raycastHit.collider.name.Substring(0, 4));
				if(raycastHit.collider.name.Substring(0,4) == "Coin")
					Destroy(raycastHit.collider.gameObject);
			}
		}*/
