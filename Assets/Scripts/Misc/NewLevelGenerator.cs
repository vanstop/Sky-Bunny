using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPooler;
    [SerializeField] GameObject itemsPooler;
    [SerializeField] GameObject windFlag;

    [SerializeField] Transform PlatformChecker;

    [SerializeField] float minY = 0.5f;
    [SerializeField] float maxY = 1f;

    float currentMinY = 0.5f;
    float currentMaxY = 1f;

    Vector3 spawnPosition = new Vector3(0, -1f);

    [SerializeField] float maxPlatformSpawnRange = 0.1f;
    [SerializeField] float maxItemSpawnRange = 0.1f;
    [SerializeField] float minItemSpawnRange = 0;

    [SerializeField] float maxItemSpawnInterval = 1f;
    [SerializeField] float delaySpawnItem = 0;

    [SerializeField] float chanceToSpawnCoin = 0.1f;
    [SerializeField] float chanceToSpawnSpring = 5f;
    [SerializeField] float chanceToSpawnJetpack = 5f;
    [SerializeField] float chanceToSpawnMushroom = 5f;
    [SerializeField] float chanceToSpawnWings = 5f;

    float platformToSpawn;
    float itemToSpawn;

    float points;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {

        points = HUDSystem.Current.points; //Verifica a quantidade de pontos atual

        currentMinY = minY + points / 35000; //Proporção em que a dificuldade aumenta de acordo com a altura que o personagem esta.
        currentMaxY = maxY + points / 35000;

        if (currentMinY > 3) currentMinY = 3; //Estipula um limite para a dificuldade
        if (currentMaxY > 3) currentMaxY = 3;

        maxPlatformSpawnRange = 0.1f + points / 5000; //Determina o range de spawn das plataformas

        maxItemSpawnRange = 0.1f + points / 10000; //Determina o range de spawn dos items

        bool canSpawnPlatform = PlatformChecker.position.y > spawnPosition.y;

        if (points > 10000)
        {
            windFlag.SetActive(true);
        }

        if (canSpawnPlatform)
        {
            platformToSpawn = Random.Range(0, maxPlatformSpawnRange); //Determina qual plataforma sera criada
            if (platformToSpawn > platformPooler.GetComponent<ObjectPooling>().prefabs.Count - 1)
                platformToSpawn = platformPooler.GetComponent<ObjectPooling>().prefabs.Count - 1;
            spawnPlatform((int)platformToSpawn);
        }
    }
    void spawnPlatform(int platformId)
    {
        spawnPosition.y += Random.Range(currentMinY, currentMaxY);
        spawnPosition.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0.125f, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(0.875f, 0, 0)).x);
        GameObject plat = platformPooler.GetComponent<ObjectPooling>().SpawnObject(platformId);
        plat.transform.position = spawnPosition;

        itemToSpawn = Random.Range(minItemSpawnRange, maxItemSpawnRange); //Determina qual item sera criado

        if (itemToSpawn > chanceToSpawnWings + maxItemSpawnInterval)
            itemToSpawn -= itemToSpawn /= chanceToSpawnWings + maxItemSpawnInterval;

        itemToSpawn -= delaySpawnItem;
        if(platformId <= 1)
        {
            spawnItem(plat);
        }
    }

    void spawnItem(GameObject plat)
    {
        int itemID = -1;

        if (itemToSpawn >= chanceToSpawnWings)
        {
            itemID = 4;
            delaySpawnItem = 0.2f;
        }
        else if (itemToSpawn >= chanceToSpawnMushroom && itemToSpawn < chanceToSpawnMushroom + maxItemSpawnInterval)
        {
            itemID = 3;
            delaySpawnItem = 0.2f;
        }
        else if (itemToSpawn >= chanceToSpawnJetpack)
        {
            itemID = 2;
            delaySpawnItem = 0.1f;
        }
        else if (itemToSpawn >= chanceToSpawnSpring)
        {
            itemID = 1;
            delaySpawnItem = 0.1f;
        }
        else if (itemToSpawn >= chanceToSpawnCoin)
        {
            itemID = 0;
            delaySpawnItem = 0;
        }

        if(itemID >= 0)
        {
            ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
            itemPoolingScript.SpawnObject(itemID, plat);
        }  
    }
}
