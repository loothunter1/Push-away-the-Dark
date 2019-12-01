using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool canMove;
    bool controlsActive;
    int moveHorizontal;
    int moveVertical;
    int playerX;
    int playerY;
    MapManager parentMap;
    Rigidbody rb;
    MapControls mapMark;
    public float moveTime = 1f;

    private void Awake()
    {
        mapMark = GetComponent<MapControls>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //mapMark = GetComponent<MapControls>();
        parentMap = gameObject.GetComponentInParent<MapManager>();
        controlsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controlsActive)
            return;
        moveHorizontal = (int) Input.GetAxisRaw("Horizontal");
        moveVertical = (int)Input.GetAxisRaw("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            if (moveVertical != 0)
                moveHorizontal = 0;
            MoveTo(playerX + moveHorizontal, playerY + moveVertical);
        }
    }

    public void SetPosition(int x, int y)
    {
        playerX = x;
        playerY = y;
        mapMark.CashPosition(playerX, playerY);
    }

    void MoveTo(int newX, int newY)
    {
        if (parentMap.IsPositionValid(newX, newY))
        {
            controlsActive = false;
            parentMap.rm.LeaveRoom();
            playerX = newX;
            playerY = newY;
            mapMark.CashPosition(playerX, playerY);
            StartCoroutine(SmoothMovement(parentMap.GetTilePosition(playerX, playerY)));
        }
    }

    protected IEnumerator SmoothMovement(Vector3 moveTo)
    {
        float sqrRemainingDistance = (transform.position - moveTo).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime / moveTime);
            transform.position = newPosition;
            sqrRemainingDistance = (transform.position - moveTo).sqrMagnitude;
            yield return null;
        }
        controlsActive = true;
    }
}
