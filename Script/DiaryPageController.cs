using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageController : MonoBehaviour
{
    public List<GameObject> Diarys;
    
    public int index;

    private List<DiarySubPageController> subpages;
    // Start is called before the first frame update
    void Start()
    {
        CheckPlayerDataInit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIndex()
    {
        index += 1;
        if (index > Diarys.Count - 1)
        {
            index = 0;
        }
        RefreshDiaryShow();
    }

    public void SubIndex()
    {
        index -= 1;
        if (index < 0)
        {
            index = Diarys.Count - 1;
        }
        RefreshDiaryShow();
    }
    
    private void OnEnable()
    {
        
        subpages = new List<DiarySubPageController>();
        for (int i = 0; i < Diarys.Count; i++)
        {
            subpages.Add(Diarys[i].GetComponent<DiarySubPageController>());
        }
        RefreshDiaryShow();
    }

    public void RefreshDiaryShow()
    {
        for (int i = 0; i < Diarys.Count; i++)
        {
            if (i == index)
            {
                Diarys[i].SetActive(true);
                subpages[i].CheckMask();
            }
            else
            {
                Diarys[i].SetActive(false);
            }
        }
    }

    void CheckPlayerDataInit()
    {
        for (int i = 0; i < Diarys.Count; i++)
        {
            if (!PlayerPrefs.HasKey("Diary"+i))
            {
                PlayerPrefs.SetInt("Diary"+i, 0);
            }
        }
        
    }
}
