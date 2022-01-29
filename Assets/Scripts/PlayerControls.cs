using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{


   // public Controls playerController;

    Vector3 pos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (Input.GetButton("Vertical"))
            MoveLeft();*/
        
    }

    public void MoveLeft()
    {
        this.GetComponent<Transform>().position += Vector3.right.normalized * speed;
    }
}
