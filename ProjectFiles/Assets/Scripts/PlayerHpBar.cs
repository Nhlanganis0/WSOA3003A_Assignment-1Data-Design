using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] EnemyHealt enemyHealt;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Text;
   
    public Text lifeDisplay;
    private void Start()
    {
        enemyHealt = enemy.GetComponent<EnemyHealt>();
        lifeDisplay = Text.GetComponent<Text>();
        
    }
    private void Update()
    {
        lifeDisplay.text = enemyHealt.playerhealth.ToString("F1");
    }
}
