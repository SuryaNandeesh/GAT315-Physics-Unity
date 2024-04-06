using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] ForceMode forcemode = ForceMode.Force;
    [SerializeField] Space space = Space.World;

    Rigidbody rb;
    Vector3 force = Vector3.zero;
    Vector3 torque = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float rotation = 0;

        if (space == Space.World) direction.x = Input.GetAxis("Horizontal");
        else 
        { 
            rotation = Input.GetAxis("Horizontal"); 
        }

        direction.z = Input.GetAxis("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);
        force = direction * speed;

        //transform.rotation *= Quaternion.Euler(0, rotation * speed, 0 );
        //direction = transform.rotation * direction;

        //transform.Translate(direction * speed * Time.deltaTime * speed, space);

        //transform.position += direction * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, forcemode);
        rb.AddTorque(force, forcemode);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
