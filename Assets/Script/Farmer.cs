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
    private Score score;
    private GameObject shoot;

    public AudioClip snatchAnimalSound;
    public GameObject projectile;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        score = GetComponent<Score>();
        animalCountText = GameObject.Find("AnimalCount").GetComponent<Text>();
        shoot = GameObject.Find("Shoot");
        sound.volume = PlayerPrefsManager.GetMasterVolume();
        isFacingLeft = true;
        isMovingLeft = true;
        isMovingRight = true;
        isMovingUp = true;
        isMovingDown = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!TimerLevel.isGameOver) {
            FarmerMovement();
        }
	}

    private void FarmerMovement (){

        if (Input.GetKeyDown(KeyCode.F)) {

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
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (isFacingLeft){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				isFacingLeft = false;
			}
			if (isMovingRight){
				anim.SetBool("walking", true);
				transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
		}

		if (Input.GetKey(KeyCode.UpArrow) && isMovingUp){
			anim.SetBool("walking", true);
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.DownArrow) && isMovingDown){
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

        RescueFarmAnimals(obj);
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
            score.SetAnimalCount();
            animalCountText.text = score.GetAnimalCount().ToString();
        }
    }

    public bool isFacingRight() {
        return !isFacingLeft;
    }
}
