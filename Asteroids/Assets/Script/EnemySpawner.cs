using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float tiempoSpawn = 30f;
    public float masMeteor = 2f;//para aunmetar la dificultad q salgan mas asteroides por min

    private float spawnNext = 0f;

    public float xlimit;
    public float maxLife = 2f;


    void Update()
    {
        //contador y generar enemigo de forma random
        
            if (Time.time > spawnNext)
            {

                spawnNext = Time.time + 60 / tiempoSpawn;

                //para incrementar el ratio
                tiempoSpawn += masMeteor;

                float rand = Random.Range(-xlimit, xlimit);

                Vector3 spawnPos = new Vector3(rand, 8f, 5f);

                GameObject meteor = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);

                Destroy(meteor, maxLife);
           }
        

    }
}
