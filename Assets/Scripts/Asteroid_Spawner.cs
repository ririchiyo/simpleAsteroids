using System.Collections;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{

    public GameObject _player;

    public float asteroidSpawnTimer = 5; //seconds to spawn next asteroid wave

    private IEnumerator coroutine;

    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = spawnAsteroids();
        StartCoroutine(coroutine);
        coroutine = handleMovement();
        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private IEnumerator spawnAsteroids()
    {
        while(_player.activeInHierarchy)
        {
            switch (Random.Range(1,4))
            {
                case 1:
                    this.transform.GetComponent<Asteroid>().createSmallAsteroid(Random.Range(1, 5));
                    break;
                case 2:
                    this.transform.GetComponent<Asteroid>().createMediumAsteroid(Random.Range(1, 5));
                    break;
                case 3:
                    this.transform.GetComponent<Asteroid>().createLargeAsteroid(Random.Range(1, 5));
                    break;
                default:
                    break;

            }
            yield return new WaitForSeconds(5f);
        }

    }

    private IEnumerator handleMovement()
    {
        while(_player.activeInHierarchy)
        {
            this.transform.GetComponent<Asteroid>().asteroid_rb.transform.position = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            yield return new WaitForSeconds(2f);
        }
    }

}
