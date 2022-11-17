using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_spawn_slime : MonoBehaviour
{
    public GameObject[] slime;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, slime.Length);
        Instantiate(slime[random], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
