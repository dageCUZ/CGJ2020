using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeUI : MonoBehaviour
{
    
    public GameObject Info;
    public GameObject Diary;
    

    public void ClickInfo()
    {
        if (Info.activeSelf)
        {
            Info.SetActive(false);
        }
        else
        {
            Info.SetActive(true);
        }
    }

    public void ClickDiary()
    {
        if (Diary.activeSelf)
        {
            Diary.SetActive(false);
        }
        else
        {
            Diary.SetActive(true);
        }
    }

    public void EnterLevel(int i)
    {
        Debug.Log("EnterLevel "+i);
    }
}
