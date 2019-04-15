using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int deathCount = 0;
    private float playTime = 0;

    private void Awake()
    {
        if (GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {

    }

    public void StartGame()
    {
        StartPlayTime();
        ClearDeathCount();
        AudioManager.Instance.StopBgm();
        AudioManager.Instance.PlayBgm(1);
        GameObject.Find("InGame").transform.GetChild(0).gameObject.SetActive(true);
        for(int i=1; i<9; i++)
        {
            GameObject.Find("InGame").transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject.Find("Panel").gameObject.SetActive(false);
        AudioManager.Instance.PlayClick();
    }

    public void ReStartGame()
    {
        ClearDeathCount();
        ClearPlayTime();

        StartPlayTime();
    }

    #region Play Time
    public void StartPlayTime()
    {
        StartCoroutine(CorPlayTime());

        UIManager.Instance.RefreshUI();
    }

    public void ClearPlayTime()
    {
        playTime = 0;
        StopCoroutine(CorPlayTime());

        UIManager.Instance.RefreshUI();
    }

    public float GetPlayTime()
    {
        return playTime;
    }

    private IEnumerator CorPlayTime()
    {
        yield return new WaitForSeconds(0.01f);
        playTime += 0.01f;

        StartPlayTime();
    }
    #endregion

    #region Death Count
    public void IncreaseDeathCount()
    {
        deathCount++;
        UIManager.Instance.RefreshUI();
    }

    public void ClearDeathCount()
    {
        deathCount = 0;
        UIManager.Instance.RefreshUI();
    }

    public int GetDeathCount()
    {
        return deathCount;
    }
    #endregion

}
