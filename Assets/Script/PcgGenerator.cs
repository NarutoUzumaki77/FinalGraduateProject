using UnityEngine;
using UnityEngine.UI;

public class PcgGenerator : MonoBehaviour
{

	private int animalCountInt;
	private NonPlayableEntities npc;
    private GenerateFox generatefox;
	private PCG_MazeBricks maze;
	private GenerateAppleRewards geneAppleRewards;
    private TimerLevel level;
    private ScoreKeeper scorekeeper;

    private Text animalCount;

    private GameObject pcg_MazeBricks;
    private GameObject nonplayableEntities;
    private GameObject gfox;
    private GameObject gamesummary;

	public static bool pickedUpAllAnimal = false;
    public float summaryViewTime = 5f;

	// Use this for initialization
	void Start() {

        scorekeeper = GameObject.FindObjectOfType<ScoreKeeper>();
        geneAppleRewards = GameObject.FindObjectOfType<GenerateAppleRewards>();
        level = GameObject.FindObjectOfType<TimerLevel>();

        pcg_MazeBricks = GameObject.Find("PCG_MazeBricks");
        maze = pcg_MazeBricks.GetComponent<PCG_MazeBricks>();

        nonplayableEntities = GameObject.Find("NonPlayableEntities");
        npc = nonplayableEntities.GetComponent<NonPlayableEntities>();

		gfox = GameObject.Find("GenerateFox");
		generatefox = gfox.GetComponent<GenerateFox>();

		gamesummary = GameObject.Find("GameSummary");
        gamesummary.SetActive(false);

        animalCount = GameObject.Find("AnimalCount").GetComponent<Text>();
		animalCountInt = 0;
	}

	private void Update() {
		if (FarmAnimal.animalCount.Equals(animalCountInt)) {
			pickedUpAllAnimal = true;
		}
	}

    public void StopPlay() {
		scorekeeper.calculateScore();
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
        animalCount.text = animalCountInt.ToString();
		FarmAnimal.animalCount = 0;
	}

	private void RecycleGame() {

		pickedUpAllAnimal = false;
        TimerLevel.isLevelComplete = false;
        TimerLevel.ftime = 120f;
        level.SetLevel();

		ResetAnimalCount();

        ClearChildGameObjects(pcg_MazeBricks);
        ClearChildGameObjects(nonplayableEntities);
        ClearChildGameObjects(gfox);
		PCG_MazeBricks.mazePositions.Clear();

		//Enable fox, maze and FarmAnimal
		if (!pcg_MazeBricks.activeSelf) {
			SetGameObjectVisibility(true);
		}

        //regenerate maze, fox and farmanimals
        maze.GenerateMaze(); // maze
        npc.GenerateNPC(); //FarmAnimals
        generatefox.InstantiateFox(); // fox
        geneAppleRewards.GenerateApples();

	}

    private void ClearChildGameObjects(GameObject obj) {
        int k = obj.transform.childCount;
        for (int i = 0; i < k; i++) {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }
}