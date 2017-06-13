using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleReward : MonoBehaviour {

	private Text appleCounter;
    private NonPlayableEntities npc;
    private int timerInt;

    public float timer = 7.0f;

    private void Start() {
        appleCounter = GameObject.Find("AppleCountText").GetComponent<Text>();
        appleCounter.text = Farmer.projectileCounter.ToString();
        npc = GameObject.FindObjectOfType<NonPlayableEntities>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Farmer>()) {
            Farmer.projectileCounter += 2;
            appleCounter.text = Farmer.projectileCounter.ToString();
			npc.RemovePositionFromGrid(gameObject);
            Destroy(gameObject);
        }
    }

	public void Update() {
        if (!TimerLevel.isLevelComplete) {
			timer -= Time.deltaTime;
			timerInt = (int)timer;
			if (timerInt <= 0 && gameObject) {
				Destroy(gameObject);
			}
        }else {
            Destroy(gameObject);
        }
	}
}
