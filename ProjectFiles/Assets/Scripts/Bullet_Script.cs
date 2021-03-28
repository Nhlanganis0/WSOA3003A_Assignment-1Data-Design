using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public bool EnemyEncounter;
    [SerializeField]PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy");
            PlayerController.EnemyEncounter = true;
        }
        StartCoroutine(BulletDie());
    }

    IEnumerator BulletDie()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
