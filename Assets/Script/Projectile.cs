using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Farmer farmer;
    private float speed;
    private float damage = 50f;

	// Use this for initialization
	void Start () {
        farmer = GameObject.FindObjectOfType<Farmer>();
        speed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(Vector3.left * speed * Time.deltaTime);
		
        if (farmer.isFacingLeftM()){
			transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.GetComponent<Barn>()) {
            if (collision.gameObject.GetComponent<FarmAnimal>()) {
                Health health = collision.gameObject.GetComponent<Health>();
				if (health) {
					health.DoDamage(damage);
				}
            } else if (collision.gameObject.GetComponent<Fox>()){
                Destroy(collision.gameObject);
            }
			Destroy(gameObject);
        }
    }
}
