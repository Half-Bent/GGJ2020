using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public List<RepairableObject> availableObjects;
    private RepairableObject selectedObject;

    private void Start()
    {
        // Get random from availables
        selectedObject = Instantiate(availableObjects[Random.Range(0, availableObjects.Count - 1)]);
        selectedObject.transform.position = transform.position;
    }
}
