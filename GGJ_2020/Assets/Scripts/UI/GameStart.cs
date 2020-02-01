using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class NewBehaviourScript : MonoBehaviour
{

    public UpperManager manager;
    public GameObject Player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(bool Solo){
        if(Solo){
            player2.SetActive(false);
        }

        manager.started = true;
    }
}
