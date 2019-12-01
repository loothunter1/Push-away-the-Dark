using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionLog : MonoBehaviour
{
    public Text logMessages;
    public int maxMessages;
    public List<string> messages;
    // Start is called before the first frame update
    void Start()
    {
        //messages = new List<string>();
        ///messages.Add("Go beyond the bounds of the light to push away the dark.");
        //messages.Add("But beware monsters that leap at you from the dark.");
        UpdateText();
    }

    void ClearLog()
    {
    }

    void UpdateText()
    {
        logMessages.text = "";
        foreach(string m in messages)
        {
            logMessages.text += m;
            logMessages.text += "\n";
        }
    }

    public void AddMessage(string msg)
    {
        messages.Add(msg);
        if (messages.Count > maxMessages)
            messages.RemoveAt(0);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
