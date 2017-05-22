﻿using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    private float speed;
    private Animator anim;
    private bool foxjump = true;
    private bool isWalkingLeft = false;
    private bool isWalkingRight = true;
    private bool isWalkingUp = false;
    private bool isWalkingDown = false;
    private float delayTime = 1.0f;
    private GameObject child;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        child = gameObject.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (isWalkingRight){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } if (isWalkingLeft){
			transform.Translate(Vector3.left * speed * Time.deltaTime);
        } if (isWalkingDown && transform.position.y >= 1.2f){
            transform.Translate((Vector3.down * (speed * 0.5f) * Time.deltaTime));
            if (transform.position.y <= 1.2f){
				Invoke("ChangeDirection", delayTime);
            }
        } if (isWalkingUp && transform.position.y <= 5.2f) {
            transform.Translate((Vector3.up * (speed * 0.5f) * Time.deltaTime));
			if (transform.position.y >= 5.2f) {
				Invoke("ChangeDirection", delayTime);
			}           
        }

        if (!isWalkingUp && !isWalkingLeft && !isWalkingDown && !isWalkingRight) {
            anim.SetBool("isIdle", true);
        } 
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Brick" && foxjump) {
            foxjump = false;
            anim.SetBool("IsJumping", true);
        }else if (obj.tag == "Brick" && !foxjump) {
            anim.SetBool("isIdle", true);
            InvokeRepeating("ChangeDirection", delayTime, delayTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        anim.SetBool("IsJumping", false);
        anim.SetBool("isIdle", false);
        CancelInvoke("ChangeDirection");
    }

    public void SetSpeed (float speed) {
        this.speed = speed;
    }

    private void ChangeDirection() {
        int dirInt = 0;
        string direction = "Right";
        dirInt = Random.Range(1, 4);
        Debug.Log(dirInt);
        switch (dirInt){
            case 1:
                //WalkingLeft
                isWalkingLeft = true;
                isWalkingRight = false;
                isWalkingUp = false;
                isWalkingDown = false;
                if (direction.Equals("Right")) {
					direction = "Left";
					GetComponent<BoxCollider2D>().offset = new Vector2(-0.38f, -0.04888678f);
					child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
										 child.transform.localScale.y, child.transform.localScale.z);
                }
                break;
            case 2:
                //WalkingRight
                isWalkingLeft = false;
				isWalkingRight = true;
				isWalkingUp = false;
				isWalkingDown = false;
                if (direction.Equals("Left")) {
					direction = "Right";
					GetComponent<BoxCollider2D>().offset = new Vector2(0.18f, -0.04888678f);
					child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
										child.transform.localScale.y, child.transform.localScale.z);
                }
				break;
			case 3:
                isWalkingLeft = false;
				isWalkingRight = false;
				isWalkingUp = true;
				isWalkingDown = false;
				break;
			case 4:
				isWalkingLeft = false;
                isWalkingRight = false;
				isWalkingUp = false;
				isWalkingDown = true;
				break;
		}
        Debug.Log(direction); 
    }
}
