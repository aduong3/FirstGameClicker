using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsPanel : MonoBehaviour
{
    public GameObject statsMenu, strButton, stamButton, agilityButton, critButton;
    public TextMeshProUGUI availStatText, strengthText, staminaText, agilityText, critText;
    public static StatsPanel instance;
    private Player playerScript;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        changeAvailStat(playerScript.availStat);
    }

    private void openStatsMenu()
    {
        if(statsMenu.activeInHierarchy == false){
        statsMenu.SetActive(true);
        }
        else{
            statsMenu.SetActive(false);
        }

    }


    public void addStat()
    {
            strengthText.text = "Strength:<br>" + playerScript.strength;

            staminaText.text = "Stamina:<br>" + playerScript.stamina;

            agilityText.text = "Agility:<br>" + playerScript.agility;

            critText.text = "Critical Chance:<br>" + playerScript.critchance;
    }

    public void changeAvailStat(float availStat)
    {
        availStatText.text = "Attribute Stat Available:<br>" + availStat;


        if(playerScript.availStat == 0)
        {
            strButton.SetActive(false);
            stamButton.SetActive(false);
            agilityButton.SetActive(false);
            critButton.SetActive(false);
        }
        else
        {
            strButton.SetActive(true);
            stamButton.SetActive(true);
            agilityButton.SetActive(true);
            critButton.SetActive(true);
        }


    }

}
