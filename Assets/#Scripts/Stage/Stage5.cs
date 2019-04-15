using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour
{
    public Animator guardain;
    bool check;
    public GameObject guardainobject;
    public float Speed;
    Vector3 Pos;

    private void Awake()
    {
        Pos = guardainobject.transform.position;
    }
    private void OnDisable()
    {
        guardainobject.transform.position = Pos;
        check = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            guardainobject.transform.position = new Vector3(guardainobject.transform.position.x + GameObject.Find("Player").transform.position.x*Speed* Time.deltaTime, guardainobject.transform.position.y + GameObject.Find("Player").transform.position.y*Speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            guardain.Play("NPC_Guardian_Move1");
            check = true;
        }
    }
}
