using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPhiysics : MonoBehaviour
{
   public GameObject[] Stage;
    public GameObject Menu;
    public Image[] images;
    int key = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "black")
        {
            if(collision.name == "up")
            {
                PlayerMove.OutCheck[3] = collision.gameObject;
            }
            if(collision.name == "down")
            {
                PlayerMove.OutCheck[2] = collision.gameObject;
            }
        }

        if(collision.tag == "enemy")
        {
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Panel").transform.GetChild(0).gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
            Menu.transform.GetChild(1).gameObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            GameManager.Instance.IncreaseDeathCount();
        }

        if(collision.tag == "check")
        {
            for(int i=0; i<2; i++)
            {
                GameObject.Find("Stage4").transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if(collision.tag == "bullet")
        {
            if(key== 2)
            {
                GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Panel").transform.GetChild(0).gameObject.SetActive(false);
                Menu.gameObject.SetActive(true);
                Menu.transform.GetChild(1).gameObject.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
                GameManager.Instance.IncreaseDeathCount();
            }
            images[key].gameObject.SetActive(false);
            key++;
        }

        if(collision.tag == "out")
        {
            switch (collision.name)
            {
                case "1":
                    Stage[0].gameObject.SetActive(false);
                    Stage[1].gameObject.SetActive(true);
                    PlayerMove.OutCheck[3] = GameObject.Find("UpOutCheck");
                    break;
                case "2":
                    Stage[1].gameObject.SetActive(false);
                    Stage[2].gameObject.SetActive(true);
                    break;
                case "3":
                    Stage[2].gameObject.SetActive(false);
                    Stage[3].gameObject.SetActive(true);
                    break;
                case "4":
                    Stage[3].gameObject.SetActive(false);
                    Stage[4].gameObject.SetActive(true);
                    AudioManager.Instance.StopBgm();
                    AudioManager.Instance.PlayBgm(2);
                    break;
                case "5":
                    Stage[4].gameObject.SetActive(false);
                    Stage[5].gameObject.SetActive(true);

                    break;
                case "6":
                    Stage[5].gameObject.SetActive(false);
                    Stage[6].gameObject.SetActive(true);
                    break;
                case "7":
                    Stage[6].gameObject.SetActive(false);
                    Stage[7].gameObject.SetActive(true);
                    break;
                case "8":
                    Stage[7].gameObject.SetActive(false);
                    Stage[8].gameObject.SetActive(true);
                    AudioManager.Instance.StopBgm();
                    AudioManager.Instance.PlayBgm(3);
                    break;
                case "9":
                    Stage[8].gameObject.SetActive(false);
                    Stage[9].gameObject.SetActive(true);
                    AudioManager.Instance.StopBgm();
                    AudioManager.Instance.PlayBgm(4);

                    break;
            }
        }
    }
}
