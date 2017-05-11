using UnityEngine;
using System.Collections;

public class GenerateMaze : MonoBehaviour {

	public GameObject wall;

	private int [,] worldMap = new int[,] {
		{1,1,1,1,1,1,1,1,1,1},
		{1,0,1,0,0,0,0,0,0,1},
		{1,0,1,0,1,0,1,0,0,1},
		{1,0,1,0,0,0,0,0,0,1},
		{1,0,1,1,1,1,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,1},
		{1,0,1,0,1,0,1,1,1,1},
		{1,0,0,1,0,0,0,0,0,1},
		{1,0,1,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,1,1},
	};

	// Use this for initialization
	void Start () {

		int i,j;

		for (i = 0; i < worldMap.GetLength(0); i++) {
			for (j = 0; j < worldMap.GetLength(1); j++){

				print ("["+i+","+j+"] = "+ worldMap[i,j]);


				if (worldMap [i,j]==1) {
					GameObject t = (GameObject)(Instantiate (wall, new Vector3 (45-i*10, 1.5f, 45-j*10),
											Quaternion.identity));
					t.transform.parent = this.transform;
				}
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
