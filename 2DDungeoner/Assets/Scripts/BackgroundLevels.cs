using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackgroundLevels : MonoBehaviour
{
    public List<Sprite> backgroundList = new();
    public List<GameObject> ButtonList = new();
    public Image background;
    [SerializeField] private GameObject buttonPressed;
    public static BackgroundLevels instance;
    Enemy eScript;
    EnemyManager emScript;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        emScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    public void changeBackground(){
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        //background.GetComponent<Image>();
        //Debug.Log(background.sprite.name);
        for(int i = 0; i < ButtonList.Count; i++)
        {
            if(buttonPressed == ButtonList[i])
            {
                background.sprite = backgroundList[i];
                eScript = GameObject.Find(emScript.curEnemy.name).GetComponent<Enemy>();
                emScript.DefeatEnemy(eScript.gameObject);
                return;
            }
        }
    }

    public void setDungeonPanelActive()
    {
        if(gameObject.activeInHierarchy == false)
        {
        gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
