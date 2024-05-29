using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    Vector3 mousepos;
    float moveSpeed = 3f;
   /* public override void MoveControll()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * (Time.deltaTime * moveSpeed));
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));

        //if (Input.GetMouseButtonDown(0)) // Left
        

        

    }
*/
 /*   private void Update()
    {
        MoveControll();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Camera.main.nearClipPlane));
        transform.LookAt(mousepos);



    }*/
}
