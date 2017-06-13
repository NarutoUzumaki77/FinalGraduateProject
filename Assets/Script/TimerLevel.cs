using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour {
    
	private Text timeText;
	private Text level;
    private int level_number;

    public static bool isGameOver;
    public static bool isLevelComplete;
	public static int timer;
	public static float ftime;

	// Use this for initialization
	void Start() {
		ftime = 120f;
		timeText = GameObject.Find("Time").GetComponent<Text>();
        isLevelComplete = false;
		level_number = 1;
		level = GameObject.Find("Level").GetComponent<Text>();
		level.text = level_number.ToString();
	}

	// Update is called once per frame
	void Update() {
        if (!isLevelComplete) {
			ftime -= Time.deltaTime;
			timer = (int)ftime;
			timeText.text = "000" + timer.ToString();
		}
	}

    public void SetLevel () {
        level_number = level_number + 1;
        level.text = level_number.ToString();
    }

    public int GetLevel () {
        return level_number;
    }
}