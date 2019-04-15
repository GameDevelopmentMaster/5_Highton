using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage7 : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject Bealeobject;
    bool check=false;
    bool Beale;
    Vector3 BackGroundPos, ObjectPos;
    private void Awake()
    {
        if (BackGround != null)
        {
            BackGroundPos = BackGround.transform.position;
        }
        if (Bealeobject != null)
        {
            ObjectPos= Bealeobject.transform.position;
        }
    }
    private void OnEnable()
    {
        if(BackGround!= null)
        {
            BackGround.transform.position = BackGroundPos;
        }
        if(Bealeobject != null)
        {
            Bealeobject.transform.position = ObjectPos;
        }
        Beale = false;
        check = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check&&BackGround!=null)
        {
            BackGround.transform.position = new Vector3(BackGround.transform.position.x + 1f * Time.deltaTime, BackGround.transform.position.y, BackGround.transform.position.z);
            GameObject.Find("Player").GetComponent<Animator>().Play("Left");
        }
        if (Beale&&Bealeobject!=null)
        {
            Bealeobject.transform.position = new Vector3(Bealeobject.transform.position.x - 1.2f*Time.deltaTime, Bealeobject.transform.position.y, Bealeobject.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Beale = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            check = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        check = false;
    }
}
