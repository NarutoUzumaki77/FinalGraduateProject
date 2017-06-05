using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAppleRewards : MonoBehaviour {

    private float frequency = 0.5f;
    private NonPlayableEntities npc;

	public GameObject reward;

	// Use this for initialization
	void Start () {
        npc = GameObject.FindObjectOfType<NonPlayableEntities>();
        InvokeRepeating("ProbabilityOfApple", 10f, 0.1f);
	}

    private void ProbabilityOfApple() {
		float probability = Time.deltaTime * frequency;
		if (Random.value < probability) {
			string position = npc.DetermineEntityDropPosition();
			string[] posArray = position.Split('|');
			float x = float.Parse(posArray[0]);
			float y = float.Parse(posArray[1]);
            GameObject apple = Instantiate(reward, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
		}
        if (TimerLevel.isGameOver) {
            CancelInvoke("ProbabilityOfApple");
        }
    }
}
