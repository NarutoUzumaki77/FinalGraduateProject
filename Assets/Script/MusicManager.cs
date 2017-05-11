using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	static MusicManager instance = null; 

	// Use this for initialization
	void Awake () {
		if (instance != null){
			Destroy (gameObject);
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	public void ChangeVolume(float volume) {
		instance.GetComponent<AudioSource>().volume = volume;
	}
}
