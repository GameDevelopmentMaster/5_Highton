using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    Vector3 Pos;
    public float Speed;
    private void Awake()
    {
        Pos = transform.position;
    }
    private void OnDisable()
    {
        this.transform.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        transform.position = Pos;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Speed*Time.deltaTime, transform.position.y, transform.position.z);
        if(transform.position.x > PlayerMove.OutCheck[1].transform.position.x+5 || transform.position.x < PlayerMove.OutCheck[0].transform.position.x-5)
        {
            transform.position = Pos;
        }
    }
}
