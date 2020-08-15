using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitFloor))]
public class Ant : MonoBehaviour
{
    public float MoveSpeed;

    private Transform m_Player;
    private Vector3 m_Direction;

    private Animation m_Animation;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float realSpeed = MoveSpeed * Time.deltaTime;
        var position = transform.position;
        m_Direction = m_Player.position - position;
        m_Direction = Vector3.Normalize(m_Direction);
        transform.forward = m_Direction;
        m_Direction *= realSpeed;
        position += m_Direction;
        transform.position = position;
    }
}
