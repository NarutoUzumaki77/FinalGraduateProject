using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Barn : MonoBehaviour{

	public AudioClip questComplete;

    public void OnCollisionEnter2D(Collision2D collision) {
		GameObject obj = collision.gameObject;
		if (obj.GetComponent<Farmer>()) {
            if (PcgGenerator.pickedUpAllAnimal) {
                PcgGenerator.pickedUpAllAnimal = false;
				TimerLevel.isLevelComplete = true;
                obj.GetComponent<PcgGenerator>().StopPlay();
				obj.GetComponent<AudioSource>().clip = questComplete;
				obj.GetComponent<AudioSource>().Play();
				PCG_MazeBricks.mazePositions.Clear();
				obj.GetComponent<Animator>().SetBool("walking", false);
                if (PlayerPrefsManager.GetDifficulty() > 1) {
                    Farmer.projectileCounter = 0;
                }
			}
		}
        Debug.Log(PcgGenerator.pickedUpAllAnimal); 
	}
}