using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

    [SerializeField] bool willGrow;

    [SerializeField] List<GameObject> objects;

    [SerializeField] int MaxNumberObjects;

    public List<GameObject> prefabs;

    public GameObject SpawnObject(int objectID)
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy && obj.name == prefabs[objectID].name + "(Clone)")
            {
                obj.transform.parent = null;
                obj.SetActive(true);
                return obj;
            }
        }

        if (willGrow || objects.Count < MaxNumberObjects)
        {
            GameObject obj = Instantiate(prefabs[objectID]);
            objects.Add(obj);
            obj.SetActive(true);
            return (obj);
        }
        else
        {
            return null;
        }
    }

    public GameObject SpawnObject(int objectID, GameObject parent)
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy && obj.name == prefabs[objectID].name + "(Clone)")
            {
                obj.transform.parent = null;
                obj.SetActive(true);
                obj.transform.SetParent(parent.transform);
                obj.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + 0.2f, parent.transform.position.z);
                return obj;
            }
        }

        if (willGrow || objects.Count < MaxNumberObjects)
        {
            GameObject obj = Instantiate(prefabs[objectID], new Vector3(parent.transform.position.x, parent.transform.position.y + 0.2f, parent.transform.position.z), Quaternion.identity, parent.transform);
            objects.Add(obj);
            obj.SetActive(true);
            return (obj);
        }
        else
        {
            return null;
        }
    }
}
