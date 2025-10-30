using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Born : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    public bool isPlayerControll;
    public GameObject[] enemyPrefabs;
    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }


    void BornTank() 
    {

        if (isPlayerControll)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else 
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabs[num], transform.position, Quaternion.identity);
        }
        
    }


}
