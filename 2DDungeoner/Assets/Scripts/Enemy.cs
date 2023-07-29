using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float enemyStrength, enemyDefense, enemyHp, enemySpeed, curHp;
    public int goldToGive, xpToGive, enemyLevel;
    private Player playerScript;
    private EnemyManager emScript;
    private PlayerManager pmScript;
    [SerializeField] private Image enemyHealthBarFill;
    [SerializeField] private TextMeshProUGUI enemyHealthText;
    private float checkPlayerHealth;
    ItemData itemData;
    [SerializeField] private int[] table;
    [SerializeField] private int total;
    [SerializeField] private int randomNumber;
    private Image background;
    public Enemy instance;

    [SerializeField] private List<ItemData> itemList;


private void Awake() {
    instance = this;
}
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        emScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        pmScript = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        background = GameObject.Find("backgroundImage").GetComponent<Image>();
        InvokeRepeating("takeDamage", 0.5f, 1.0f + enemySpeed - playerScript.playerSpd);
    }

    public void takeDamage()
    {
        if(playerScript.playerDmg > (enemyDefense * 0.5f)){
        curHp -= Mathf.Ceil(playerScript.playerDmg - (enemyDefense * 0.5f));
        enemyHealthBarFill.fillAmount = (float) curHp / (float) enemyHp;
        enemyHealthText.text = curHp + "/" + enemyHp;
        }

        if(curHp <= 0)
        {
            Defeated();
            playerScript.currentHP += Mathf.Floor(playerScript.playerHP * 0.10f);
            if(playerScript.currentHP > playerScript.playerHP){

            
            checkPlayerHealth = Mathf.Floor(playerScript.currentHP - playerScript.playerHP);
            playerScript.currentHP = playerScript.currentHP - checkPlayerHealth;
            }
        }

    }

    public void Defeated()
    {
        DropItem();
        checkPlayerLevel();
        PlayerManager.instance.addGoldandXPToPlayer(goldToGive, xpToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);
    }

    public void DropItem()
    {
        total = 0;
        foreach(var item in table)
        {
            total += item;
        }
        randomNumber = Random.Range(0,total);
        for(int i = 0; i < table.Length; i++){
        if(randomNumber <= table[i])
        {
            if(itemList[i].isNull != true){
           Inventory.instance.Add(itemList[i]);
            return;
            }
            else{
                return;
            }
        }
        else
        {
            randomNumber -= table[i];
        }

        }
    }

    public void checkPlayerLevel(){
        if(playerScript.playerLevel >= (enemyLevel + 5))
        {
                xpToGive = Random.Range(0,2);
        }
    }
}
