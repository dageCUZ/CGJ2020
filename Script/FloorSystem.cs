using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSystem : MonoBehaviour
{
    public GameObject[] Blocks;

    private List<Floor> m_blockStates;
    private List<GameObject> m_EmptyBlock;

    private int m_Top;
    private int m_Bottom;
    // Start is called before the first frame update
    void Start()
    {
        m_blockStates = new List<Floor>();
        m_EmptyBlock = new List<GameObject>();
        /*Transform[] Allchild = GetComponentsInChildren<Transform>();
        foreach (var child in Allchild)
        {
            Floor intervalScript = child?.GetComponent<Floor>();
            if(intervalScript)m_blockStates.Add(intervalScript);
        }*/
        //m_blockStates = new Floor[Blocks.Length];
        for (int i = 0; i < Blocks.Length; i++)
        {
            m_blockStates.Add(Blocks[i].GetComponent<Floor>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndGame();
    }

    void CheckEndGame()
    {
        m_Top = 0;
        m_Bottom = 0;
        for (int i = 0; i < m_blockStates.Count; i++)
        {
            if (m_blockStates[i].IntervalType.Equals(Floor.FloorType.Grey))
            {
                return;
            }else if (m_blockStates[i].IntervalType.Equals(Floor.FloorType.White))
            {
                m_Top += 1;
            }
            else
            {
                m_Bottom += 1;
            }
        }
        Debug.LogWarning("Game Ends, White " + m_Top + " and Black " + m_Bottom);
        Application.Quit();
    }

    public GameObject GetRandomEmptyBlock()
    {
        m_EmptyBlock.Clear();
        for (int i = 0; i < Blocks.Length; i++)
        {
            if (m_blockStates[i].HasBox == false)
            {
                m_EmptyBlock.Add(m_blockStates[i].gameObject);
            }
        }

        int num = m_EmptyBlock.Count;
        if (num <= 0)
        {
            return null;
        }
        int randomSerial = Random.Range(0, num);
        return m_EmptyBlock[randomSerial];
    }

    
}
