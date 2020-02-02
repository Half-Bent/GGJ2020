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
            Vector3 pos = new Vector3();
            for(int i = 0; i < 2; i++){
                pos += Players[i].transform.position;
                bounds.Encapsulate(Players[i].transform.position);
            }
            pos = pos / 2;

            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }
    }
}
