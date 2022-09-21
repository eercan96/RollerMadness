using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private Transform[] spawnPositions;
    private TimeManager TimeManager;


    private float nextSpawnTime = 0f;

    void Start()
    {
        TimeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad > nextSpawnTime && TimeManager.gameOver == false && TimeManager.gamefinished == false)//Burada 5 saniye aral�kla bir kodu �al��t�rma yap�ld�.
        {
            nextSpawnTime += spawnRate;
            SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            //Instantiate(coinPrefab,transform.position,transform.rotation);//spawn yapmak i�in kullan�labilir.(obje-kordinat-rotayon)
        }
    }
    private void SpawnObject(GameObject objectToSpawn, Transform newPosition)//Obje �retmek i�in
    {
        Instantiate(objectToSpawn, newPosition.position, newPosition.rotation);
    }
    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }
    private int RandomObjectNumber()
    {
        return Random.Range(0, objects.Length);
    }
}
