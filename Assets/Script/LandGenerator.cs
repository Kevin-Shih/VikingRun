using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class LandGenerator : MonoBehaviour
{
	public Transform road;
	public Transform intersect;
	System.Random rand;
	public static int i = 0;
	public static int consistancy = 2; //大於0時必先走consistancy個直線的block
	public int direction = 0; //0:朝Z 1:朝X 2:朝-Z 3:朝-X
	public int[,,] dir2coor = { { { 1, 0 }, { 0, 1 } }, { { 0, 1 }, { -1, 0 } } , { { -1, 0 }, { 0, -1 } } , { { 0, -1 }, { 1, 0 } } };
	float T_x, T_z, T_x_inter, T_z_inter, T_base_turn = 18f, T_base_straight = 31f;
	CoinSpawner coinSpawner;
	/*
	dir2coor 即每個direction對應的旋轉矩陣，用於計算Road平移量
	T = R*[X,Z]'
	0: [[ 1, 0], 1: [[ 0, 1], 2: [[-1, 0],  3: [[ 0,-1],
		[ 0, 1]]	 [-1, 0]]	  [ 0, -1]]		[ 1, 0]]
	*/

	// Start is called before the first frame update
	void Start()
    {
		rand = new System.Random();
		coinSpawner = GameObject.Find("Coin").GetComponent<CoinSpawner>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other) //when trigger gen next road
	{
		Transform t = Instantiate(road);
		double p = rand.NextDouble();
		if(consistancy > 0 || p < 0.6)
		{
			T_x = dir2coor[direction, 0, 1] * T_base_straight;
			T_z = dir2coor[direction, 1, 1] * T_base_straight;
			//normal straight
			t.localPosition = new Vector3(transform.position.x + T_x, -1, transform.position.z + T_z);
			t.name = "road" + (i % 20).ToString();
			t.parent = transform.parent;
			(t.gameObject.GetComponent<LandGenerator>()).direction = direction;
			LandKiller.roadList.Add(t);
			i++;
			consistancy--;
		}
		else if(p < 0.75)
		{
			Debug.Log("Left"+i.ToString());
			T_x = dir2coor[direction, 0, 0] * -T_base_turn + dir2coor[direction, 0, 1] * T_base_turn;
			T_z = dir2coor[direction, 1, 0] * -T_base_turn + dir2coor[direction, 1, 1] * T_base_turn;
			T_x_inter = dir2coor[direction, 0, 1] * T_base_turn;
			T_z_inter = dir2coor[direction, 1, 1] * T_base_turn;

			//add intersect
			Transform inter = Instantiate(intersect);
			inter.localPosition = new Vector3(transform.position.x + T_x_inter, -1, transform.position.z + T_z_inter);
			inter.name = "road_intersect" + (i % 20).ToString();
			inter.parent = transform.parent;
			LandKiller.roadList.Add(inter);
			//left turn
			t.localPosition = new Vector3(transform.position.x + T_x, -1, transform.position.z + T_z);
			t.Rotate(Vector3.down, 90);
			t.name = "road" + (i % 20).ToString();
			t.parent = transform.parent;
			(t.gameObject.GetComponent<LandGenerator>()).direction = ((direction - 1) < 0)? 3 : (direction - 1);
			LandKiller.roadList.Add(t);
			i++;
			consistancy = 1;
		}
		else if (p < 0.9)
		{
			Debug.Log("Right" + i.ToString());
			T_x = dir2coor[direction, 0, 0] * T_base_turn + dir2coor[direction, 0, 1] * T_base_turn;
			T_z = dir2coor[direction, 1, 0] * T_base_turn + dir2coor[direction, 1, 1] * T_base_turn;
			T_x_inter = dir2coor[direction, 0, 1] * T_base_turn;
			T_z_inter = dir2coor[direction, 1, 1] * T_base_turn;

			//add intersect
			Transform inter = Instantiate(intersect);
			inter.localPosition = new Vector3(transform.position.x + T_x_inter, -1, transform.position.z + T_z_inter);
			inter.name = "road_intersect" + (i % 20).ToString();
			inter.parent = transform.parent;
			LandKiller.roadList.Add(inter);
			//right turn
			t.localPosition = new Vector3(transform.position.x + T_x, -1, transform.position.z + T_z);
			t.Rotate(Vector3.up, 90);
			t.name = "road" + (i % 20).ToString();
			t.parent = transform.parent;
			(t.gameObject.GetComponent<LandGenerator>()).direction = (direction + 1) % 4;
			LandKiller.roadList.Add(t);
			i++;
			consistancy = 1;
		}
		else
		{
			Debug.Log("T" + i.ToString());
			float T_x_l = dir2coor[direction, 0, 0] * -T_base_turn + dir2coor[direction, 0, 1] * T_base_turn;
			float T_z_l = dir2coor[direction, 1, 0] * -T_base_turn + dir2coor[direction, 1, 1] * T_base_turn;
			float T_x_r = dir2coor[direction, 0, 0] * T_base_turn + dir2coor[direction, 0, 1] * T_base_turn;
			float T_z_r = dir2coor[direction, 1, 0] * T_base_turn + dir2coor[direction, 1, 1] * T_base_turn;
			T_x_inter = dir2coor[direction, 0, 1] * T_base_turn;
			T_z_inter = dir2coor[direction, 1, 1] * T_base_turn;

			//add intersect
			Transform inter = Instantiate(intersect);
			inter.localPosition = new Vector3(transform.position.x + T_x_inter, -1, transform.position.z + T_z_inter);
			inter.name = "road_intersect" + (i % 20).ToString();
			inter.parent = transform.parent;
			LandKiller.roadList.Add(inter);

			//T turn_L
			t.localPosition = new Vector3(transform.position.x + T_x_l, -1, transform.position.z + T_z_l);
			t.Rotate(Vector3.down, 90);
			t.name = "road_TL" + (i % 20).ToString();
			t.parent = transform.parent;
			(t.gameObject.GetComponent<LandGenerator>()).direction = ((direction - 1) < 0) ? 3 : (direction - 1);
			LandKiller.roadList.Add(t);
			i++;
			//T turn_R
			Transform t2 = Instantiate(road);
			t2.localPosition = new Vector3(transform.position.x + T_x_r, -1, transform.position.z + T_z_r);
			t2.Rotate(Vector3.up, 90);
			t2.name = "road_TR" + (i % 20).ToString();
			t2.parent = transform.parent;
			(t2.gameObject.GetComponent<LandGenerator>()).direction = (direction + 1) % 4;
			LandKiller.roadList.Add(t2);
			i++;
			consistancy = 2;
			//for TR
			coinSpawner.GenCoin(t2, (t2.gameObject.GetComponent<LandGenerator>()).direction);
		}
		coinSpawner.GenCoin(t, (t.gameObject.GetComponent<LandGenerator>()).direction);
	}
}
