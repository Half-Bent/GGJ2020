using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public List<GameObject> RepairableObjects = new List<GameObject>();
    public int RepairedObjects = 0;
    public bool Done = false;

    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RepairedObjects >= RepairableObjects.Count){
            Done = true;
            Door.SetActive(false);
        }
    }
}
