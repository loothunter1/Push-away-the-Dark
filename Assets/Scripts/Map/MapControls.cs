using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControls : MonoBehaviour
{
    int lightRatio = 1;
    public int LightRatio
    {
        get { return lightRatio; }
        set
        {
            lightRatio = value;
            if (lightRatio > 3)
                lightRatio = 3;
            else if (lightRatio < 0)
                lightRatio = 0;
            SetLighting();
        }
    }

    public bool powerCube;

    int tileX;
    int tileY;
    MapManager parentMap;
    // Start is called before the first frame update
    void Awake()
    {
        lightRatio = 0;
        parentMap = gameObject.GetComponentInParent<MapManager>();
        SetLighting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CashPosition(int x, int y)
    {
        tileX = x;
        tileY = y;
    }

    // On click
    public void OnClick()
    {
        if (gameObject.CompareTag("Player"))
            parentMap.SpreadTheLight(tileX, tileY, 3);
    }

    void LightenTile()
    {
        LightRatio += 1;
    }

    void SetLighting()
    {
        if(!gameObject.CompareTag("Player"))
        gameObject.GetComponent<MeshRenderer>().material = parentMap.PickLighting(lightRatio);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&parentMap!=null)
        {
            parentMap.currentRoom = this;
            parentMap.rm.SetRoom(lightRatio, powerCube);
        }
    }
}
