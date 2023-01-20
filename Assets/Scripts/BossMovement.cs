using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float sideBuffer = 7f;
    [SerializeField] float topBuffer = 7f;
    Vector2 initialPosition;
    bool moveRight;
    bool moveUp;
    

    void Start()
    {   
        moveRight=true;
        moveUp=false;
        initialPosition = transform.position;
    }

    void Update()
    {
        CheckBufferSide();
        CheckBufferTopBottom();
        MoveLeftRight();
        MoveTopBottom();
    }

    void CheckBufferSide()
    {
        if (transform.position.x > sideBuffer)
        {
            moveRight = false;
        }
        else if (transform.position.x < -sideBuffer)
        {
            moveRight = true;
        }
    }

    void CheckBufferTopBottom()
    {
        if (transform.position.y > initialPosition.y + topBuffer)
        {
            moveUp = false;
        }
        else if (transform.position.y < initialPosition.y -topBuffer)
        {
            moveUp = true;
        }
    }

    void MoveLeftRight()
    {
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
                                            transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
                                            transform.position.y);
        }
    }

    void MoveTopBottom()
    {
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x,
                                            transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x,
                                            transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
