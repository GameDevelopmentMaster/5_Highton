using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static GameObject[] OutCheck;
    public GameObject Player;
    Vector3 BackVector3;
    Vector3 Mousepos;
    int key;
    // Start is called before the first frame update
    void Start()
    {
        OutCheck = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
           OutCheck[i] = GameObject.Find("OutCheck").transform.GetChild(i).gameObject;
        }
               Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            if (Mousepos.x < OutCheck[1].transform.position.x && Mousepos.x > OutCheck[0].transform.position.x && Mousepos.y > OutCheck[2].transform.position.y && Mousepos.y < OutCheck[3].transform.position.y)
            {
                Player.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                if (BackVector3.x > Player.transform.position.x)
                {
                    //Player.GetComponent<Animator>().SetBool("LeftRight", true);
                    Player.GetComponent<Animator>().Play("Left");
                    key = 1;
                }
                else if (BackVector3.x < Player.transform.position.x)
                {
                    //Player.GetComponent<Animator>().SetBool("LeftRight", false);
                    Player.GetComponent<Animator>().Play("Right");
                    key = 2;
                }
                else if (BackVector3.x == Player.transform.position.x)
                {
                    if (key == 1)
                    {
                        Player.GetComponent<Animator>().SetTrigger("Left_Idle");
                    }

                    else if (key == 2)
                    {
                        Player.GetComponent<Animator>().SetTrigger("Right_Idle");
                    }
                }
                BackVector3 = Player.transform.position;

            }

        }
      
    }
}
