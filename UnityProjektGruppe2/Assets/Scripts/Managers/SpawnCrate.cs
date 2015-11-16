using UnityEngine;
using System.Collections;

public class SpawnCrate : MonoBehaviour
{

    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;
    public GameObject[] whatToSpawnClone;



    void SpawnPickups1()
    {
        if (whatToSpawnClone[0] != null)
        {
            whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[0], 10);
        }
    }
    void SpawnPickups2()
    {
        if (whatToSpawnClone[1] != null)
        {
            whatToSpawnClone[1] = Instantiate(whatToSpawnPrefab[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[1], 10);
        }
    }
    void SpawnPickups3()
    {
        if (whatToSpawnClone[2] != null)
        {
            whatToSpawnClone[2] = Instantiate(whatToSpawnPrefab[2], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[2], 10);
        }
    }
    void SpawnPickups4()
    {
        if (whatToSpawnClone[3] != null)
        {
            whatToSpawnClone[3] = Instantiate(whatToSpawnPrefab[3], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[3], 10);
        }
    }
    void SpawnPickups5()
    {
        if (whatToSpawnClone[4] != null)
        {
            whatToSpawnClone[4] = Instantiate(whatToSpawnPrefab[4], spawnLocations[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[4], 10);
        }
    }
    void SpawnPickups6()
    {
        if (whatToSpawnClone[5] != null)
        {
            whatToSpawnClone[5] = Instantiate(whatToSpawnPrefab[5], spawnLocations[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[5], 10);
        }
    }
    void SpawnPickups7()
    {
        if (whatToSpawnClone[6] != null)
        {
            whatToSpawnClone[6] = Instantiate(whatToSpawnPrefab[6], spawnLocations[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[6], 10);
        }
    }
    void SpawnPickups8()
    {
        if (whatToSpawnClone[7] != null)
        {
            whatToSpawnClone[7] = Instantiate(whatToSpawnPrefab[7], spawnLocations[7].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(whatToSpawnClone[7], 10);
        }
    }













    // Use this for initialization
    void Start()
    {
        int whatToSpwanLength = whatToSpawnClone.Length;
        if (whatToSpwanLength > 0)
        {
            InvokeRepeating("SpawnPickups1", 5, 15);
            if (whatToSpwanLength > 1)
            {
                InvokeRepeating("SpawnPickups2", 20, 30);
                if (whatToSpwanLength > 2)
                {
                    InvokeRepeating("SpawnPickups3", 0, 30);
                    if (whatToSpwanLength > 3)
                    {
                        InvokeRepeating("SpawnPickups4", 25, 20);
                        if (whatToSpwanLength > 4)
                        {
                            InvokeRepeating("SpawnPickups5", 50, 17);
                            if (whatToSpwanLength > 5)
                            {
                                InvokeRepeating("SpawnPickups6", 10, 10);
                                if (whatToSpwanLength > 6)
                                {
                                    InvokeRepeating("SpawnPickups7", 15, 20);
                                    if (whatToSpwanLength > 7)
                                    {
                                        InvokeRepeating("SpawnPickups8", 0, 25);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }




    void Update()
    {

    }

    // Update is called once per frame
}

