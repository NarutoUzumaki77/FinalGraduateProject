using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{

	private float speed;
	private Animator anim;
	private bool foxjump = false;
	private bool isWalkingLeft = false;
	private bool isWalkingRight = true;
	private bool isWalkingUp = false;
	private bool isWalkingDown = false;
	private float delayTime = 1.0f;
	private GameObject child;
	private GameObject currentTarget;
	private int dirInt = 2;
	//private float newX;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		child = gameObject.transform.GetChild(0).gameObject;
		if (transform.position.x < 0) {
			foxjump = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
        /*
		//Restricting Player movement within boundaries
		newX = Mathf.Clamp(transform.position.x, 1.0f, 9.0f);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        if (newX <= 1.0f || newX >= 9.0f) {
			//anim.SetBool("isIdle", true);
            //InvokeRepeating("ChangeDirection", delayTime, delayTime);
            Invoke("ChangeDirection", delayTime);
        }*/

		if (!TimerLevel.isLevelComplete) {
			FoxMovement();
        }else {
            anim.SetBool("isIdle", true);
        }
	}

	private void FoxMovement(){
		if (isWalkingRight) {
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (isWalkingLeft) {
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}

		if (!isWalkingUp && !isWalkingLeft && !isWalkingDown && !isWalkingRight) {
			anim.SetBool("isIdle", true);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		GameObject obj = collision.gameObject;
		if (!obj.GetComponent<Fox>()) {
			if (obj.tag == "Brick" && foxjump) {
				foxjump = false;
				anim.SetBool("IsJumping", true);
			}
			else if (obj.tag == "Brick" && !foxjump) {
				anim.SetBool("isIdle", true);
				InvokeRepeating("ChangeDirection", delayTime, delayTime);
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision) {
		anim.SetBool("IsJumping", false);
		anim.SetBool("isIdle", false);
		CancelInvoke("ChangeDirection");
	}

	public void SetSpeed(float speed){
		this.speed = speed;
	}

	public void Attack(GameObject obj){
		anim.SetBool("IsAttacking", true);
		currentTarget = obj;
	}

	public void StopAttacking(){
		anim.SetBool("IsAttacking", false);
	}

	public void StrikeCurrentTarget(float damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.DoDamage(damage);
			}
		}
	}

	private void ChangeDirection(){
		string direction = "Right";
		dirInt = Random.Range(1, 4);
		switch (dirInt){
			case 1:
				//WalkingLeft
				isWalkingLeft = true;
				isWalkingRight = false;
				isWalkingUp = false;
				isWalkingDown = false;
				if (direction.Equals("Right")){
					child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
					 child.transform.localScale.y, child.transform.localScale.z);
					if (child.transform.localScale.x > 0){
						GetComponent<BoxCollider2D>().offset = new Vector2(-0.38f, -0.04888678f);
						direction = "Left";
					}
				}
				break;
			case 2:
				//WalkingRight
				isWalkingLeft = false;
				isWalkingRight = true;
				isWalkingUp = false;
				isWalkingDown = false;

				child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
					 child.transform.localScale.y, child.transform.localScale.z);
				if (child.transform.localScale.x < 0){
					GetComponent<BoxCollider2D>().offset = new Vector2(0.18f, -0.04888678f);
					direction = "Right";
				}

				break;
		}
	}
}