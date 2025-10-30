using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
：
*/
public class SelectMode : MonoBehaviour
{

    private int option;
    public Transform option1;
    public Transform option2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            option = 1;
            transform.position = option1.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            option = 2;
            transform.position = option2.transform.position;
        }
        if (option ==1 && Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(1);
        }

        if (option == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
