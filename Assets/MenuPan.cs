using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MenuPan : MonoBehaviour
{
    [SerializeField] private Sprite panSprite;
    [SerializeField] private Sprite eggpanSprite;

    private bool panFilled = false;
    private float timer = 0f;

    private SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (panFilled)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                sr.sprite = panSprite;
                timer = 0f;
                panFilled = false;
            }
                
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Egg")) {
            sr.sprite = eggpanSprite;
            panFilled = true;
        }
    }
}
