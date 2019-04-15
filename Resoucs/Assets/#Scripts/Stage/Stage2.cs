using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public float Speed=1;
    float time;
    public Animator animator;
    public GameObject Mom;
    Vector3 Startpos, endpos;
    private void OnEnable()
    {
        Mom.SetActive(false);
        time = Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.3f)
        {
            Mom.SetActive(true);
        }
        if (Mom.activeSelf)
        {
            Startpos = Mom.transform.position;
            endpos = new Vector3(7.2f, -2.88f,0);
            Mom.transform.position = Vector3.MoveTowards(Startpos, endpos, Speed);
            Debug.Log(Mom.transform.position);
        }
    }
}
