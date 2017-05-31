using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public int splashscreentime;
    public int level_number = 1;

    private string main_level = "Game_Stage";

	// Use this for initialization
	void Start () {
		if (splashscreentime >= 1) {
			Invoke ("LoadNextLevel", splashscreentime);
		}
	}

	public void LoadRequestedLevel(string level) {
        if (SceneManager.GetSceneByName(main_level).Equals(main_level)){
            level_number++;
            Debug.Log("add to the level number");
        }
        SceneManager.LoadScene(level);
	}

	public void LoadNextLevel() {
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
	}

    public int GetLevelNumber(){
        return level_number;
    }
}
