using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public List<GameObject> Players = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!Players[1].activeSelf){
            transform.position = new Vector3(Players[0].transform.position.x, Players[0].transform.position.y, transform.position.z);
        }else{
            Bounds bounds = new Bounds();
            for(int i = 0; i < Players.Count; i++){
                if(Players[i].activeSelf){
                    bounds.Encapsulate(Players[i].transform.position);
                }
            }

            transform.position = new Vector3(bounds.center.x, bounds.center.y, transform.position.z);
        }
    }
}
