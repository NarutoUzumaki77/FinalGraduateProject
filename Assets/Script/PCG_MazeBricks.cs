using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PCG_MazeBricks : MonoBehaviour {

	public GameObject brick;
	public int colheight;
	public int rowheight;
    public static List<string> mazePositions = new List<string>();

	private float xOffset = 0.97f;
	private float yOffset = 0.17f;
	private int [,] worldMap;

	void Start () {

		worldMap = new int[colheight, rowheight];

		for (int i = 0; i < colheight; i++) {
			for (int j = 0; j < rowheight; j++){
				worldMap[i,j] = Mathf.RoundToInt(Random.Range(0,5));

                mazePositions.Add("9|1"); //Barn position
				if (worldMap [i,j]>=4 && !(j == 9 && i == 1)) {
                    float x = j + xOffset;
                    float y = i + yOffset + 1f;
					GameObject t = (GameObject)(Instantiate (brick, new Vector3 (x, y, 0),
											Quaternion.identity));
					t.transform.parent = this.transform;
                    string position = Mathf.RoundToInt(x) + "|" + Mathf.RoundToInt(y);
                    mazePositions.Add(position);
				}
			}
		}
	}
}
