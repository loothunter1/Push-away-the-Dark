using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public Light lightSource;
    public Camera roomCam;
    public GameObject[] monsterPrefab;
    public Image fader;
    public GameObject[] landscapePrefab;
    public Transform coordMin;
    public Transform coordMax;
    Vector3 min;
    Vector3 max;
    // Start is called before the first frame update
    void Start()
    {

    }

    void SetLight(float intensity, float range)
    {
        if(intensity>=0)
            lightSource.intensity = intensity;
        if (range >= 0)
            lightSource.range = range;
    }

    void RandomObjectPlacement(GameObject[] objectArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        Debug.Log("Spawning " + objectCount + " monsters");

        for(int i = 0; i < objectCount; i++)
        {
            GameObject pickObject = objectArray[Random.Range(0, objectArray.Length)];
            Vector3 pickPosition = ChooseRandomPosition(true, true, true);
            Instantiate(pickObject, pickPosition, Quaternion.identity, transform);
        }
    }

    void RandomGroundPlacement(GameObject[] objectArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);

        for (int i = 0; i < objectCount; i++)
        {
            GameObject pickObject = objectArray[Random.Range(0, objectArray.Length)];
            Vector3 pickPosition = ChooseRandomPosition(true, false, true, y: -.3f);
            Instantiate(pickObject, pickPosition, Quaternion.identity, transform);
        }
    }

    void PlaceCube()
    {
        Vector3 pickPosition = ChooseRandomPosition(false, false, false, 0, -.3f, coordMin.position.z);
        Instantiate(landscapePrefab[0], pickPosition, Quaternion.identity, transform);
    }

    public Vector3 ChooseRandomPosition(bool randX, bool randY,bool randZ, float x=0, float y=0, float z=0)
    {
        float randomX = randX ? Random.Range(coordMin.position.x, coordMax.position.x) : x;
        float randomY = randY ? Random.Range(coordMin.position.y, coordMax.position.y) : y;
        float randomZ = randZ ? Random.Range(coordMin.position.z, coordMax.position.z) : z;
        Vector3 pos = new Vector3(randomX, randomY, randomZ);
        return pos;
    }

    void SetRoomLight(int state)
    {
        switch (state)
        {
            case 0:
                SetLight(1, 10);
                break;
            case 1:
                SetLight(2, 20);
                break;
            case 2:
                SetLight(3, 30);
                break;
            case 3:
                SetLight(5, 50);
                break;
            default:
                break;
        }
    }

    public void SetRoom(int state, bool cube)
    {
        SetRoomLight(state);
        if(cube)
        PlaceCube();
        //RandomGroundPlacement(landscapePrefab, 1, 3);
        Debug.Log("Light ratio is " + state);
        RandomObjectPlacement(monsterPrefab, 3 - state, 3 - state);
        fader.gameObject.SetActive(false);
    }

    public void LeaveRoom()
    {
        fader.gameObject.SetActive(true);
        ClearRoom();
    }

    void ClearRoom()
    {
        foreach(ObjectInRoom roomObject in transform.GetComponentsInChildren<ObjectInRoom>())
        {
            roomObject.Remove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
