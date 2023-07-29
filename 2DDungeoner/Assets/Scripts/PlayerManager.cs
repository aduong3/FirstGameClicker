using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Image healthBarFill;
    private Player playerScript;
    private StatsPanel panelScript;
    private GameObject statButton;
    public TextMeshProUGUI levelText, goldText, xpText, healthText;

    void Start()
    {
        instance = this;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        panelScript = GameObject.Find("UIManager").GetComponent<StatsPanel>();

    }

    public void OnStatClick()
    {
        statButton = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(statButton);
        if(statButton == panelScript.strButton)
        {
            //Debug.Log("strButton was clicked");
            playerScript.strength++;
            
            playerScript.availStat--;
            panelScript.changeAvailStat(playerScript.availStat);
        }
        else if(statButton == panelScript.stamButton)
        {
            //Debug.Log("stamButton was clicked");
            playerScript.stamina++;
            playerScript.availStat--;
            panelScript.changeAvailStat(playerScript.availStat);
        }
        else if(statButton == panelScript.agilityButton)
        {
            playerScript.agility++;
            playerScript.availStat--;
            panelScript.changeAvailStat(playerScript.availStat);
        }
        else
        {
            playerScript.critchance++;
            playerScript.availStat--;
            panelScript.changeAvailStat(playerScript.availStat);
        }
        panelScript.addStat();
    }
        public void onPlayerLevelUp(int level, float availStat)
        {
            levelText.text = "Level: " + level;
            panelScript.changeAvailStat(availStat);
        }

        public void onPlayerDamage(float curHp, float maxHp)
        {
            healthBarFill.fillAmount = curHp/maxHp;
            healthText.text = curHp + "/" + maxHp;
        }

        public void addGoldandXPToPlayer(int gAmount, int xp)
        {
            playerScript.gold += gAmount;
            goldText.text = "Gold:<br>" + playerScript.gold;

            playerScript.currentXP += xp;
            xpText.text = "XP:<br>" + playerScript.currentXP + "/" + playerScript.xpToLevel[playerScript.playerLevel - 1];
        }
}
