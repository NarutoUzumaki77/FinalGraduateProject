using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Barn : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Farmer>()){
            if (Score.pickedUpAllAnimal) {
                TimerLevel.isGameOver = true;
                obj.GetComponent<Animator>().SetBool("walking", false);
            }
        }
    }
}
