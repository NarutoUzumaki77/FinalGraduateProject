﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour {

    private Animator anim;
    private float speed = 1.0f;
    private bool isFacingLeft;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMovingUp;
    private bool isMovingDown;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isFacingLeft = true;
        isMovingLeft = true;
        isMovingRight = true;
        isMovingUp = true;
        isMovingDown = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow)){
            if (!isFacingLeft){
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                isFacingLeft = true;
            }
            if (isMovingLeft) {
				anim.SetBool("walking", true);
				transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)){
			if (isFacingLeft){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                isFacingLeft = false;
			}
            if (isMovingRight) {
				anim.SetBool("walking", true);
				transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && isMovingUp) {
            anim.SetBool("walking", true);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) && isMovingDown) {
            anim.SetBool("walking", true);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
                || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
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
	}

    private void OnCollisionExit2D(Collision2D collision) {
        isMovingLeft = true;
        isMovingRight = true;
		isMovingUp = true;
		isMovingDown = true;
    }
}
