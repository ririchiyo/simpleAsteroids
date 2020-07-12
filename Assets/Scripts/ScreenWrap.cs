using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{


    public GameObject player;
     ParticleSystem ps;

    float leftSide = 0.0f;
    float rightSide = 0.0f;

    float buffer = 0.5f;
    float distanceZ = 0.5f;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        leftSide = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, distanceZ)).x;
        rightSide = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceZ)).x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        position = player.transform.position;
        if (position.x < leftSide - buffer)
        {
            position.x = rightSide - buffer;
            player.transform.position = position;
        }
        if (position.x > rightSide + buffer)
        {
            position.x = leftSide + buffer;
            player.transform.position = position;
        }
        if (position.y < leftSide - buffer)
        {
            position.y = rightSide - buffer;
            player.transform.position = position;
        }
        if (position.y > rightSide + buffer)
        {
            position.y = leftSide + buffer;
            player.transform.position = position;
        }
        player.transform.position = position;
        position = player.transform.position;
    }
}
