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

    IEnumerator SpawnAstroids(Score playerScore)
    {
        while (true)
        {
            SpawnAstroid();
            yield return new WaitForSeconds(spawnRate * Math.Clamp(playerScore.Score1/500,1,3));
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score playerScore = FindFirstObjectByType<Score>();
        StartCoroutine(SpawnAstroids(playerScore));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
