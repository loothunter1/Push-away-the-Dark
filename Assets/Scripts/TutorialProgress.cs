using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgress : MonoBehaviour
{
    public int tutorialPhase = 0;
    // Awake is called before the first frame update
    void Awake()
    {
        tutorialPhase = 0;
    }

    public void NextPhase()
    {
        tutorialPhase++;
    }

    void StartPhase()
    { }
}
