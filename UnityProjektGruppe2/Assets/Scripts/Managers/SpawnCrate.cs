using UnityEngine;
using System.Collections;

public class SpawnCrate : MonoBehaviour
{

    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;
    public GameObject[] whatToSpawnClone;



    void SpawnPickups1()
    {
        whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[0], 10);
    }
    void SpawnPickups2()
    {
        whatToSpawnClone[1] = Instantiate(whatToSpawnPrefab[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[1], 10);
    }
    void SpawnPickups3()
    {
        whatToSpawnClone[2] = Instantiate(whatToSpawnPrefab[2], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[2], 10);
    }
    void SpawnPickups4()
    {
        whatToSpawnClone[3] = Instantiate(whatToSpawnPrefab[3], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[3], 10);
    }
    void SpawnPickups5()
    {
        whatToSpawnClone[4] = Instantiate(whatToSpawnPrefab[4], spawnLocations[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[4], 10);
    }
    void SpawnPickups6()
    {
        whatToSpawnClone[5] = Instantiate(whatToSpawnPrefab[5], spawnLocations[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[5], 10);
    }
    void SpawnPickups7()
    {
        whatToSpawnClone[6] = Instantiate(whatToSpawnPrefab[6], spawnLocations[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[6], 10);
    }
    void SpawnPickups8()
    {
        whatToSpawnClone[7] = Instantiate(whatToSpawnPrefab[7], spawnLocations[7].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(whatToSpawnClone[7], 10);
    }













    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnPickups1", 5, 15);
        InvokeRepeating("SpawnPickups2", 20, 30);
        InvokeRepeating("SpawnPickups3", 0, 30);
        InvokeRepeating("SpawnPickups4", 25, 20);
        InvokeRepeating("SpawnPickups5", 50, 17);
        InvokeRepeating("SpawnPickups6", 10, 10);
        InvokeRepeating("SpawnPickups7", 15, 20);
        InvokeRepeating("SpawnPickups8", 0, 25);


    }



    void Update()
    {

    }
}

	// Update is called once per frame
	

