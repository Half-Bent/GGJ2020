using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 5;
    public CharacterAnimation charAnimation;
    [SerializeField]
    private XboxController CurrentController = XboxController.Any;
    public XboxController GetController{
        get{return CurrentController;}
    }

    public bool IsController{
        get{return CurrentController != XboxController.Any;}
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3();
        if(CurrentController == XboxController.First){
            XCI.GetAxis(XboxAxis.LeftStickX, CurrentController);
            mov = new Vector3(XCI.GetAxis(XboxAxis.LeftStickX, CurrentController), XCI.GetAxis(XboxAxis.LeftStickY, CurrentController));
        }else{
            mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        transform.position = transform.position + mov * speed * Time.deltaTime;

        if (charAnimation)
            charAnimation.AnimateMovement(mov);
    }
}
