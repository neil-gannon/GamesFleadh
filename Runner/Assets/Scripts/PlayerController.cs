using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float ForceX = 10;
    public float ForceY = 20;
    public float ForceZ = 100;

    private bool CanJump = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(ForceX, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(-ForceX, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump)
            {
                rigidbody.AddForce(Vector3.up * ForceY);
                CanJump = false;
            }
        }


        //if(transform.position.x < -5)
        //{
        //    var trans = transform.position;
        //    trans.x = -4;
        //    transform.position = trans;
        //}
        //if(transform.position.x > 5)
        //{
        //    var trans = transform.position;
        //    trans.x = 4;
        //    transform.position = trans;
        //}

        rigidbody.AddForce(0, 0, ForceZ);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 50);
    }

    void OnCollisionEnter(Collision collision)
    {
        CanJump = true;
    }
}
