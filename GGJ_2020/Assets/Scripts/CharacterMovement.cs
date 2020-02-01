using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 5;
    public CharacterAnimation charAnimation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position = transform.position + mov * speed * Time.deltaTime;

        if (charAnimation)
            charAnimation.AnimateMovement(mov);
    }
}
