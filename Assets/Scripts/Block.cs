using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject hitEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Increase score here
            ScoreManager.Instance.IncrementScore(scoreValue);

            //Instantiate the particle effect
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            //Destroy block
            Destroy(this.gameObject);
        }
    }
}
