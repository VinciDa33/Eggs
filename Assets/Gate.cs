using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private AudioClip openSound;
    private Animator anim;
    private bool open = false;
    private AudioSource audioSource;
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "" + key;
    }

    void Update()
    {
        if (!open && Input.GetKeyDown(key)) {
            anim.Play("HorizontalGateOpen", 0, 0);
            transform.GetChild(0).gameObject.SetActive(false);
            audioSource.PlayOneShot(openSound, 1.8f);
            open = true;
        }
    }
}
