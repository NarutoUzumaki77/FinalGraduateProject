using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private ScoreKeeper score;
    private LevelManager lm;

	private Text levelSummary;
	private Text scoreSummary;
	private Text highScoreSummary;
    private Text congrats;

    // Use this for initialization
    void Start(){
		congrats = GameObject.Find("Congrats").GetComponent<Text>();
        score = GameObject.FindObjectOfType<ScoreKeeper>();
        lm = GameObject.FindObjectOfType<LevelManager>();

        if (score) {
            score.SetHighScore(score.GetScore());
            DisplayScoreSummary();
        }else {
            Debug.LogError("Score Keeper not Found");
        }
    }

    private void DisplayScoreSummary() {
		levelSummary = GameObject.Find("LevelInt").GetComponent<Text>();
		scoreSummary = GameObject.Find("ScoreInt").GetComponent<Text>();
		highScoreSummary = GameObject.Find("HighScoreInt").GetComponent<Text>();

        int level = score.GetLevel();
        if (level <= 0) {
            level = 1;
        }
        levelSummary.text = level.ToString();
        scoreSummary.text = score.GetScore().ToString();
        highScoreSummary.text = PlayerPrefsManager.GetHighestScore().ToString();

        if (score.GetScore() >= PlayerPrefsManager.GetHighestScore()) {
            congrats.text = "Congratulations!!! You set a new High Score";
        }else {
            congrats.text = "";
        }
    }

    public void PlayAgain (string level) {
        //New Player plays with fresh score
        score.ResetScore();
        lm.LoadRequestedLevel(level);
    }
}
