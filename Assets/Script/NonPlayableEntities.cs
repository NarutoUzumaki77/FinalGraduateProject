﻿using UnityEngine;
using System.Collections;

public class NonPlayableEntities : MonoBehaviour {

	public GameObject barn;
    public GameObject[] entity;

    private int npeSize;

	// Use this for initialization
	void Start () {
        npeSize = entity.Length * Mathf.RoundToInt(PlayerPrefsManager.GetDifficulty());

        for (int i = 0; i < npeSize; i++){
            string position = DetermineEntityDropPosition();
            string[] posArray = position.Split('|');
            float x = float.Parse(posArray[0]);
            float y = float.Parse(posArray[1]);
            int index = Mathf.RoundToInt(Random.Range(0f, 1f));
            GameObject npc = Instantiate(entity[index], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            npc.transform.parent = this.transform;
        }

        //Generate Barn
        Instantiate(barn, new Vector3(9f, 1f), Quaternion.identity);

        foreach(string nn in PCG_MazeBricks.mazePositions){
            Debug.Log(nn); 
        }

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
        PCG_MazeBricks.mazePositions.Add(position);

        return position;
    }
}
