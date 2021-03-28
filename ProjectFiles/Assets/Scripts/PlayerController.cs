using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] PlayerHpBar playerHpBar;
    [SerializeField] EnemyHealt enemyHealt;
    [SerializeField] Rigidbody2D fireball;
    [SerializeField] Rigidbody2D THunder;
    [SerializeField] Rigidbody2D Normal_;
    [SerializeField] Rigidbody2D rb;
    public GameObject PlayAgain;
    public GameObject Player;
    public GameObject Enemy;

    [SerializeField] float speed = 1.0f;
    public static bool EnemyEncounter;
    public bool IsPiercingLightning;
    public bool IsFireball;
    public bool IsPressed;
    public bool IsKicks;

    private void Start()
    {
        enemyHealt = Enemy.GetComponent<EnemyHealt>();
    }
    public void HandleUpdate()
    {
        Shoot();
        rb = GetComponent<Rigidbody2D>();
        var move = new Vector3(Input.GetAxis("Horizontal"),0, 0);
        transform.position += move * speed * Time.deltaTime;
        
        if (enemyHealt.playerhealth <= 0)
        {
            Player.SetActive(false);
            PlayAgain.SetActive(true);
        }
    }
    
    public void PiercingLightning()
    {
        IsPressed = true;
        IsPiercingLightning = true;
        IsFireball = false;
        IsKicks = false;
    } //calls for buttons
    public void Fireball()
    {
        IsPressed = true;
        IsFireball = true;
        IsPiercingLightning = false;
        IsKicks = false;
    }
    public void Kicks()
    {
        IsPressed = true;
        IsKicks = true;
        IsFireball = false;
        IsPiercingLightning = false;
    }

    private void Shoot() 
    {
        if (IsPressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsKicks)
            {
                var fireBullet= Instantiate(Normal_, transform.position, transform.rotation);
                fireBullet.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
                IsPressed = false;
                IsKicks = false;
                StartCoroutine(EndTurn());
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsFireball)
            {
                var fireBullet = Instantiate(fireball, transform.position, transform.rotation);
                fireBullet.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
                IsPressed = false;
                IsFireball = false;
                StartCoroutine(EndTurn());
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsPiercingLightning)
            {
                var fireBullet = Instantiate(THunder, transform.position, transform.rotation);
                fireBullet.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
                IsPressed = false;
                IsPiercingLightning = false;
                StartCoroutine(EndTurn());
            }
        }
    }

    IEnumerator EndTurn()
    {
        gameController.state = GameState.EnemyTurn;
        yield return new WaitForSeconds(1f);
        print("EndTurn");
    }
}
