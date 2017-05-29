using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour {

    private GameObject child;
    private Animator anim;
    private float speed = 1.5f;
    private bool isFacingLeft;

	// Use this for initialization
	void Start () {
        child = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        isFacingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow)){
            if (!isFacingLeft){
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                isFacingLeft = true;
            }
            anim.SetBool("walking", true);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow)){
			if (isFacingLeft){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                isFacingLeft = false;
			}   
            anim.SetBool("walking", true);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //Going Up

        //Going Down

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.SetBool("walking", false);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject obj = collision.gameObject;
        Debug.Log(obj);
    }
}
