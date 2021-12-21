using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public Transform coin;
	public List<Transform> coinList;
	System.Random rand;
	public int[,,] dir2coor = { { { 1, 0 }, { 0, 1 } }, { { 0, 1 }, { -1, 0 } }, { { -1, 0 }, { 0, -1 } }, { { 0, -1 }, { 1, 0 } } };
	// Start is called before the first frame update
	void Start()
    {
		coinList = new List<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
		if (coinList.Count > 20)
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
			Transform t = Instantiate(coin);
			x = dir2coor[direction, 0, 0] * ((rand.Next(-1, 2)) * 2f) + dir2coor[direction, 0, 1] * ((i - 3.5f) * 3.5f);
			z = dir2coor[direction, 1, 0] * ((rand.Next(-1, 2)) * 2f) + dir2coor[direction, 1, 1] * ((i - 3.5f) * 3.5f);
			t.localPosition = new Vector3(transform.position.x + x, 0.1f, transform.position.z + z);
			t.name = transform.name + "_Coin_" + (i + 1).ToString();
			t.parent = GameObject.Find("Coin").transform;
			coinList.Add(t);
		}
	}
}
