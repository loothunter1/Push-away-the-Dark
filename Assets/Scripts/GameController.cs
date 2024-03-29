﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance=null;

    public GameObject gameControllerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
		if (instance == null)
		{
			instance = this;
            Instantiate(gameControllerPrefab);
		}
		else if (instance != this)
			Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
