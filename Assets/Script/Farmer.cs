using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Farmer : MonoBehaviour {

    private Animator anim;
    private float speed = 1.0f;
    private bool isFacingLeft;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMovingUp;
    private bool isMovingDown;
    private AudioSource sound;
	private Text animalCountText;
    private Text appleCounter;
    private PcgGenerator generator;
    private GameObject shoot;
	private float newX;
	private float newY;
	private NonPlayableEntities npc;
    private LevelManager levelManager;

    public AudioClip snatchAnimalSound;
    public GameObject projectile;

    public static int projectileCounter;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        generator = GetComponent<PcgGenerator>();
        animalCountText = GameObject.Find("AnimalCount").GetComponent<Text>();
        appleCounter = GameObject.Find("AppleCountText").GetComponent<Text>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        shoot = GameObject.Find("Shoot");
        npc = GameObject.FindObjectOfType<NonPlayableEntities>();
        sound.volume = PlayerPrefsManager.GetMasterVolume();
        projectileCounter = 0;
        isFacingLeft = true;
        isMovingLeft = true;
        isMovingRight = true;
        isMovingUp = true;
        isMovingDown = true;
	}

    void Update()
    {
        //Restricting Player movement within boundaries
        newX = Mathf.Clamp(transform.position.x, 1.0f, 9.0f);
        newY = Mathf.Clamp(transform.position.y, 1.0f, 5.0f);
        transform.position = new Vector3(newX, newY, transform.position.z);

        if (!TimerLevel.isLevelComplete) {
            FarmerMovement();
        }
    }

    private void FarmerMovement (){

        if (Input.GetKeyDown(KeyCode.F) && projectileCounter > 0) {

            projectileCounter -= 1;
            appleCounter.text = projectileCounter.ToString();
            GameObject child = transform.gameObject;
            for (int x = 0; x < transform.childCount; x++){
                if (!transform.GetChild(x).GetComponent<SpriteRenderer>()) {
                    child = transform.GetChild(x).gameObject;
                }
            }
            GameObject newProjectile = Instantiate(projectile, child.transform.position, Quaternion.identity) as GameObject;
            newProjectile.transform.parent = shoot.transform;
        }

		if (Input.GetKey(KeyCode.LeftArrow)){
			if (!isFacingLeft){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				isFacingLeft = true;
			}
			if (isMovingLeft){
				anim.SetBool("walking", true);
				transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			if (isFacingLeft){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				isFacingLeft = false;
			}
			if (isMovingRight){
				anim.SetBool("walking", true);
				transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
		} else if (Input.GetKey(KeyCode.UpArrow) && isMovingUp){
			anim.SetBool("walking", true);
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}else if (Input.GetKey(KeyCode.DownArrow) && isMovingDown){
			anim.SetBool("walking", true);
			transform.Translate(Vector3.down * speed * Time.deltaTime);
		} 

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
				|| Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)){
			anim.SetBool("walking", false);
		}        
    }

	private void OnCollisionEnter2D(Collision2D collision){
		GameObject obj = collision.gameObject;
		if (obj.tag == "Brick") {
            if (isFacingLeft){
                isMovingLeft = false;
            } else if (!isFacingLeft) {
                isMovingRight = false;
            }
            isMovingUp = false;
            isMovingDown = false;
		}

        if (obj.GetComponent<Fox>()) {
            TimerLevel.isLevelComplete = true;
            anim.SetBool("walking", false);
            Invoke("GameOver", 2f);
        }
        RescueFarmAnimals(obj);
	}

    private void GameOver() {
        generator.ResetAnimalCount();
        levelManager.LoadNextLevel();
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isMovingLeft = true;
        isMovingRight = true;
		isMovingUp = true;
		isMovingDown = true;
    }

    private void RescueFarmAnimals (GameObject animal) {
        if (animal.GetComponent<FarmAnimal>()) {
            sound.clip = snatchAnimalSound;
            sound.Play();
            GameObject parent = animal.transform.parent.gameObject;
            Destroy(parent);
            npc.RemovePositionFromGrid(parent);
            generator.SetAnimalCount();
            animalCountText.text = generator.GetAnimalCount().ToString();
            Debug.Log(generator.GetAnimalCount());
            Debug.Log(FarmAnimal.animalCount); 
            Debug.Log("");
        }
    }

    public bool isFacingLeftM() {
        return isFacingLeft;
    }
}
