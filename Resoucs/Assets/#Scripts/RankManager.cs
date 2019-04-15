using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public static RankManager Instance;

    private void Awake()
    {
        if (RankManager.Instance == null)
            RankManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddRank()
    {
        StartCoroutine(CorAddRank());
        AudioManager.Instance.PlayClick();
    }

    private IEnumerator CorAddRank()
    {
        WWW www = new WWW("http://haeyum.com/highthon5/add_rank.php?username=Ang&deathCount=" + GameManager.Instance.GetDeathCount() + "&time=" + GameManager.Instance.GetPlayTime());
        yield return www;

        //Debug.Log("http://haeyum.com/highthon5/add_rank.php?username=HolyKnight&deathCount=" + GameManager.Instance.GetDeathCount() + "&time=" + GameManager.Instance.GetPlayTime().ToString("N2"));
    }

    public void GetRank()
    {
        StartCoroutine(CorGetRank());
    }

    private IEnumerator CorGetRank()
    {
        WWW www = new WWW("http://haeyum.com/highthon5/top_rank.php");
        yield return www;

        string text = www.text;

        for (int i = 1; i <= 10; i++)
        {
            if (GetXML(text, $"username{i}") == null)
                break;
            
            UIManager.Instance.AddRank(i.ToString(), GetXML(text, $"username{i}"), GetXML(text, $"deathCount{i}"), GetXML(text, $"time{i}"));
        }
    }

    public string GetXML(string text, string sub)
    {
        int pos1 = text.IndexOf($"<{sub}>") + $"<{sub}>".Length;
        int pos2 = text.IndexOf($"</{sub}>");

        if (pos2 == -1)
            return null;

        return text.Substring(pos1, pos2 - pos1);
    }
}
