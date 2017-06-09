using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private Score score;

	// Use this for initialization
	void Start () {
        score = GameObject.FindObjectOfType<Score>();
        if (score){
            Debug.Log("score found"); 
        } else {
            Debug.Log("score not found"); 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
