using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public int splashscreentime;

	// Use this for initialization
	void Start()
	{
		if (splashscreentime >= 1)
		{
			Invoke("LoadNextLevel", splashscreentime);
		}
	}

	public void LoadRequestedLevel(string level)
	{
		SceneManager.LoadScene(level);
	}

	public void LoadNextLevel()
	{
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
	}
}