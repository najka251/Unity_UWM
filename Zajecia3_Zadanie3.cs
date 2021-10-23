using UnityEngine;

public class Zajecia3_Zadanie3 : MonoBehaviour
{
    Vector3 myVector;
    Rigidbody m_Rigidbody;
    float m_Speed = 2.0f;
    int obrot = 0; // przesuwamy w prawo gdy jest 0, w lewo gdy jest 1
    float x = 0.0f;
    float y = 0.0f;
    float z = 1.0f;
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
        if(obrot == 0)
        {
            
            if (x == 4.5f)
            {
                m_Rigidbody.transform.Rotate(90, 0, 0, Space.World);
                obrot = 1;
            }
            else
            {
                x = x + 0.5f;
                myVector = new Vector3(x, y, z);
                m_Rigidbody.MovePosition(myVector * m_Speed);
            }
        }
        else if (obrot == 1)
        {
            
            if (z == 4.5f)
            {
                m_Rigidbody.transform.Rotate(90, 0, 0, Space.World);
                obrot = 2;
            }
            else
            {
                z = z + 0.5f;
                myVector = new Vector3(x, y, z);
                m_Rigidbody.MovePosition(myVector * m_Speed);
            }
        }
        else if (obrot == 2)
        {
            
            if (x == 0.0f)
            {
                m_Rigidbody.transform.Rotate(90, 0, 0, Space.World);
                obrot = 3;
            }
            else
            {
                x = x - 0.5f;
                myVector = new Vector3(x, y, z);
                m_Rigidbody.MovePosition(myVector * m_Speed);
            }
        }
        else if (obrot == 3)
        {
            
            if (z == 0.5f)
            {
                m_Rigidbody.transform.Rotate(90, 0, 0, Space.World);
                obrot = 0;
            }
            else
            {
                z = z - 0.5f;
                myVector = new Vector3(x, y, z);
                m_Rigidbody.MovePosition(myVector * m_Speed);
            }
        }
        //Move the RigidBody upwards at the speed you define
        //Set the vector, which you use to move the RigidBody upwards straight away
        
    }
}