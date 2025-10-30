using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class MapControll : MonoBehaviour
{

    public GameObject[] item;


    private List<Vector3> itemPositionList = new List<Vector3>();
    private void Awake()
    {
        InteMap();

    }



    private void InteMap() 
    {
        //DontDestroyOnLoad(gameObject);

        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);

        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);
        }


        // 实例化空气墙
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        // 初始化玩家
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().isPlayerControll = true;

        // 产生敌人
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(-0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4, 5);

        // 实例化地图
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
    }

    private void CreateItem(GameObject createGameObject, Vector3 createPosition, Quaternion createQuaternion) 
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createQuaternion);

        itemGo.transform.SetParent(gameObject.transform);
    }



    /// <summary>
    ///  产生随机位置的方法
    /// </summary>
    /// <returns></returns>
    private Vector3 CreateRandomPosition() 
    {

        // 不生成x = -10,10,y = -8,8两列位置

        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosition)) 
            {
                return createPosition;
            }
        }
    }

    /// <summary>
    /// 判断位置列表中是否有位置
    /// </summary>
    /// <param name="createPosition"></param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    private bool HasThePosition(Vector3 createPosition)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPosition == itemPositionList[i]) return true;
        }

        return false;
    }

    /// <summary>
    /// 产生敌人方法
    /// </summary>
    private void CreateEnemy() 
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();

        switch (num) 
        {
            case 0:
                EnemyPos = new Vector3(-10, 8, 0);
                break;
            case 1:
                EnemyPos = new Vector3(0, 8, 0);
                break;
            case 2:
                EnemyPos = new Vector3(10, 8, 0);
                break;
        }

        CreateItem(item[3], EnemyPos, Quaternion.identity);
    }
}
