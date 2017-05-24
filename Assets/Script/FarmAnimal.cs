using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimal : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Fox>()){
            collision.GetComponent<Fox>().Attack(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
		if (collision.GetComponent<Fox>()) {
            collision.GetComponent<Fox>().StopAttacking();
        }
    }

}
