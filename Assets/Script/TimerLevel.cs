using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour {
    
	private Text timeText;

    public static bool isGameOver;
    public static bool isLevelComplete;
	public static int timer;
	public static float ftime;

	// Use this for initialization
	void Start() {
		ftime = 120f;
		timeText = GameObject.Find("Time").GetComponent<Text>();
        isLevelComplete = false;
        isGameOver = false;
	}

	// Update is called once per frame
	void Update() {
        if (!isLevelComplete) {
			ftime -= Time.deltaTime;
			timer = (int)ftime;
			timeText.text = "000" + timer.ToString();
		}
	}
}