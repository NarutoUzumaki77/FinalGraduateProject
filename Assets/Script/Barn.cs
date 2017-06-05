using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Barn : MonoBehaviour {

    public AudioClip questComplete;

    public void OnCollisionEnter2D(Collision2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Farmer>()){
            if (Score.pickedUpAllAnimal) {
                TimerLevel.isGameOver = true;
                obj.GetComponent<AudioSource>().clip = questComplete;
                obj.GetComponent<AudioSource>().Play();
                PCG_MazeBricks.mazePositions.Clear();
                obj.GetComponent<Animator>().SetBool("walking", false);
            }
        }
    }
}
