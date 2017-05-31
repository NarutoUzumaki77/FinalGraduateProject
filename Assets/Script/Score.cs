using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int animalCountInt = 0;
    private LevelManager lm;
	private Text level;

	// Use this for initialization
	void Start () {
        lm = FindObjectOfType<LevelManager>();
        level = GameObject.Find("Level").GetComponent<Text>();
	}

    public int GetAnimalCount() {
        return animalCountInt;
    }

    public void SetAnimalCount() {
        animalCountInt++;
        if (FarmAnimal.animalCount == animalCountInt) {
            lm.LoadRequestedLevel("Game_Stage");
			level.text = lm.GetLevelNumber().ToString();
            ResetAnimalCount();
        }
    }

    public void ResetAnimalCount () {
        animalCountInt = 0;
        FarmAnimal.animalCount = 0;
    }
}
