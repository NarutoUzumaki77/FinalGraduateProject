using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour {

	private static int timer;
	private float ftime;
	private Text timeText;

	// Use this for initialization
	void Start () {
		ftime = 100f;
		timeText = GameObject.Find("Time").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ftime -= Time.deltaTime;
		timer = (int)ftime;
		timeText.text = "000" + timer.ToString();
	}
}
