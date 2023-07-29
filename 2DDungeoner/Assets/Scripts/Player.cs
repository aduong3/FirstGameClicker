using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float availStat, strength, stamina, agility, critchance;
    public float playerDmg, playerHP, playerSpd, playerCrit, currentHP;
    public int playerLevel, currentXP, gold;
    public int[] xpToLevel;
    public static Player instance;
    private PlayerManager pmScript;
    private EnemyManager emScript;
    private Enemy eScript;

    private void Start()
    {
        instance = this;
        pmScript = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        emScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        playerStats();
        currentHP = playerHP;
        takeDamageTicker();
        
    }

    private void Update() 
    {
        onLevelUp();
        playerStats();
        onPlayerDeath();
    }
    
    public void playerStats()
    {
        playerDmg = 1.0f + (strength * 0.4f) + (playerLevel * 0.25f);
        
        playerHP = 50.0f + (stamina * 10.0f) + (playerLevel * 5.0f);

        playerSpd = 0.25f + (agility * 0.005f) + (playerLevel * 0.005f);

        playerCrit = 5.0f + (critchance * 0.0075f) + (playerLevel * 0.005f);
    }

    public void onLevelUp()
    {
        if(currentXP >= xpToLevel[playerLevel - 1])
        {
            currentXP -= xpToLevel[playerLevel - 1];
            pmScript.xpText.text = "XP:<br>" + currentXP + "/" + xpToLevel[playerLevel - 1];
            playerLevel++;
            currentHP = playerHP;
            availStat += 3.0f;
            pmScript.onPlayerLevelUp(playerLevel, availStat);
        }
    }

    public void takeDamageTicker()
    {
        eScript = GameObject.Find(emScript.curEnemy.name).GetComponent<Enemy>();
        InvokeRepeating("damageAmountToTake", 1.0f, 1.0f + playerSpd - eScript.enemySpeed);
    }

    public void damageAmountToTake()
    {
        eScript = GameObject.Find(emScript.curEnemy.name).GetComponent<Enemy>();
        if((strength * 0.25f) <= eScript.enemyStrength){
        currentHP -= Mathf.Ceil(eScript.enemyStrength - (strength * 0.25f));
        }
        pmScript.onPlayerDamage(currentHP, playerHP);
    }

    public void onPlayerDeath()
    {
        if(currentHP <= 0)
        {
            currentHP = playerHP;
            currentXP = (currentXP * 6)/10;
        }
    }

}
