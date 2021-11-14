using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drzwi : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 3.0f;
    private float leftPosition;
    private float rightPosition;
    private bool isRunningRight = true;
    private bool isRunningLeft = false;


    void Start()
    {
        rightPosition = transform.position.x + distance;
        leftPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (isRunningRight && transform.position.x >= rightPosition)
        {
            elevatorSpeed = -elevatorSpeed;
            isRunning = false;
            isRunningRight = false;
            isRunningLeft = true;
}
        else if (isRunningLeft && transform.position.x <= leftPosition)
        {
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
            isRunning = false;
            isRunningRight = true;
            isRunningLeft = false;

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
            Debug.Log("Player w drzwiach.");

            isRunning = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player przeszedl.");
            if(isRunningLeft)
            {
                isRunning = true;
            }
        }
    }
}