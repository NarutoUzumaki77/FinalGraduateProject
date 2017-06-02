using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private GameObject parent;
    private Farmer farmer;
    private float speed;

	// Use this for initialization
	void Start () {
        parent = transform.parent.gameObject;
        farmer = parent.GetComponent<Farmer>();
        speed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        /*
        if (farmer.isFacingRight()){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
        }else{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
        }*/
	}
}
