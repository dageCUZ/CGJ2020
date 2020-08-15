using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    public float intervalTime;
    public GameObject BoxPrefab;
    private BoxCollider m_Collider;
    private float m_Timer;

    private GameObject m_BoxListParent;

    // private List<GameObject> m_BoxList;

    private FloorSystem m_FloorSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Timer = 0;
        m_BoxListParent = Instantiate(new GameObject());
        m_BoxListParent.name = "BoxList";
        // m_BoxList = new List<GameObject>();
        m_FloorSystem = GameObject.Find("FloorSystem").GetComponent<FloorSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Timer >= intervalTime)
        {
            GameObject emptyBlock = m_FloorSystem.GetRandomEmptyBlock();
            if (emptyBlock != null)
            {
                Vector3 pos = emptyBlock.transform.position;
                pos.y = transform.position.y;
                GameObject newBox = Instantiate(BoxPrefab, 
                    pos
                    ,Quaternion.identity, m_BoxListParent.transform);
                // m_BoxList.Add(newBox);
            }
            m_Timer = 0;
        }
        m_Timer += Time.deltaTime;
    }
    

}
