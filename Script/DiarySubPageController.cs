using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarySubPageController : MonoBehaviour
{
    public int index;
    public GameObject FullMask;
    public GameObject[] SubMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CheckMask()
    {
        if (PlayerPrefs.HasKey("Diary"+index))
        {
            int num = PlayerPrefs.GetInt("Diary"+index);
            if (num <= 0)
            {
                FullMask.SetActive(true);
            }
            else
            {
                for (int i = 0; i < SubMask.Length; i++)
                {
                    if (i < num)
                    {
                        SubMask[i].SetActive(true);
                    }
                    else
                    {
                        SubMask[i].SetActive(false);
                    }
                }
            }
            
            return;
        }
        Debug.LogError("No Diary1 data found");
    }
}
