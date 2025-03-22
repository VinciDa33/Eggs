using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField] private Sprite eggpanSprite;
    private AudioSource audioSource;
    
    
    [Header("Sounds")] 
    [SerializeField] private AudioClip yaySound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Egg")) {
            GetComponent<SpriteRenderer>().sprite = eggpanSprite;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<EggManager>().Win();
            audioSource.PlayOneShot(yaySound, 1.2f);
        }
    }
}
