using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRoomScript : MonoBehaviour
{
    Camera cam;
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        layerMask = cam.cullingMask;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraView = cam.ScreenToViewportPoint(Input.mousePosition);
        if (cameraView.x >= 0 && cameraView.x <= 1 && cameraView.y >= 0 && cameraView.y <= 1)
        {
            Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(cam.ScreenToViewportPoint(Input.mousePosition));
            Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.black);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, layerMask))
            {
                Transform hitTransform = hit.transform;
                //Debug.Log(hitTransform.tag);
                if (Input.GetMouseButtonDown(0))
                {
                    hitTransform.GetComponent<ObjectInRoom>().OnClick();
                }
            }
        }
    }
}
