using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFox : MonoBehaviour {

    public GameObject fox;
    public int foxCount;

	private NonPlayableEntities npc;

	// Use this for initialization
	void Start () {
        npc = GameObject.FindObjectOfType<NonPlayableEntities>();
        for (int i = 1; i <= foxCount; i++) {
			string position = npc.DetermineEntityDropPosition();
			string[] posArray = position.Split('|');
			float x = float.Parse(posArray[0]);
			float y = float.Parse(posArray[1]);
            GameObject obj = Instantiate(fox, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            obj.transform.parent = transform;
        }
     }
}
