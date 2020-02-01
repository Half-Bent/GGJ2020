using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 5;
    public CharacterAnimation charAnimation;
    public XboxController CurrentController;
    public XboxController GetController{
        get{return CurrentController;}
    }

    public Vector3 movTemp;
    public bool ohjain = false;
    void awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        XCI.DEBUG_LogControllerNames();
        Debug.Log(XCI.GetNumPluggedCtrlrs());

    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag != "Player"){
            Vector3 mov = new Vector3(XCI.GetAxis(XboxAxis.LeftStickX, this.CurrentController), XCI.GetAxis(XboxAxis.LeftStickY, this.CurrentController));
            movTemp = mov;
            ohjain = true;
            transform.position = transform.position + mov * speed * Time.deltaTime;
            if (charAnimation)
                charAnimation.AnimateMovement(mov);

        }else{
            //Vector3 mov  = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 mov = new Vector3();
            if(Input.GetKey(KeyCode.A)){
                mov.x = -1;
            }else if(Input.GetKey(KeyCode.D)){
                mov.x = 1;
            }
            
            if(Input.GetKey(KeyCode.W)){
                mov.y = 1;
            }else if(Input.GetKey(KeyCode.S)){
                mov.y = -1;
            }

            ohjain = false;
            transform.position = transform.position + mov * speed * Time.deltaTime;
            if (charAnimation)
                charAnimation.AnimateMovement(mov);

        }

        
    }
}
