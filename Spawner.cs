using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int spawnID;

    public GameObject[] enemyPrefab;
    Player player;

    bool ready2spawn = true;

    public bool attackSpawn;
    public bool defenseSpawn;
    public bool scoutSpawn;

    public float enemySpawnTime = 3f;

    Vector3 spawnlocation;



    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        spawnID = Random.Range(1, 5);
        
        if (ready2spawn == true)
        {
            switch (spawnID)
            {
                case 1:
                    spawnlocation = new Vector3(9.5f, Random.Range(4.5f, -4.5f), 0);
                    restart();
                    break;
                case 2:
                    spawnlocation = new Vector3(-9.5f, Random.Range(4.5f, -4.5f), 0);
                    restart();
                    break;
                case 3:
                    spawnlocation = new Vector3(Random.Range(-9.5f, 9.5f), 5.7f, 0);
                    restart();
                    break;
                case 4:
                    spawnlocation = new Vector3(Random.Range(-9.5f, 9.5f), -5.7f, 0);
                    restart();
                    break;
            }
        }
    }
    void restart()
    {
        spawn();
        ready2spawn = false;
        StartCoroutine(EnemyDelay());
    }

    void spawn()
    {
        if (player.isDead == true)
            return;
        Instantiate(enemyPrefab[Random.Range(0, 3)], spawnlocation, Quaternion.Euler(0, 0, Random.Range(0, 361)));
    }

    IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(enemySpawnTime);
        ready2spawn = true;
    }


    


    
}
