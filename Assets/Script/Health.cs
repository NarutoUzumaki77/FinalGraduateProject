using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;
    public Sprite [] healthBar;

    private GameObject parent;
    private int childcount;
	private NonPlayableEntities npc;

    private void Start() {
        npc = GameObject.FindObjectOfType<NonPlayableEntities>();
    }

    public void DoDamage(float damage) {
        health -= damage;
		parent = gameObject.transform.parent.gameObject;
		childcount = parent.transform.childCount;
        if (health <= 0) {
            if (parent){
                Destroy(parent);
            }
			FarmAnimal.animalCount -= 1;
            Destroy(gameObject);
			npc.RemovePositionFromGrid(parent);
        }else {
            SwitchHealthBar();
        }
    }

    private void SwitchHealthBar(){
		for (int i = 0; i < childcount; i++) {
            GameObject obj = parent.transform.GetChild(i).gameObject;
            if (!obj.GetComponent<FarmAnimal>()){
                if (health <= 400 && health > 300){
                    obj.GetComponent<SpriteRenderer>().sprite = healthBar[0];
                } else if (health <= 300 && health > 200){
                    obj.GetComponent<SpriteRenderer>().sprite = healthBar[1];
                } else if (health <= 200 && health > 100){
                    obj.GetComponent<SpriteRenderer>().sprite = healthBar[2];
                } else if (health <= 100 && health > 0){
                    obj.GetComponent<SpriteRenderer>().sprite = healthBar[3];
                }
            }
		}
    }
}
