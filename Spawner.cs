using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnRate;

    public GameObject rockPrefab;

    List<GameObject> rocks = new List<GameObject>();

    private float lastSpawn = 0;

    private int poolSize = 8;
    private int currentPoolIndex = 0;

    private Vector2 spawnLocation;

    void Start()
    {
        for(int i = 0; i<poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(rockPrefab);
            obj.SetActive(false);

            rocks.Add(obj);
        }
    }

	void Update()
    {
        if(GameControl.instance.isDead != true)
        {
            if (Time.time >= lastSpawn + spawnRate)
            {
                rocks[currentPoolIndex].transform.position = spawnLocation = new Vector2(Random.Range(-10, 10), 6.3f);
                rocks[currentPoolIndex].SetActive(true);

                currentPoolIndex++;

                if(currentPoolIndex >= poolSize)
                {
                    currentPoolIndex = 0;
                }

                lastSpawn = Time.time;
            }
        }
    }
}
