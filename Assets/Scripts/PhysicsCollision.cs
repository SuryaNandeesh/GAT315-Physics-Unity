using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour
{
    string status;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        status = "collision enter: " + collision.gameObject.name;
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        
    }

    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        status = "trigger enter: " + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }
}
