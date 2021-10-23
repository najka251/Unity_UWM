using UnityEngine;

public class Zajecia3_Zadanie2 : MonoBehaviour
{
    Vector3 myVector;
    Rigidbody m_Rigidbody;
    float m_Speed = 2.0f;
    int przesun = 0; // przesuwamy w prawo gdy jest 0, w lewo gdy jest 1
    float x = 0.0f;
    void Start()
    {
        //Fetch the RigidBody you attach to the GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (przesun == 0 )
        {
            if( x == 5f)
            {
                przesun = 1;
            }
            else
            {
                x = x + 0.5f;
            }
        }
        else if(przesun == 1)
        {
            if (x == 0.0f)
            {
                przesun = 0;
            }
            else
            {
                x = x - 0.5f;
            }
        }
        //Move the RigidBody upwards at the speed you define
        //Set the vector, which you use to move the RigidBody upwards straight away
        myVector = new Vector3(x, 0.0f, 0.0f);
        m_Rigidbody.MovePosition(myVector * m_Speed);
    }
}