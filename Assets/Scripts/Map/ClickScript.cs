using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    Camera cam;
    public Camera innerCam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!innerCam.pixelRect.Contains(Input.mousePosition))
        {
            Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(mouseRay.origin);
            //Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.black);
            RaycastHit hit;
            int layerMask = cam.cullingMask;
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, layerMask))
            {
                Transform hitTransform = hit.transform;
                //Debug.Log(hitTransform.tag);
                if (Input.GetMouseButtonDown(0))
                {
                    hitTransform.GetComponent<MapControls>().OnClick();
                }
            }
        }
    }
}
