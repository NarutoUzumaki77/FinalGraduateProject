using UnityEngine;
using System.Collections;

public class NonPlayableEntities : MonoBehaviour {
    
    public GameObject[] entity;

    private int npeSize;

	// Use this for initialization
	void Start () {
        npeSize = entity.Length * 2;

        for (int i = 0; i < npeSize; i++){
            string position = DetermineEntityDropPosition();
            string[] posArray = position.Split('|');
            print(position); 
            float x = float.Parse(posArray[0]);
            float y = float.Parse(posArray[1]);
            Instantiate(entity[0], new Vector3(x, y, 0f), Quaternion.identity);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        //print("Collided with " + collision.gameObject.tag);
    }

    private string DetermineEntityDropPosition() {

        bool posFoundinList = false;
        string position = null;

        do
        {
            posFoundinList = false;
			int x = Mathf.RoundToInt(Random.Range(1, 9));
			int y = Mathf.RoundToInt(Random.Range(1, 5));
            position = x + "|" + y;

			foreach (string item in PCG_MazeBricks.mazePositions) {
                if (item.Equals(position)){
                    posFoundinList = true;   
                }
			}
        } while (posFoundinList);

        return position;

    }
}
