using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Penel;
    public Image Rank;
    public GameObject Clear;
    private void Start()
    {
        Cursor.visible = true;
    }

    public void GameStart()
    {
        for(int i=0; i < 9; i++)
        {
            GameObject.Find("InGame").transform.GetChild(i).gameObject.SetActive(false);
        }
        Stage1.SetActive(true);
        Penel.SetActive(false);
        Time.timeScale = 1;
        AudioManager.Instance.StopBgm();
        AudioManager.Instance.PlayBgm(1);
        AudioManager.Instance.PlayClick();
        Cursor.visible = false;
    }
   
    public void Main()
    {
        Penel.transform.GetChild(0).gameObject.SetActive(true);
        for(int i=1; i<3; i++)
        {
            if (Penel.transform.GetChild(i).gameObject.activeSelf)
            {
                Penel.transform.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
        AudioManager.Instance.PlayClick();
    }

    public void RankShow()
    {
        Rank.gameObject.SetActive(true);
    }
    public void EndShow()
    {
        Clear.gameObject.SetActive(true);
        Rank.gameObject.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        AudioManager.Instance.PlayClick();
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
