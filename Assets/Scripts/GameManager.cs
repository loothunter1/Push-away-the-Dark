using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance=null;

	public int[] levelProgress;
	public string[] levelNames;
	public string menuLevelName;
	public int nextLevel;
	public int currentLevel;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
			InitGameManager ();
		}
		else if (instance != this)
			Destroy (gameObject);
	}

	void InitGameManager()
	{
		if(SceneManager.GetActiveScene().name=="Init")
		{
            LoadMenu();
		}
	}

	void LoadMenu()
	{
	}

	void LoadLevel(int levelNum)
	{
		SceneManager.LoadScene(levelNames[levelNum]);
	}
}
