using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamBtn : MonoBehaviour
{
    public int index;
    public bool isFull;
    public int MaxCell;
    public bool isLocked;
    public Sprite FullImage;
    public Sprite NotFullImage;
    public Sprite EmptyImage;
    private Button m_Button;
    private void OnEnable()
    {
        m_Button = GetComponent<Button>();
        if (index == 0)
        {
            isLocked = false;
            int num = PlayerPrefs.GetInt("Diary" + index);
            if (num == MaxCell)
            {
                isFull = true;
            }
            else
            {
                isFull = false;
            }
        }
        else
        {
            int beforenum = PlayerPrefs.GetInt("Diary" + (index - 1));
            if (beforenum == 0)
            {
                isLocked = true;
                m_Button.interactable = false;
                m_Button.image.sprite = EmptyImage;
                return;
            }
            else
            {
                m_Button.interactable = true;
            }
            int num = PlayerPrefs.GetInt("Diary" + index);
            if (num == MaxCell)
            {
                isFull = true;
            }
            else
            {
                isFull = false;
            }
        }
        CheckFull();
    }

    private void CheckFull()
    {
        if (isFull)
        {
            m_Button.image.sprite = FullImage;
        }
        else
        {
            m_Button.image.sprite = NotFullImage;
        }
    }
    
}
