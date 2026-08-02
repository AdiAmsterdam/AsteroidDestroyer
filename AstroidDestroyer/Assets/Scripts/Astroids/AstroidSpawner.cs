using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AstroidSpawner : MonoBehaviour
{
    
    public Astroid AstroidPrefab;
    public float spawnRate;
    private float MaxXRange = 18f;
    private float MaxYRange = 5f;



    void SpawnAstroid()
    {
        float x = Random.Range(10, MaxXRange);
        float y = Random.Range(5, MaxYRange);
        
        float signX = (Random.value > 0.5f) ? 1f : -1f;
        float signY = (Random.value > 0.5f) ? 1f : -1f;
        
        x *= signX;
        y *= signY;
        
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(AstroidPrefab, pos, transform.rotation);
    }

    IEnumerator SpawnAstroids()
    {
        while (true)
        {
            SpawnAstroid();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAstroids());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
