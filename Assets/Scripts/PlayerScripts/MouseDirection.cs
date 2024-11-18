using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class MouseDirection : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    private float mouseX;
    private float mouseY;
    public float attackDirection;

    public Transform player;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - player.transform.position).normalized;

        //Splitting the player's sides in 4 directions
        mouseX = direction.x;
        mouseY = direction.y;
        GetDirection();
    }

    public void GetDirection()
    {
        //Splitting the player's sides in 4 directions
        //attackDirection 1-4, 1 right, 2 left, 3 up, 4 down
        if (mouseX > 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
        {
            attackDirection = 1; // deksia
        }
        else if (mouseY > 0 && Mathf.Abs(mouseX) < Mathf.Abs(mouseY))
        {
            attackDirection = 3; //panw 
        }
        else if (mouseX < 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
        {
            attackDirection = 2; //aristera
        }
        else if (mouseY < 0 && Mathf.Abs(mouseX) < Mathf.Abs(mouseY))
        {
            attackDirection = 4; //katw
        }
    }



}
