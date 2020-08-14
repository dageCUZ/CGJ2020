using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Floor : MonoBehaviour
{
    public enum FloorType
    {
        White,
        Grey,
        Black
    }

    [Range(0,1)]public float Percent = 0.5f;
    public FloorType IntervalType = FloorType.Grey;
    
    private float m_Speed;
    private MeshRenderer m_MeshRenderer;
    private BoxCollider m_Collider;
    private static string PROPERTY_NAME = "_Percent";

    private MaterialPropertyBlock m_PropertyBlock;
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_Collider = GetComponent<BoxCollider>();
        m_PropertyBlock = new MaterialPropertyBlock();
        MaterialControl();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
        CheckSpeed();
        MaterialControl();
        Percent += m_Speed;
    }

    public void ChangeSpeed(float speed)
    {
        if(IntervalType.Equals(FloorType.Grey))
            m_Speed = speed;
    }

    private void CheckState()
    {
        if (Percent >= 1)
        {
            IntervalType = FloorType.White;
            Percent = 1;
        }
        else if (Percent <= 0)
        {
            IntervalType = FloorType.Black;
            Percent = 0;
        }
        else
        {
            IntervalType = FloorType.Grey;
        }
    }
    
    private void CheckSpeed()
    {
        switch (IntervalType)
        {
            case FloorType.White:
                m_Speed = 0;
                break;
            case FloorType.Black:
                m_Speed = 0;
                break;
            default: break;
        }
    }

    private void MaterialControl()
    {
        m_MeshRenderer.GetPropertyBlock(m_PropertyBlock);
        m_PropertyBlock.SetFloat(PROPERTY_NAME, Percent);
        m_MeshRenderer.SetPropertyBlock(m_PropertyBlock);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " entered " + gameObject.name + " : Speed " + other.GetComponent<HitFloor>().Speed);
        switch (other.gameObject.tag)
        {
            case "Ant":
                m_Speed = other.gameObject.GetComponent<HitFloor>().Speed * Time.deltaTime;
                break;
            case "Box":
                /**/
                break;
            case "Player":
                m_Speed = other.gameObject.GetComponent<HitFloor>().Speed * Time.deltaTime;
                break;
        }
    }
}
