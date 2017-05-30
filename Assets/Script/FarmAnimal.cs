using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimal : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Fox>()){
            obj.GetComponent<Fox>().Attack(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		GameObject obj = collision.gameObject;
		if (obj.GetComponent<Fox>())
		{
			obj.GetComponent<Fox>().StopAttacking();
		}
	}
}
