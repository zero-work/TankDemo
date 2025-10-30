using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3;

    private Vector3 bullectEulerAngles;

    private float timeVal;
    private float timeValChangeDirection;

    private float v;
    private float h;

    private SpriteRenderer sr;

    public Sprite[] sprite;

    public GameObject bullectPrefab;

    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeVal >= 3f)
        {
            Attack();
        }
        else 
        {
            timeVal += Time.deltaTime;
        }
      


    }


    private void FixedUpdate()
    {
        if (PlayerManager.Instance.IsDefeat)
        {
            return;
        }
        Move();
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeVal = 0;
        }

    }


    private void Move()
    {

        if (timeValChangeDirection >= 4f)
        {
            int num = Random.Range(0, 8);

            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 5)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;

        }
        else 
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        transform.Translate(v * Vector3.right * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = sprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);

        }
        else if (v > 0)
        {
            sr.sprite = sprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);

        }

        if (v != 0) return;



        transform.Translate(h * Vector3.up * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = sprite[2];

            bullectEulerAngles = new Vector3(0, 0, -180);

        }
        else if (h > 0)
        {
            sr.sprite = sprite[0];

            bullectEulerAngles = new Vector3(0, 0, 0);
        }

    }


    public void Die()
    {

        PlayerManager.Instance.PlayerScore += 5;

        // 激活爆照特效

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // 删除玩家
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            timeValChangeDirection = 4;
        }
    }
}
