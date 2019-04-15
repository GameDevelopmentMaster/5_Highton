using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text textDeathCount, textPlayTime;

    public Slider sliderBossHp;

    public GameObject panelRank;
    public GameObject prefabRankItem;

    public GameObject panelClear;

    private void Awake()
    {
        if (UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void RefreshUI()
    {
        SetDeathCount();
        SetPlayTime();
    }

    public void SetDeathCount()
    {
        textDeathCount.text = "죽은 횟수: " + GameManager.Instance.GetDeathCount().ToString();
    }

    public void SetPlayTime()
    {
        textPlayTime.text = "플레이 시간: " + GameManager.Instance.GetPlayTime().ToString("N2");
    }

    public void ShowRank()
    {
        for (int i = 0; i < panelRank.transform.GetChild(0).childCount; i++)
            Destroy(panelRank.transform.GetChild(0).GetChild(i).gameObject);

        panelRank.SetActive(true);
        RankManager.Instance.GetRank();
        AudioManager.Instance.PlayClick();
    }

    public void HideRank()
    {
        panelRank.SetActive(false);
    }

    public void AddRank(string index, string username, string deathCount, string time)
    {
        GameObject item = Instantiate(prefabRankItem);
        item.transform.SetParent(panelRank.transform.GetChild(0));

        item.transform.GetChild(0).GetComponent<Text>().text = index + "위";
        item.transform.GetChild(1).GetComponent<Text>().text = username;
        item.transform.GetChild(2).GetComponent<Text>().text = deathCount;
        item.transform.GetChild(3).GetComponent<Text>().text = float.Parse(time).ToString("N2") + "초";
        AudioManager.Instance.PlayClick();
    }

    public void ChangeBossHP(int hp)
    {
        sliderBossHp.value = hp;
    }

    public void GameClear()
    {
        panelClear.SetActive(true);
        panelClear.transform.parent.gameObject.SetActive(true);

        Destroy(GameObject.Find("Player"));

        GameObject.Find("InGame").transform.GetChild(8).gameObject.SetActive(false);
        AudioManager.Instance.StopBgm();
        AudioManager.Instance.PlayBgm(0);

        Cursor.visible = true;
        Debug.Log("보스 주겨쪙");
    }
}
