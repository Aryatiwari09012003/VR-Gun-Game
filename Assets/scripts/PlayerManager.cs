using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static float health, currentscore;
    public Image healthImage;
    public TMP_Text score;
    public GameObject Gameon, Gameoff, enemies; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            GameOver();
        healthImage.fillAmount = health;
        score.text = currentscore.ToString();
    }

    public void GameStart()
    {
        Gameon.SetActive(true);
        Gameoff.SetActive(false);
        health = 1;
        currentscore = 0;
        score.text = "0";
    }

    public void GameOver()
    {
        foreach (Transform child in enemies.transform)
            child.gameObject.GetComponent<EnemyBehaviour>().Death(); 
        Gameon.SetActive(false);
        Gameoff.SetActive(true);
    }
}
