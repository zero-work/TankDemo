using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Player : MonoBehaviour
{

    public float moveSpeed = 3;


    private bool invincibleState = true;
    private float invincibleTime = 0.3f;

    private Vector3 bullectEulerAngles;

    private float timeVal = 0.4f; 
    private SpriteRenderer sr;

    public Sprite[] sprite;

    public GameObject bullectPrefab;

    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    public AudioSource moveAudio;

    public AudioClip[] tankAudios;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (invincibleTime >= 0) 
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime <= 0) 
            {
                shieldPrefab.SetActive(false);
                invincibleState = false;
            }

        }

        if (timeVal > 0.4f)
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
        float v = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

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

        if (Mathf.Abs(v) > 0.05f)
        {
            moveAudio.clip = tankAudios[1];
            if (!moveAudio.isPlaying) 
            {
                moveAudio.Play();
            }
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

        if (Mathf.Abs(h) > 0.05f)
        {
            moveAudio.clip = tankAudios[1];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudios[0];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }

    }


    public void Die() 
    {

        PlayerManager.Instance.IsDead = true;

        if (invincibleState) return;

        // 激活爆照特效

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // 删除玩家
        Destroy(gameObject);
    }
}
