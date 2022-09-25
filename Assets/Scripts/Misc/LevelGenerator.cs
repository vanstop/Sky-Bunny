using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField] GameObject platformPooler;
    [SerializeField] GameObject itemsPooler;

    [SerializeField] Transform PlatformChecker;

    [SerializeField] float minY = 0.5f;
    [SerializeField] float maxY = 1f;

    [SerializeField] float currentMinY = 0.5f;
    [SerializeField] float currentMaxY = 1f;

    [SerializeField] int chanceToSpawnItem;

    Vector3 spawnPosition = new Vector3(0, -1f);

    void Update()
    {
        float points = HUDSystem.Current.points;
        currentMinY = minY + points/5000; //Proporção em que a dificuldade aumenta de acordo com a altura que o personagem esta.
        currentMaxY = maxY + points/5000;

        if (currentMinY > 3) currentMinY = 3; //Estipula um limite para a dificuldade
        if (currentMaxY > 3) currentMaxY = 3;

        bool canSpawnPlatform = PlatformChecker.position.y > spawnPosition.y;
        if (canSpawnPlatform)
        {
            if (currentMaxY >= 3)
            {
                spawnMovingPlatform();
            }
            spawnPlatform();
        } 
    }

    void spawnPlatform()
    {
        spawnPosition.y += Random.Range(currentMinY, currentMaxY);
        spawnPosition.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0.125f,0,0)).x, Camera.main.ViewportToWorldPoint(new Vector3(0.875f, 0, 0)).x);
        GameObject plat = platformPooler.GetComponent<ObjectPooling>().SpawnObject(0);
        plat.transform.position = spawnPosition;
        chanceToSpawnItem = Random.Range(0, 100);

        if(spawnPosition.y >= 20)
        {
            if (chanceToSpawnItem >= 98)
            {
                ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
                GameObject item = itemPoolingScript.SpawnObject(3);
                item.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 0.2f, spawnPosition.z);
            }
            else if (chanceToSpawnItem >= 94)
            {
                ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
                GameObject item = itemPoolingScript.SpawnObject(4);
                item.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 0.2f, spawnPosition.z);
            }
            else if (chanceToSpawnItem >= 90)
            {
                ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
                GameObject item = itemPoolingScript.SpawnObject(2);
                item.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 0.2f, spawnPosition.z);
            }
            else if (chanceToSpawnItem >= 87)
            {
                ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
                GameObject item = itemPoolingScript.SpawnObject(1);
                item.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 0.2f, spawnPosition.z);
            }
            else if (chanceToSpawnItem >= 84)
            {
                ObjectPooling itemPoolingScript = itemsPooler.GetComponent<ObjectPooling>();
                GameObject item = itemPoolingScript.SpawnObject(0);
                item.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 0.2f, spawnPosition.z);
            }
        }
    }

    void spawnMovingPlatform()
    {
        spawnPosition.y += Random.Range(currentMinY, currentMaxY);
        spawnPosition.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0.125f, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(0.875f, 0, 0)).x);
        GameObject plat = platformPooler.GetComponent<ObjectPooling>().SpawnObject(1);
        plat.transform.position = spawnPosition;
    }
}
