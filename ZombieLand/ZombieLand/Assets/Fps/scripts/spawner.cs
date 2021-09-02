using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public Transform enemies;
    public GameObject enemy;
    public Transform Player;
    void Start()
    {
        spawners = new GameObject[5];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        //belirlediğimiz noktalarda zombileri spawn ediyor
        GameObject zombie =
            Instantiate(enemy, spawners[Random.Range(0, spawners.Length)].transform.position,
         spawners[Random.Range(0, spawners.Length)].transform.rotation, enemies);
        zombie.GetComponent<Zombiescript>().hedef = Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy();

        }
    }
}
