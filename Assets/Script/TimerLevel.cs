using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour {
    
	private Text timeText;
	private Text level;
    private int level_number;
	private PcgGenerator generator;
    private LevelManager levelManager;

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
        generator = GameObject.FindObjectOfType<PcgGenerator>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update() {
        if (!isLevelComplete) {
			ftime -= Time.deltaTime;
			timer = (int)ftime;
            CheckifTimerisZero();
			timeText.text = "000" + timer.ToString();
		}
	}

    private void CheckifTimerisZero() {
        if (timer <= 0) {
            isLevelComplete = true;
			generator.ResetAnimalCount();
			levelManager.LoadNextLevel();
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