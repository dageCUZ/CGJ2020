using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    public float ThrowTime;
    [Space(20)]
    public bool OnThrow;
    public Vector3 Target;
    public Floor Floor;

    public Vector3 StartThrow;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeThrown();
    }

    void BeThrown()
    {
        if (OnThrow)
        {
            Debug.Log("OnThrow");
            var position = transform.position;
            float semi = Time.deltaTime / ThrowTime;
            position += (Target - StartThrow) / semi;
                
            transform.position = position;
        }
    }
    
}
