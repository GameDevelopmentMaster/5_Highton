using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6 : MonoBehaviour
{
    public Animator[] animators; 
    public float Spped;
    public GameObject Soccor;
    bool check;
    private void OnEnable()
    {
        for(int i=0; i<6;i++)
        {
            Soccor.transform.position = new Vector3(Soccor.transform.position.x - 1 * Time.deltaTime, Soccor.transform.position.y, Soccor.transform.position.z);
        }
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
            Soccor.transform.position = new Vector3(Soccor.transform.position.x + Spped * Time.deltaTime, Soccor.transform.position.y, Soccor.transform.position.z);
        }   
        if (!check)
        {
            Soccor.transform.position = new Vector3(Soccor.transform.position.x - Spped * Time.deltaTime, Soccor.transform.position.y, Soccor.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "check1")
        {
            animators[0].Play("SoccorAnimationRight");
            check = true;
            Spped += 0.3f;
            
        }
        if (collision.name == "check2")
        {
            animators[1].Play("SoccorAnimation");
            check = false;
            Spped += 0.3f;
        }
    }
}
