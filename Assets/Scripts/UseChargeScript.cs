using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseChargeScript : MonoBehaviour
{
    public MapManager map;
    public Text chargesInfo;
    int charges;
    public int Charges
    {
        get{ return charges; }
        set
        {
            charges = value;
            UpdateText();
        }
    }
    public int chargesTotal = 1;
    // Start is called before the first frame update
    void Start()
    {
        Charges = 0;
    }

    void UpdateText()
    {
        chargesInfo.text = "Light charges x" + charges.ToString();
    }

    public void ActivateCharge()
    {
        if (Charges > 0)
        {
            Charges--;
            map.rm.LeaveRoom();
            map.player.GetComponent<MapControls>().OnClick();
            map.player.gameObject.SetActive(false);
            map.player.gameObject.SetActive(true);
            chargesTotal--;
            if (chargesTotal <= 0)
            {
                Congrats();
            }
        }
    }

    void Congrats()
    {
        map.GetComponent<GameOverScript>().GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
