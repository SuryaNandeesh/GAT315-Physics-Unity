using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour
{
    [SerializeField] GameObject fx;

    string status;

    Vector3 contact;
    Vector3 normal;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        status = "collision enter: " + collision.gameObject.name;

        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;

        Instantiate(fx, contact, Quaternion.LookRotation(normal));
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        status = "collision stay: " + collision.gameObject.name;
    }

    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        status = "collision leave: " + collision.gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        status = "trigger enter: " + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "trigger stay: " + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "trigger exit: " + other.gameObject.name;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(contact, 0.5f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}
