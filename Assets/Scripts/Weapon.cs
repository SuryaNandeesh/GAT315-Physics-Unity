using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform emission;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ammoPrefab, emission.position, emission.rotation);
        }

        if(ammoPrefab == null)
        {
            Instantiate(ammoPrefab);
        }
    }
}
