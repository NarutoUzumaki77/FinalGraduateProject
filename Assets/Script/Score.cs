using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int animalCountInt;
	private LevelManager lm;
	private Text level;

    public static bool pickedUpAllAnimal = false;

	// Use this for initialization
	void Start()
	{
		lm = FindObjectOfType<LevelManager>();
		level = GameObject.Find("Level").GetComponent<Text>();
		level.text = lm.GetLevelNumber().ToString();
		animalCountInt = 0;
	}

	public int GetAnimalCount() {
		return animalCountInt;
	}

	public void SetAnimalCount(){
		animalCountInt++;
		if (FarmAnimal.animalCount.Equals(animalCountInt)){
            pickedUpAllAnimal = true;
		}
	}

	public void ResetAnimalCount(){
		animalCountInt = 0;
		FarmAnimal.animalCount = 0;
	}

	private void Update(){
		if (FarmAnimal.animalCount.Equals(animalCountInt)) {
			pickedUpAllAnimal = true;
		}
	}
}
