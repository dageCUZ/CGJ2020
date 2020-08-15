using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitFloor))]
public class Player : MonoBehaviour
{
    public float moveSpeed;

    private GameObject m_HandOnBox;
    private static Vector3 _boxOffset = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // Throw();
    }

    void Move()
    {
        float realSpeed = moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,1) *realSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,0,-1) * realSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1,0,0) * realSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1,0,0) * realSpeed);
        }

        if (m_HandOnBox != null)
        {
            m_HandOnBox.transform.localPosition = _boxOffset;
        }
    }

    // void Throw()
    // {
    //     if (Input.GetKey(KeyCode.Mouse0))
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hitInfo;
    //         if (Physics.Raycast(ray, out hitInfo))
    //         {
    //             Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
    //             GameObject obj = hitInfo.collider.gameObject;
    //             Debug.Log("Hit obj " + obj.name);
    //             if (m_HandOnBox != null)
    //             {
    //                 m_HandOnBox.transform.parent = null;
    //                 m_HandOnBox.GetComponent<Rigidbody>().WakeUp();
    //                 var position = obj.transform.position;
    //                 Vector3 direction = position - transform.position;
    //                 direction.y = 0;
    //                 //m_HandOnBox.transform.forward = direction;
    //                 Box box = m_HandOnBox.GetComponent<Box>();
    //                 // box.OnThrow = true;
    //                 // box.Target = position;
    //                 // box.Target.y = 1;
    //                 box.Floor = null;
    //                 // box.StartThrow = m_HandOnBox.transform.position;
    //                 m_HandOnBox = null;
    //             }
    //         }
    //     }
    // }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ant"))
        {
            Debug.Log("************* You Lose *****************");
            Application.Quit();
        }

        if (other.gameObject.tag.Equals("Box"))
        {
            if (other.gameObject.transform.position.y > transform.position.y)
            {
                Debug.Log("You have been hit from a Box, Game Over.");
            }
            else
            {
                Vector3 forcedir = other.gameObject.transform.position - transform.position;
                // if (Mathf.Abs(forcedir.x) > Mathf.Abs(forcedir.z))
                // {
                //     forcedir.z = 0;
                // }
                // else
                // {
                //     forcedir.x = 0;
                // }

                other.gameObject.GetComponent<Box>().velocity = forcedir;
                // if (m_HandOnBox == null)
                // {
                //     m_HandOnBox = other.gameObject;
                //     m_HandOnBox.transform.parent = transform;
                //     m_HandOnBox.transform.localPosition = new Vector3(0, 1, 0);
                //     m_HandOnBox.GetComponent<Box>().Floor.HasBox = false;
                //     m_HandOnBox.GetComponent<Rigidbody>().Sleep();
                // }
            }
        }
    }


}
