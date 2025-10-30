using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
：
*/
public class PlayerManager : MonoBehaviour
{

    private int lifeValue = 3;
    private int playerScore = 0;
    private bool isDead;
    private static PlayerManager instance;
    private bool isDefeat;
    public GameObject bornPlayer;

    public Text Score;
    public Text Life;
    public GameObject overImage;

    public int LifeValue { get => lifeValue; set => lifeValue = value; }
    public static PlayerManager Instance { get => instance; set => instance = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public int PlayerScore { get => playerScore; set => playerScore = value; }
    public bool IsDefeat { get => isDefeat; set => isDefeat = value; }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsDefeat) 
        {
            overImage.gameObject.SetActive(false);
            Invoke("ReturnToMainMenu", 3);
            return;
        }
        if (IsDead) 
        {
            Recover();
        }

        Score.text = PlayerScore.ToString();
        Life.text = lifeValue.ToString();
    }

    public void Recover() 
    {
        if (LifeValue <= 0)
        {
            // 游戏结束
            IsDefeat = true;
            Invoke("ReturnToMainMenu", 3);
        }
        else 
        {
            LifeValue--;
            GameObject go = Instantiate(bornPlayer, new Vector3(-2,-8,0), Quaternion.identity);
            go.GetComponent<Born>().isPlayerControll = true;
            isDead = false;
        }
    }

    private void ReturnToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
