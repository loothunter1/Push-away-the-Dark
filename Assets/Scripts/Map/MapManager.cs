using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Material darkTile;
    public Material darkGreyTile;
    public Material lightGreyTile;
    public Material lightTile;


    public float scaleX = 1f;
    public float scaleY = 1f;
    public int columns;
    public int raws;
    public int startX = 0;
    public int startY = 0;

    public RoomManager rm;
    public MapControls currentRoom;
    GameObject[,] rooms;
    public PlayerMovement player;
    Vector3[,] positionMap;
    public GameObject roomPrefab;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SetMap();
        SetPlayer();
        
    }

    void SetMap()
    {
        positionMap = new Vector3[columns, raws];
        rooms = new GameObject[columns, raws];
        for (int x = 0; x < columns; x++)
            for (int y = 0; y < raws; y++)
            {
                positionMap[x, y] = new Vector3(scaleX * x+transform.position.x, scaleY * y + transform.position.y, transform.position.z);
                rooms[x, y] = Instantiate(roomPrefab, positionMap[x, y], Quaternion.identity, transform);
                rooms[x, y].GetComponent<MapControls>().CashPosition(x, y);
            }
        RandomCubesPlacement(10, 10);
        SpreadTheLight(startX, startY, 3);
    }

    void SetPlayer()
    {
        player = Instantiate(playerPrefab, positionMap[startX, startY], Quaternion.identity, transform).GetComponent<PlayerMovement>();
        player.SetPosition(startX, startY);
    }

    public void SpreadTheLight(int tileX, int tileY, int range)
    {
        for(int x=tileX-range;x<=tileX+range;x++)
            for(int y = tileY - range; y <= tileY + range; y++)
            {
                MapControls tile = GetTile(x, y);
                if (tile)
                {
                    float x1 = x - tileX;
                    float y1 = y - tileY;
                    float curRange = (x1 * x1 + y1 * y1)/range/range;
                    tile.LightRatio = Mathf.Max(Mathf.RoundToInt((1f - curRange) * 2.6f), tile.LightRatio);
                }
            }
    }

    public MapControls GetTile(int tileX, int tileY)
    {
        if (IsPositionValid(tileX,tileY))
            return rooms[tileX, tileY].GetComponent<MapControls>();
        else
            return null;
    }

    public Vector3 GetTilePosition(int tileX, int tileY)
    {
        if (IsPositionValid(tileX, tileY))
            return positionMap[tileX, tileY];
        else
            return new Vector3(0,0,0);
    }

    void RandomCubesPlacement(int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);

        for (int i = 0; i < objectCount; i++)
        {
            int x = Random.Range(0, columns);
            int y = Random.Range(0, raws);
            while (GetTile(x, y).powerCube)
            {
                x = Random.Range(0, columns);
                y = Random.Range(0, raws);
            }
            GetTile(x, y).powerCube = true;
        }
    }

    public bool IsPositionValid(int tileX,int tileY)
    {
        if (tileX >= 0 && tileY >= 0 && tileX < positionMap.GetLength(0) && tileY < positionMap.GetLength(1))
            return true;
        else
            return false;
    }

    public Material PickLighting(int lightRatio)
    {
        switch (lightRatio)
        {
            case 0:
                return darkTile;
                break;
            case 1:
                return darkGreyTile;
                break;
            case 2:
                return lightGreyTile;
                break;
            case 3:
                return lightTile;
                break;
            default:
                return darkTile;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
