using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audioSource;

    public bool equipped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(emission.position, emission.forward * 10, Color.red);

        if (equipped && Input.GetMouseButtonDown(0))
        {
            if (audioSource != null) audioSource.Play();
            Instantiate(ammoPrefab, emission.position, emission.rotation);
        }

        if (ammoPrefab == null)
        {
            Instantiate(ammoPrefab);
        }
    }
}