using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float fastSpeed = 30f;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bump")
        {
            moveSpeed = slowSpeed;
        }
        if (other.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
}