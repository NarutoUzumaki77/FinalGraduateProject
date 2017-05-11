using UnityEngine;
using System.Collections;

public class GenerateGameBorders : MonoBehaviour {

	public GameObject wall;

	private float xOffset = 0.45f;
	private float yOffset = 0.7f;

	private int [,] worldMap = new int[,] {
		{1,1,1,1,1,1,1,1,1},
		{1,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,1},
	};

	// Use this for initialization
	void Start () {

		int row,col;

		for (row = 0; row < worldMap.GetLength(0); row++) {
			for (col = 0; col < worldMap.GetLength(1); col++){
				GameObject brick;
				if (worldMap [row,col]==1) {
					//Rotate brick 90 degree because sprite pivot point is on the bottom left
					if ((col == 0 || col == worldMap.GetLength(1)-1) && row != worldMap.GetLength(0)-1){
						brick = InstantiateBrick(row, col);
						if (col == worldMap.GetLength(1)-1) { 
							brick.transform.position = new Vector3 (col + 1.1f + xOffset, row + yOffset, 0);
						}
						brick.transform.Rotate(0f, 0f, 90f);
					}else{
						brick = InstantiateBrick(row, col);
					}
					brick.transform.parent = this.transform;
				}
			}
		}

		//Create remaining two empty boundaries using size of multi-dimensional array
		InstantiateBrick(0, 0).transform.parent = this.transform;
		InstantiateBrick(0, worldMap.GetLength(1)-1).transform.parent = this.transform;
	}

	GameObject InstantiateBrick(int row, int col) {
		return (GameObject)(Instantiate (wall, new Vector3 (col + xOffset, row + yOffset, 0),
											Quaternion.identity));;
	}
}
