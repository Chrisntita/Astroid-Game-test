using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spwaner : MonoBehaviour
{
     public float spawnRate = 1.0f;
     public int amountPerSpawn = 2;
     public int spawnAmount = 1;
     public float spawnDistance = 20f;
    public float  trajectoryVariance = 15.0f;

     public Asteroid asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }


     public void Spawn()
     {
        for (int i = 0; i < amountPerSpawn; i++)
        {
             Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
             Vector3 spawnPoint = transform.position + spawnDirection;

             float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

             Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            // Vector2 trajectory = rotation * -spawnDirection;
             asteroid.SetTrajectory(rotation * -spawnDirection);

        }
     }

   
    

}
