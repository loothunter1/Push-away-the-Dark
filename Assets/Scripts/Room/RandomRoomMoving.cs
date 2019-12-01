using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomMoving : MonoBehaviour
{
    RoomManager room;
    Vector3 targetPosition;
    public float speed = 1f;
    public float attackSpeed = 3f;
    bool attacking;
    float currentSpeed;
    float aggressionRate=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        room = gameObject.GetComponentInParent<RoomManager>();
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        attacking = false;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
        if (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
        else
        {
            transform.position = targetPosition;
            if (!attacking&&WantsToAttack())
            {
                targetPosition = room.transform.position;
                gameObject.GetComponent<MonsterInRoom>().LogAction("Monster leaps at you from the dark!");
                currentSpeed = attackSpeed;
                attacking = true;
            }
            else
            {
                if (attacking)
                {
                    currentSpeed = speed;
                    attacking = false;
                }
                targetPosition = room.ChooseRandomPosition(true, true, true);
            }
        }
    }

    bool WantsToAttack()
    {
        return (Random.value < aggressionRate) ? true : false;
    }
}
