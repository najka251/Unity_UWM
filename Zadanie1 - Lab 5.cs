using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 5.6f;
    private float leftPosition;
    private float rightPosition;


    void Start()
    {
        rightPosition = transform.position.x + distance;
        leftPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (transform.position.x >= rightPosition)
        {
            elevatorSpeed = -elevatorSpeed;
        }
        else if (transform.position.x <= leftPosition)
        {
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            isRunning = false;
        }
    }


}