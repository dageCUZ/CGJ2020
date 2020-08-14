using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitFloor))]
public class Player : MonoBehaviour
{
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float realSpeed = MoveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0,1) *realSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0,0,-1) * realSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1,0,0) * realSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1,0,0) * realSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ant"))
        {
            Debug.Log("************* You Lose *****************");
            Application.Quit();
        }
    }
}
