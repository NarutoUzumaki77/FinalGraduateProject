using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDiffAdjustment : MonoBehaviour {

    public int beginner;
    public int intermidate;
    public int professional;

    private int time;
    private float diff_level;

	// Use this for initialization
	void Start () {
		diff_level = PlayerPrefsManager.GetDifficulty();
        FetchAndSetDDA(InitialDifficulty());
	}
	
    public void FetchAndSetDDA(int time) {
		diff_level = PlayerPrefsManager.GetDifficulty();
        this.time = time; 
    }

    private void SetDynamicDifficulty() {
        if (time >= beginner && time < intermidate) {
            PlayerPrefsManager.SetDifficulty(1.0f);
        }else if (time >= intermidate && time < professional){
            PlayerPrefsManager.SetDifficulty(2.0f);
        }else if (time > professional && (int)diff_level != 1) { //Avoids a situation where a player jumps from beginner to professional
            PlayerPrefsManager.SetDifficulty(3.0f);
        }else {
            PlayerPrefsManager.SetDifficulty(2.0f);
        }
    }

    private int InitialDifficulty() {
        int levelTime = 0;
        if ((int)diff_level == 1){
            levelTime = beginner;
        }else if ((int)diff_level == 2){
            levelTime = intermidate;
        }else if ((int)diff_level == 3) {
            levelTime = professional;
        }
        return levelTime;
    }
}
