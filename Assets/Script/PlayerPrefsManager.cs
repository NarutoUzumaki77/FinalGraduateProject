using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
    const string HSCORE_KEY = "highest_score";

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}else {
			Debug.Log(volume);
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty (float diffulty) {
		if (diffulty >= 1 && diffulty <= 3) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, diffulty);
		}else{
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

    public static void SetHighestScore(int highscore) {
        if (highscore > 0) {
            PlayerPrefs.SetInt(HSCORE_KEY, highscore);
        }
    }

    public static float GetHighestScore() {
        return PlayerPrefs.GetInt(HSCORE_KEY, 0);
    }

}
