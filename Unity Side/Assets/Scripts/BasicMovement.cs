using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 1f;

    Vector3 direction;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(direction * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction += transform.rotation * Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += transform.rotation * Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.rotation * Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.rotation * Vector3.forward;
        }
        if (direction.magnitude > 0)
        {
            Vector3.ClampMagnitude(direction, 1);
            direction *= speed;
        }
    }
}
