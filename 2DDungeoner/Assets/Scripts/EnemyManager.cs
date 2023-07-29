using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Enemy curEnemy;
    public Transform spawnHere;
    private Enemy eScript;
    private Player playerScript;
    GameObject enemySpawn;
    Image bgCheck;

    public static EnemyManager instance;

    void Awake()
    {
        instance = this;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        bgCheck = GameObject.Find("backgroundImage").GetComponent<Image>();
        CreateNewEnemy();

    }



    public void CreateNewEnemy()
    {
        //Debug.Log(bgCheck.sprite.name);
        if(bgCheck.sprite.name == "fieldLevel"){
        enemySpawn = enemyPrefabs[Random.Range(0,3)];
        // for int Random.Range(inclusive,exclusive)
        // if float Random.Range(minInclusive, maxInclusive)
        //Between 0 - 2
        }
        else if(bgCheck.sprite.name == "forestLevel")
        {
            enemySpawn = enemyPrefabs[Random.Range(3,5)];
            //Between 3 - 4
        }
        GameObject obj = Instantiate(enemySpawn, spawnHere);

        curEnemy = obj.GetComponent<Enemy>();
        curEnemy.name = enemySpawn.name;
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);
        CreateNewEnemy();
    }



}
