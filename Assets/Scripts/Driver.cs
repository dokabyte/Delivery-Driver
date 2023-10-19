using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float destroyDelay = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            Destroy(collision.gameObject, destroyDelay);
        }
    }
}
