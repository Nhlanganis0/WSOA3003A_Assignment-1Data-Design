using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls Game states btw player and enemy turns
public enum GameState
{
    PlayerTurn,
    EnemyTurn
}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] EnemyHealt enemyHealt;
    public GameObject Abilities;
    public GameObject AttackButton;
    public GameObject DefendButton;

    public GameState state;

    private void Update()
    {
        if(state == GameState.PlayerTurn)
        {
            PlayerTurn();
        }
        else if(state == GameState.EnemyTurn)
        {
            EnemyTurn();
        }
    }
   
    public void EnemyTurn()
    {
        enemyHealt.SetupAttack();
        Abilities.SetActive(false);
        AttackButton.SetActive(false);
        DefendButton.SetActive(false);
    }
    public void PlayerTurn()
    {
        playerController.HandleUpdate();
        AttackButton.SetActive(true);
        DefendButton.SetActive(true);
    }
    public void Attack()
    {
        Abilities.SetActive(true);
        AttackButton.SetActive(false);
        DefendButton.SetActive(false);
    }
    public void Defend()
    {
        state = GameState.EnemyTurn;
        enemyHealt.playerhealth = enemyHealt.playerhealth + 1f;
        print("Defend" + enemyHealt.playerhealth);
    }
}
