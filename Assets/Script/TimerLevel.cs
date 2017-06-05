using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour {

	private static int timer;
	private float ftime;
	private Text timeText;

    public static bool isGameOver;

	// Use this for initialization
	void Start () {
		ftime = 100f;
		timeText = GameObject.Find("Time").GetComponent<Text>();
        isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isGameOver) {
			ftime -= Time.deltaTime;
			timer = (int)ftime;
			timeText.text = "000" + timer.ToString(); 
        }
	}
}
