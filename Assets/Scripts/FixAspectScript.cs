using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixAspectScript : MonoBehaviour
{
    public float width = 4f;
    public float height = 3f;

    // Start is called before the first frame update
    void Start()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        float screenAspect = screenWidth / (float)screenHeight;
        Camera cam = GetComponent<Camera>();
        cam.aspect = width / height;
        if (screenAspect / cam.aspect < 1)
            cam.rect = new Rect(0, 0.5f - 0.5f * screenAspect / cam.aspect, 1, screenAspect / cam.aspect);
        else if (screenAspect / cam.aspect > 1)
            cam.rect = new Rect(0.5f - 0.5f * cam.aspect / screenAspect, 0, cam.aspect / screenAspect, 1);
        //Debug.Log(screenAspect.ToString()+" "+cam.aspect.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
