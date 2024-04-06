using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject RagDoll;
    [SerializeField] KeyCode SpawnKey;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(SpawnKey))
        {
            Instantiate(RagDoll, transform);
        }
    }
}
