using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_slime : MonoBehaviour
{
    public GameObject[] variants_spawn_slime;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTimeBtwSpawn;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int random = Random.Range(0, variants_spawn_slime.Length);
            Instantiate(variants_spawn_slime[random], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTimeBtwSpawn)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
