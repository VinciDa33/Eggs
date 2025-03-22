using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuEggSpawner : MonoBehaviour
{
    [SerializeField] private GameObject egg;

    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.2f)
        {
            float randX = Random.Range(-5.5f, 5.5f);
            Instantiate(egg, new Vector3(randX, transform.position.y), quaternion.identity);
            timer = 0f;
        }
    }
}
