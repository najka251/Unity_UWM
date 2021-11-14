using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plansza : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunningRight = false;
    private bool isRunningLeft = false;
    private int index = 0;
    private Vector3 leftPosition; //Początkowe miejsce "suwnicy"
    public List<Vector3> rightPosition; //Już nie zmieniałem nazw zmiennych, ale po prostu to jest miejsce docelowe


    void Start()
    {
        leftPosition = transform.position;
    }

    void FixedUpdate()
    {
        
        if (isRunningRight)
        {
            float maxDistanceDelta = elevatorSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, rightPosition[index], maxDistanceDelta);
            if(transform.position == rightPosition[index])
            {
                if(transform.position == rightPosition[rightPosition.Count-1])
                {
                    isRunningLeft = true;
                    isRunningRight = false;
                }
                else
                {
                    index += 1;
                }
            }
        }
        if(isRunningLeft)
        {
            float maxDistanceDelta = elevatorSpeed * Time.deltaTime;
            if (index > -1) // -1 bo miejsce poczatkowe nie zapisalem do listy a jako oddzielną zmienną
            {
                transform.position = Vector3.MoveTowards(transform.position, rightPosition[index], maxDistanceDelta);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftPosition, maxDistanceDelta);
            }
            if (transform.position == rightPosition[index])
            {
                index -= 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            isRunningRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            isRunningRight = false;
            isRunningLeft = false;
        }
    }


}