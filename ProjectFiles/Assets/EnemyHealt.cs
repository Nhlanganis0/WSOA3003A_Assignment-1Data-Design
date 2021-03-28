using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] HpBar hpBar;

    [SerializeField] GameObject Text;
    Text lifeDisplay;

    public GameObject EnemyToDisabel;
    public float playerhealth;
    float AttacAmount;
    float health;
    
    void Start()
    {
        health = 1f;
        playerhealth = 1f;
        AttacAmount = .2f;
        lifeDisplay = Text.GetComponent<Text>();
    }

    private void Update()
    {
        
        if (this.name == "Normal_1" & health <= 0)
        {
            EnemyToDisabel.SetActive(false);
        }
        else if (this.name == "Normal_2" & health <= 0)
        {
            EnemyToDisabel.SetActive(false);
        }
        else if (this.name == "Rock" & health <= 0)
        {
            EnemyToDisabel.SetActive(false);
        }
        if (this.name == "Ice" & health <= 0)
        {
            EnemyToDisabel.SetActive(false);
        }
    }
    public void TakeDamage(float damageAmount)//damage to enemy
    {
        health -= damageAmount;
    }
    public void AttackPlayer(float AttackAmount)
    {
        playerhealth -= AttackAmount;
        print("playerhealth: " + playerhealth);
    }

    public void SetupAttack() //attack player by base attack of 10% and switch state to player state
    {
        StartCoroutine(DelayAttack());
        gameController.state = GameState.PlayerTurn;
    }
    public void SetUpEnemyHP() //set enemy HP to HPbar slider
    {
        hpBar.SetupEnemyhp(health);
    }

    IEnumerator DelayAttack() //delay enemy attack and displayin player hp
    {
        yield return new WaitForSeconds(2f);
        AttackPlayer(AttacAmount);
        lifeDisplay.text = playerhealth.ToString("F1");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerController.EnemyEncounter)
        {
            TakeDamage(.1f); //base attack for all attacks 
            Debug.Log(health);
            SetUpEnemyHP();
            
            if (collision.gameObject.CompareTag("PiercingLightning") & this.name == "Normal_1") //if normal type enemy is struck by lightning extra damage
            {
                TakeDamage(.2f);
                Debug.Log(health);
                print("Normal 1 encountered");
                SetUpEnemyHP();
            }
            else if (collision.gameObject.CompareTag("PiercingLightning") & this.name == "Normal_2")
            {
                TakeDamage(.2f);
                Debug.Log(health );
                print("Normal 2 encountered");
                SetUpEnemyHP();
            }

            else if (collision.gameObject.CompareTag("PiercingLightning") & this.name == "Ice")
            {
                TakeDamage(.1f);
                Debug.Log(health);
                print("ice encountered");
                SetUpEnemyHP();
            }

            else if (collision.gameObject.CompareTag("Fireball") & this.name == "Ice") //if ice type enemy is struck by a fireball extra damage
            {
                TakeDamage(.2f);
                Debug.Log(health);
                print("Ice encountered");
                SetUpEnemyHP();
            }
            else if (collision.gameObject.CompareTag("Fireball") & this.name == "Rock")//less damaje if fireball jits rock type enemy
            {
                TakeDamage(.05f);
                Debug.Log(health);
                print("Rock encountered");
                SetUpEnemyHP();
            }
            else if (collision.gameObject.CompareTag("NormalKicks") & this.name == "Rock" || this.name == "Ice")//fightning move (kicks) are extra effective on rock and ice type enemy
            {
                TakeDamage(.2f);
                Debug.Log(health);
                print("IceRoc encountered");
                SetUpEnemyHP();
            }
        }
    }
}
