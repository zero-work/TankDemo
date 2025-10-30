using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;

    public AudioClip dieAudio;
    public Sprite brokenSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Die() 
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        sr.sprite = brokenSprite;

        PlayerManager.Instance.IsDefeat = true;

        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
