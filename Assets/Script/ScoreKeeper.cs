﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text levelSummary;
	private Text scoreSummary;
	private Text highScoreSummary;
	private int score = 0;
	private TimerLevel level;
    private PcgGenerator pcg;
    private int level_number;

    static ScoreKeeper instance = null;

	// Use this for initialization
	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

    private void Start() {
        pcg = GameObject.FindObjectOfType<PcgGenerator>();
        level = GameObject.FindObjectOfType<TimerLevel>();
		levelSummary = GameObject.Find("LevelInt").GetComponent<Text>();
		scoreSummary = GameObject.Find("ScoreInt").GetComponent<Text>();
		highScoreSummary = GameObject.Find("HighScoreInt").GetComponent<Text>();
    }

    public void calculateScore() {
        score += (TimerLevel.timer * pcg.GetAnimalCount()) + Projectile.foxCount;
        SetHighScore(score);
		scoreSummary.text = score.ToString();
		levelSummary.text = level.GetLevel().ToString();
		highScoreSummary.text = PlayerPrefsManager.GetHighestScore().ToString();
        level_number = level.GetLevel();
	}
	
    public void SetHighScore(int score) {
        if (score > PlayerPrefsManager.GetHighestScore()) {
            PlayerPrefsManager.SetHighestScore(score);
        }
    }

    public int GetScore() {
        return score;
    }

	public void ResetScore(){
		score = 0;
	}

    public int GetLevel() {
        return level_number;
    }
}
