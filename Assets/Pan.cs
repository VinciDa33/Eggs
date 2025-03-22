using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField] private Sprite eggpanSprite;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Egg")) {
            GetComponent<SpriteRenderer>().sprite = eggpanSprite;
        }
    }
}
