using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Vector2 moveDirection;
    [SerializeField] float bulletMoveSpeed =5f;

    void OnEnable() 
    {
        Invoke("Destroy", 3f);
    }

    void Update()
    {
        transform.Translate(moveDirection * bulletMoveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable() 
    {
        CancelInvoke();    
    }
}
