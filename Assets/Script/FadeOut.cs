using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();

		musicManager = GameObject.FindObjectOfType<MusicManager>();
		musicManager.ChangeVolume (PlayerPrefsManager.GetMasterVolume());

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime){
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		}else{
			gameObject.SetActive (false);
		}
	}
}
