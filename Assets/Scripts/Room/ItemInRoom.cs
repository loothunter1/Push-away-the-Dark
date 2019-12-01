using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInRoom : ObjectInRoom
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnClick()
    {
        Debug.Log("Clicked on monster in the room!");
        LogAction("Power source acquired!");
        UseChargeScript chargeScript = GameController.instance.GetComponent<UseChargeScript>();
        chargeScript.Charges++;
        chargeScript.map.currentRoom.powerCube = false;
        Remove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
