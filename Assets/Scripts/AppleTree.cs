using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //apple perfab
    public GameObject applePrefab;
    public float speed = 1f; //spped that tree moves
    public float leftAndRightEdge = 10f; // distnace where tree turns around
    public float chanceToChangeDirections = 0.02f; //chance tree changes direction
    public float secondsBetweenAppleDrops = 1f; //rate at which apples will be instantaited

    void Start() {
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //change of direction
        if ( pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }

    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change directions
        }
    }


}
