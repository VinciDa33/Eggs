using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggManager : MonoBehaviour
{
    private bool won = false;
    private bool lost = false;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;

    private float timer = 0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (won || lost)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                if (won)
                    WinScreen.SetActive(true);
                if (lost)
                    LoseScreen.SetActive(true);
            }
        }
        
        if (GameObject.FindGameObjectsWithTag("Egg").Length == 0)
            Lose();
    }

    public void Win()
    {
        Debug.Log("Win");
        if (!lost)
        {
            won = true;
        }
    }

    public void Lose()
    {
        Debug.Log("Lose");
        if (!won)
        {
            lost = true;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    
}
