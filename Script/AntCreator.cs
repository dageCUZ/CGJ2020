using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AntCreator : MonoBehaviour
{
    public float intervalTime;
    public GameObject AntPrefab;
    private BoxCollider m_Collider;
    private float m_Timer;

    private GameObject m_AntListParent;

    private List<GameObject> m_AntsList;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Timer = 0;
        m_AntListParent = Instantiate(new GameObject());
        m_AntListParent.name = "AntList";
        m_AntsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Timer >= intervalTime)
        {
            GameObject newAnt = Instantiate(AntPrefab, 
                new Vector3(
                    Random.Range(m_Collider.bounds.min.x, m_Collider.bounds.max.x), 
                    Random.Range(m_Collider.bounds.min.y, m_Collider.bounds.max.y), 
                    Random.Range(m_Collider.bounds.min.z, m_Collider.bounds.max.z))
                ,Quaternion.identity, m_AntListParent.transform);
            m_AntsList.Add(newAnt);
            m_Timer = 0;
        }
        m_Timer += Time.deltaTime;
    }
}
