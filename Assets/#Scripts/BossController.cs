using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int hp = 100;
    public float moveSpeed = 1;

    public int dir1 = 0; // 1 left 2 right
    public int dir2 = 0; // 1 left 2 right

    public Vector3 currentPosition;

    public float endPosition1;
    public float endPosition2;

    public GameObject prefabBall, prefabMyBall;

    private bool isAttack;

    private void Start()
    {
        dir1 = 1;
        dir2 = 1;

        endPosition1 = -7f;
        endPosition2 = 1f;

        CreateBall();

        AudioManager.Instance.PlayBgm(4);
    }

    private void Move()
    {
        if (dir1 == 1)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= endPosition1)
            {
                endPosition1 = 7f;
                dir1 = 2;
            }
        }
        else if (dir1 == 2)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= endPosition1)
            {
                endPosition1 = -7f;
                dir1 = 1;
            }
        }

        if(hp <= 40)
            if (dir2 == 1)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

                if (transform.position.y <= endPosition2)
                {
                    endPosition2 = 3f;
                    dir2 = 2;
                }
            }
            else if (dir2 == 2)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

                if (transform.position.y >= 3)
                {
                    endPosition2 = 1f;
                    dir2 = 1;
                }
            }
    }

    public void CreateBall()
    {
        StartCoroutine(CorCreateBall());
    }

    private IEnumerator CorCreateBall()
    {
        if (hp >= 80)
        {
            GameObject ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 180);

            moveSpeed += 0.1f;
        }
        else if (hp >= 60)
        {
            GameObject ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 135);

            ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 180);

            ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 225);

            moveSpeed += 0.2f;
        }
        else if (hp >= 40)
        {
            GameObject ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 135);

            ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 180);

            ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 225);

            moveSpeed += 0.3f;
        }
        else if (hp >= 20)
        {
            GameObject ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 90);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 135);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 180);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 225);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 260);

            moveSpeed += 0.4f;
        }
        else
        {
            GameObject ball = Instantiate(prefabBall);

            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 100);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 120);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 140);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 160);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 180);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 200);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 220);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 240);

            ball = Instantiate(prefabBall);
            ball.transform.position = transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 260);

            moveSpeed += .5f;
        }

        yield return new WaitForSeconds(.7f);
        CreateBall();
    }

    public void CheckAttack()
    {
        if(Input.GetMouseButtonDown(0) & !isAttack)
        {
            GameObject ball = Instantiate(prefabMyBall);
            ball.transform.position = GameObject.Find("Player").transform.position;
            ball.transform.rotation = Quaternion.Euler(0, 0, 0);

            AudioManager.Instance.PlayShot();

            StartCoroutine(CorCheckAttack());
        }
    }

    private IEnumerator CorCheckAttack()
    {
        isAttack = true;
        yield return new WaitForSeconds(.7f);
        isAttack = false;
    }

    private void Update()
    {
        Move();
        CheckAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MyBall")
        {
            hp -= 5;
            UIManager.Instance.ChangeBossHP(hp);

            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                UIManager.Instance.GameClear();
                
                Destroy(gameObject);
            }
        }
    }
}
