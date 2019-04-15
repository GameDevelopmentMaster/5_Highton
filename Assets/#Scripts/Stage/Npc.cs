using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    float Speed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.position = new Vector3(Random.Range(-0.5f, 9.6f), Random.Range(-11.4f, -8.7f), 0);
    }
    void Start()
    {
        Speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x,transform.position.y+Time.deltaTime*Speed,0);
        if(this.transform.position.y > PlayerMove.OutCheck[3].transform.position.y+5)
        {
            this.transform.position =new Vector3(Random.Range(-7.5f,6.5f), PlayerMove.OutCheck[2].transform.position.y-5,this.transform.position.z);
        }
    }
}
