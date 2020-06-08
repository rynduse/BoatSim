using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FloatObject))]
public class BoatController : MonoBehaviour
{
    public Vector3 COM;
    public float speed = 1.0f;
    public float movementThresold = 1.0f;

    Transform m_COM;
    float verticalInput;
    float movementFactor;

    private void Update()
    {
        Balance();
        Movement();
    }

    void Balance()
    {
        if(!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }

        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    void Movement()
    {
        movementFactor = Mathf.Lerp(movementFactor, 0.5f, Time.deltaTime / movementThresold);
        transform.Translate(movementFactor * speed, 0.0f, 0.0f);
    }
}
