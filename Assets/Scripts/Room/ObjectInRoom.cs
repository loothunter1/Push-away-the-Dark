using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInRoom : MonoBehaviour
{
    public string defaultMessage;
    public bool persistent = false;
    static GameController gameController = null;
    static ActionLog actionLog = null;
    // Start is called before the first frame update
    void Start()
    {
        if (gameController == null)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (actionLog == null)
            actionLog = gameController.GetComponent<ActionLog>();
    }

    // On click
    public virtual void OnClick()
    {
        Debug.Log("Clicked on object in the room!");
        LogAction(defaultMessage);
    }

    public void LogAction(string msg)
    {
        actionLog.AddMessage(msg);
    }

    public void Remove()
    {
        if (!persistent)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
