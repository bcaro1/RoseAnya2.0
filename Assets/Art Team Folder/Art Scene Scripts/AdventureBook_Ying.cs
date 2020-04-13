using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class AdventureBook_Ying : MonoBehaviour
{
    public static bool IsPaused = false;

    #region Public
    // Number of pages in the book, array will hold game objects for each page
    // Keeps track of current page for flipping
    public int numPages = 7;
    public GameObject[] pagesArray = new GameObject[7];
    public int curPage = 0;
    #endregion

    void Start()
    {
        // Instatiate the pages to true/false

        pagesArray[0].SetActive(true);
        for (int i = 1; i < numPages; i++)
        {
            pagesArray[i].SetActive(false);
        }
    }

    void Update()
    {
    }

    // increment page
    public void NextPage()
    {
        if (curPage < numPages-1)
        {
            pagesArray[curPage].SetActive(false);
            pagesArray[++curPage].SetActive(true);
        }
        else
        {
            Debug.Log("Last page reached");
        }
    }

    // decrement page
    public void BackPage()
    {
        if (curPage > 0)
        {
            pagesArray[curPage].SetActive(false);
            pagesArray[--curPage].SetActive(true);
        }
        else
        {
            Debug.Log("First page reached");
        }
    }

    // jumps to specific page
    public void GuideButton()
    {
        pagesArray[curPage].SetActive(false);
        curPage = 1;
        pagesArray[curPage].SetActive(true);
    }

    public void ControlsButton()
    {
        pagesArray[curPage].SetActive(false);
        curPage = 4;
        pagesArray[curPage].SetActive(true);
    }

    public void CombatButton()
    {
        pagesArray[curPage].SetActive(false);
        curPage = 5;
        pagesArray[curPage].SetActive(true);
    }

    public void QuestsButton()
    {
        pagesArray[curPage].SetActive(false);
        curPage = 6;
        pagesArray[curPage].SetActive(true);
    }
}

