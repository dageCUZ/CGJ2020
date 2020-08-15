using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    // public float ThrowTime;
    [Space(20)]
    // public bool OnThrow;
    // public Vector3 Target;
    public Floor Floor;

    // public Vector3 StartThrow;
    public Vector3 velocity = Vector3.zero;
    public float ForceCo = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // BeThrown();
        Move();
    }

    void Move()
    {
        transform.position += velocity * ForceCo * Time.deltaTime;
    }
    // void BeThrown()
    // {
    //     if (OnThrow)
    //     {
    //         Debug.Log("OnThrow");
    //         var position = transform.position;
    //         float semi = Time.deltaTime / ThrowTime;
    //         position += (Target - StartThrow) / semi;
    //             
    //         transform.position = position;
    //     }
    // }
    
}
