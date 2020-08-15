using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEdge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Box": Destroy(other.gameObject);
                break;
            case "Ant": Destroy(other.gameObject);
                break;
        }
    }
}
