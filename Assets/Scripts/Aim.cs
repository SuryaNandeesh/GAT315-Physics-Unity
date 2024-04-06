using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] float speed = 3;

    Vector3 rotation = Vector3.zero;
    Vector2 prevAxis = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        prevAxis.x = -Input.GetAxis("Mouse Y"); // x
        prevAxis.y =  Input.GetAxis("Mouse X"); // y
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x; // x
        axis.y =  Input.GetAxis("Mouse X") - prevAxis.y; // y

        rotation.x += axis.x * speed; // x
        rotation.y += axis.y * speed; // y
        
        rotation.x = Mathf.Clamp(rotation.x, -20, 20); // x
        rotation.y = Mathf.Clamp(rotation.y, -20, 20); // y


        Quaternion qyaw = Quaternion.AngleAxis(axis.y * speed, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(axis.x * speed, Vector3.right);

        transform.rotation *= (qpitch * qyaw);

    }
}
