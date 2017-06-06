using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	private int animalCountInt;
	private int score;
	private int level_number;
	private NonPlayableEntities npc;
    private GenerateFox generatefox;
	private PCG_MazeBricks maze;

	private Text level;
    private Text levelSummary;
    private Text scoreSummary;
    private Text highScoreSummary;

    private GameObject pcg_MazeBricks;
    private GameObject nonplayableEntities;
    private GameObject gfox;
    private GameObject gamesummary;

	public static bool pickedUpAllAnimal = false;
    public float summaryViewTime = 5f;

	// Use this for initialization
	void Start() {
        pcg_MazeBricks = GameObject.Find("PCG_MazeBricks");
        maze = pcg_MazeBricks.GetComponent<PCG_MazeBricks>();

        nonplayableEntities = GameObject.Find("NonPlayableEntities");
        npc = pcg_MazeBricks.GetComponent<NonPlayableEntities>();

        gfox = GameObject.Find("GenerateFox");
        generatefox = pcg_MazeBricks.GetComponent<GenerateFox>();

		gamesummary = GameObject.Find("GameSummary");
        levelSummary = GameObject.Find("LevelInt").GetComponent<Text>();
        scoreSummary = GameObject.Find("ScoreInt").GetComponent<Text>();
        highScoreSummary = GameObject.Find("HighScoreInt").GetComponent<Text>();
        gamesummary.SetActive(false);

		level_number = 1;
		level = GameObject.Find("Level").GetComponent<Text>();
		level.text = level_number.ToString();
		animalCountInt = 0;
	}

	private void Update() {
		if (FarmAnimal.animalCount.Equals(animalCountInt)) {
			pickedUpAllAnimal = true;
		}
	}

    public void StopPlay() {
		calculateScore();

		//Disable fox, maze and FarmAnimal
		if (pcg_MazeBricks.activeSelf){
				SetGameObjectVisibility(false);
		}
		Invoke("RecycleGame", summaryViewTime);
    }

    private void SetGameObjectVisibility(bool isActive) {
        pcg_MazeBricks.SetActive(isActive);
		gfox.SetActive(isActive);
		nonplayableEntities.SetActive(isActive);
        gamesummary.SetActive(!isActive);
	}

	public int GetAnimalCount() {
		return animalCountInt;
	}

	public void SetAnimalCount() {
		animalCountInt++;
		if (FarmAnimal.animalCount.Equals(animalCountInt)) {
			pickedUpAllAnimal = true;
		}
	}

	public void ResetAnimalCount() {
		animalCountInt = 0;
		FarmAnimal.animalCount = 0;
		level_number++;
		level.text = level_number.ToString();
	}

	private void calculateScore() {
        score = (TimerLevel.timer * animalCountInt) + Projectile.foxCount; 
        scoreSummary.text = score.ToString();
        levelSummary.text = level_number.ToString();
        // Add high Score from ManagerPref
	}

	private void RecycleGame() {

        TimerLevel.isLevelComplete = false;
        TimerLevel.ftime = 120f;
        level_number++;
        level.text = level_number.ToString();

		ResetAnimalCount();

        ClearChildGameObjects(pcg_MazeBricks);
        ClearChildGameObjects(nonplayableEntities);
        ClearChildGameObjects(gfox);
		PCG_MazeBricks.mazePositions.Clear();

        //regenerate maze, fox and farmanimals
        maze.GenerateMaze(); // maze
        //npc.GenerateNPC(); //FarmAnimals
        //generatefox.InstantiateFox(); // fox

		//Enable fox, maze and FarmAnimal
		if (!pcg_MazeBricks.activeSelf) {
			SetGameObjectVisibility(true);
		}

		pickedUpAllAnimal = false;
	}

    private void ClearChildGameObjects(GameObject obj) {
        int k = obj.transform.childCount;
        for (int i = 0; i < k; i++) {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }
}