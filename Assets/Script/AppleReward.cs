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
        GameObject obj = collision.gameObject;
        if (collision.gameObject.GetComponent<Farmer>()) {
            Farmer.projectileCounter += 2;
            appleCounter.text = Farmer.projectileCounter.ToString();
            Destroy(gameObject);
            npc.RemovePositionFromGrid(obj);
        }
    }

	public void Update()
	{
		timer -= Time.deltaTime;
		timerInt = (int)timer;
		if (timerInt <= 0)
		{
            Destroy(gameObject);
		}
	}
}
