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
	[SerializeField] float movingSpeed = 10f;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] float jumpForce = 7.5f;
	Rigidbody vikingRigidbody;
	Animator animator;
	ScoreCal start;
	public bool isJump = true;
	public bool run = false;
	public bool gameover = false;
	public bool seized = false;
	public int turn = 0, t_frame;
	public float frames2be_seized = 1; //insec
	public string gameover_message = "";
	void Awake()
	{

	}
	// Start is called before the first frame update
	void Start()
    {
		vikingRigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		t_frame = (int)(1 / (3 * Time.deltaTime));
		start = GameObject.Find("Score").GetComponent<ScoreCal>();
	}

    // Update is called once per frame
    void Update()
    {
		if (gameover)
			return;
		if (start.start)
		{
			frames2be_seized -= Time.deltaTime;
			if (frames2be_seized <= 0)
			{
				gameover_message = "You were seized by the Monster!";
				seized = true;
				gameover = true;
				return;
			}
		}		

		run = false;
		if (Input.GetKey(KeyCode.W))
		{
			vikingRigidbody.velocity = new Vector3(0, vikingRigidbody.velocity.y, 0) + transform.forward * movingSpeed * 1.2f;
			run = true;

		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			if (!isJump)
			{
				vikingRigidbody.velocity = new Vector3(0, vikingRigidbody.velocity.y, 0) + transform.forward * movingSpeed * 0.25f;
				run = true;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			vikingRigidbody.velocity = new Vector3(vikingRigidbody.velocity.x, -jumpForce * 1.5f, vikingRigidbody.velocity.z);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.localPosition += transform.right * Time.deltaTime * -1 * movingSpeed;
			run = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.localPosition += transform.right * Time.deltaTime * movingSpeed;
			run = true;
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (!isJump)
			{
				turn += t_frame;
			}
		} //turn left
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (!isJump)
			{
				turn -= t_frame;
			}
		}	//turn right
		if (Input.GetKey(KeyCode.Space))
		{
			if (!isJump)
			{
				vikingRigidbody.velocity = new Vector3(vikingRigidbody.velocity.x, jumpForce, vikingRigidbody.velocity.z);
				isJump = true;
			}
		} //jump
		if (Input.GetKey(KeyCode.Escape)) //Back to menu
		{
			SceneManager.LoadScene(0);
		}
		//turn left or right more smoothly
		if (turn > 0)
		{
			transform.Rotate(Vector3.down, rotateSpeed * 1 / t_frame);
			turn--;
		}
		else if(turn < 0)
		{
			transform.Rotate(Vector3.up, rotateSpeed * 1 / t_frame);
			turn++;
		}

		if (transform.position.y < -5) //game over
		{
			gameover_message = "You fell to your death!";
			gameover = true;
		}
		if (transform.position.y < 0)
		{
			isJump = true;
		}
		animator.SetBool("Run",run);
		animator.SetBool("Jump", isJump);
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
