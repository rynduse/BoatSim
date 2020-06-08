using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class FloatObject : MonoBehaviour
{
    public float waterLevel = 0.0f;
    public float floatTreshold = 2.0f;
    public float waterDesity = 0.125f;
    public float downForce = 4.0f;
    public float BouncyTime = 5.0f;
    Vector3 Bouncy;

    float forceFactor;
    Vector3 floatForce;

    private void Start()
    {
        Bouncy += new Vector3(0.0f, -15.0f, 0.0f);
        GetComponent<Rigidbody>().AddForceAtPosition(Bouncy, transform.position);
    }
    private void FixedUpdate()
    {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatTreshold);

        if(forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDesity);
            floatForce += new Vector3(0.0f, -downForce, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }

    private void Update()
    {
        BouncyTime -= Time.deltaTime;
        if (BouncyTime < 0)
        {
            if (this.transform.position.y > -0.5f && this.transform.position.y < 0.05f)
            {
                Bouncy += new Vector3(0.0f, -15.0f, 0.0f);
                GetComponent<Rigidbody>().AddForceAtPosition(Bouncy, transform.position);
            }
            BouncyTime += 2.0f;
        }
    }

}
