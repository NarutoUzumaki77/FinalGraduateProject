using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    private float speed;
    private Animator anim;
    private bool foxjump = true;
    private bool isWalkingLeft = false;
    private bool isWalkingRight = true;
    private bool isWalkingUp = false;
    private bool isWalkingDown = false;
    private float delayTime = 2.0f;
    private GameObject child;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        child = gameObject.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (isWalkingRight){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (isWalkingLeft){
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision) {

        GameObject obj = collision.gameObject;
        if (obj.tag == "Brick" && foxjump) {
            foxjump = false;
            anim.SetBool("IsJumping", true);
        }else if (obj.tag == "Brick" && !foxjump) {
            anim.SetBool("isIdle", true);
            //Invoke("ChangeDirection", delayTime);
            InvokeRepeating("ChangeDirection", delayTime, delayTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        anim.SetBool("IsJumping", false);
        anim.SetBool("isIdle", false);
        CancelInvoke("ChangeDirection");
    }

    public void SetSpeed (float speed) {
        this.speed = speed;
    }

    private void ChangeDirection() {

        int dir = 0;
        dir = Random.Range(1, 4);
        Debug.Log(dir);
        switch (dir){
            case 1:
                isWalkingLeft = true;
                isWalkingRight = false;
                isWalkingUp = false;
                isWalkingDown = false;
                child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
                                                        child.transform.localScale.y, child.transform.localScale.z);
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.3f, -0.04888678f);
                break;
            case 2:
                if (isWalkingLeft){
					child.transform.localScale = new Vector3(child.transform.localScale.x * -1,
										child.transform.localScale.y, child.transform.localScale.z);
                    GetComponent<BoxCollider2D>().offset = new Vector2(-0.07398391f, -0.04888678f);
                }
                isWalkingLeft = false;
				isWalkingRight = true;
				isWalkingUp = false;
				isWalkingDown = false;
				break;
			case 3:
                isWalkingLeft = false;
				isWalkingRight = false;
				isWalkingUp = true;
				isWalkingDown = false;
				break;
			case 4:
				isWalkingLeft = false;
                isWalkingRight = false;
				isWalkingUp = false;
				isWalkingDown = true;
				break;
		}
    }
}
