using UnityEngine;
using System.Collections;

public class PCG_MazeBricks : MonoBehaviour {

	public GameObject brick;
	public int colheight;
	public int rowheight;

	private float xOffset = 0.97f;
	private float yOffset = 0.17f;

	private int [,] worldMap;

	// Use this for initialization
	void Start () {

		worldMap = new int[colheight, rowheight];

		for (int i = 0; i < colheight; i++) {
			for (int j = 0; j < rowheight; j++){
				worldMap[i,j] = Mathf.RoundToInt(Random.Range(0,5));
				print ("["+i+","+j+"] = "+ worldMap[i,j]);

				if (worldMap [i,j]>=4) {
					GameObject t = (GameObject)(Instantiate (brick, new Vector3 (j+xOffset, i+yOffset+1f, 0),
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
