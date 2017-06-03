using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleReward : MonoBehaviour {

	private Text appleCounter;

    private void Start() {
        appleCounter = GameObject.Find("AppleCountText").GetComponent<Text>();
        appleCounter.text = Farmer.projectileCounter.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Farmer>()) {
            Farmer.projectileCounter += 2;
            appleCounter.text = Farmer.projectileCounter.ToString();
            Destroy(gameObject);
        }
    }
}
