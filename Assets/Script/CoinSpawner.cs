using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public Transform coin, obstacle;
	public List<Transform> coinList;
	System.Random rand;
	int[,,] dir2coor = { { { 1, 0 }, { 0, 1 } }, { { 0, 1 }, { -1, 0 } }, { { -1, 0 }, { 0, -1 } }, { { 0, -1 }, { 1, 0 } } };
	// Start is called before the first frame update
	void Start()
    {
		coinList = new List<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
		if (coinList.Count > 40)
		{
			Destroy(coinList[0].gameObject);
			coinList.RemoveAt(0);
		}
    }

	public void GenCoin(Transform transform, int direction)
	{
		Debug.Log("coin_dir" + direction.ToString());
		rand = new System.Random((int)Time.time);
		float x;
		float z;
		for (int i = 0; i < 8; i++)
		{
			if (i==6||i==1)
			{
				double p = rand.NextDouble();
				if (p < 0.35)
				{
					Debug.Log("ob");
					x = dir2coor[direction, 0, 1] * ((i - 3.5f) * 3.5f);
					z = dir2coor[direction, 1, 1] * ((i - 3.5f) * 3.5f);
					Transform t2 = Instantiate(obstacle);
					t2.localPosition = new Vector3(transform.position.x + x, 0, transform.position.z + z);
					t2.Rotate(Vector3.up, 90 * direction);
					t2.name = transform.name + "_obstacle_" + (i + 1).ToString();
					t2.parent = GameObject.Find("CoinAndObstacle").transform;
					coinList.Add(t2);
					continue;
				}
			}
			Transform t = Instantiate(coin);
			x = dir2coor[direction, 0, 0] * ((rand.Next(-1, 2)) * 2f) + dir2coor[direction, 0, 1] * ((i - 3.5f) * 3.5f);
			z = dir2coor[direction, 1, 0] * ((rand.Next(-1, 2)) * 2f) + dir2coor[direction, 1, 1] * ((i - 3.5f) * 3.5f);
			t.localPosition = new Vector3(transform.position.x + x, 0.15f, transform.position.z + z);
			t.name = transform.name + "_Coin_" + (i + 1).ToString();
			t.parent = GameObject.Find("CoinAndObstacle").transform;
			coinList.Add(t);
		}
	}
}
