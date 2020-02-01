using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public int RepairObjectCount = 3;
    public int RepairedObjects = 0;
    public bool Done = false;
    public bool LastRoom;

    public GameObject Door;
    public GameObject Door2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RepairedObjects >= RepairObjectCount){
            Done = true;
            if(!LastRoom){
                Door.SetActive(false);
                Door2.SetActive(false);
            }
        }
    }
}
