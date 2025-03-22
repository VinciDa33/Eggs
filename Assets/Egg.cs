using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float maxImpulse;
    [SerializeField] private GameObject eggsplosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Pan"))
        {
            Instantiate(eggsplosion, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            if (collision.contacts[0].normalImpulse > maxImpulse)
            {
                Instantiate(eggsplosion, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                Destroy(gameObject, 0.15f);
            }
        }
    }
}
