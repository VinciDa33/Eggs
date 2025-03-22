using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Egg : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    
    [SerializeField] private float maxImpulse;
    [SerializeField] private GameObject eggsplosion;

    [Header("Sounds")] [SerializeField] private GameObject audioTemp;
    [SerializeField] private AudioClip[] bonkSounds;
    [SerializeField] private AudioClip breakSound;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(gameObject, 0.15f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject aTemp;
        
        if (rb.velocity.magnitude > 0.2f)
            audioSource.PlayOneShot(bonkSounds[Random.Range(0, bonkSounds.Length)], 0.9f);
        
        if (collision.collider.tag.Equals("Pan"))
        {
            Instantiate(eggsplosion, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);
            
            aTemp = Instantiate(audioTemp, transform.position, quaternion.identity);
            aTemp.GetComponent<AudioSource>().PlayOneShot(breakSound, 1.1f);

        }
        else if (!collision.collider.tag.Equals("Gate"))
        {
            if (collision.contacts[0].normalImpulse > maxImpulse)
            {
                Instantiate(eggsplosion, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
                Destroy(gameObject, 0.15f);
                
                aTemp  = Instantiate(audioTemp, transform.position, quaternion.identity);
                aTemp.GetComponent<AudioSource>().PlayOneShot(breakSound, 1.1f);            
                
                EggManager eggManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<EggManager>();
                
            }
        }
    }
}
