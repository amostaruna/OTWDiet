﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Enemy : MonoBehaviour
{
    public float speed;
    private bool movingright = true;
    public Transform groundDetection;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(movingright==true)
            {
                transform.eulerAngles = new Vector3(0, -200, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }
    }
}
