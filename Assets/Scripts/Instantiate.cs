using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{


    public GameObject small_asteroid;
    public GameObject medium_asteroid;
    public GameObject large_asteroid;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(small_asteroid);
        Instantiate(medium_asteroid);
        Instantiate(large_asteroid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
