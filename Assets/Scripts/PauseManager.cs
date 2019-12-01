using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseText;
    bool paused;
    // Awake is called before the first frame update
    void Awake()
    {
        paused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F1))
        {
            TrogglePause();
        }
    }

    void TrogglePause()
    {
        if (paused)
        {
            pauseText.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            pauseText.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
    }
}
