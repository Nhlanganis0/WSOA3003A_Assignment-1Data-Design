using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] GameObject Enemyhealth;
    
   public void SetupEnemyhp(float hpNormalisedhp)
    {
        Enemyhealth.transform.localScale = new Vector3(hpNormalisedhp, 1f);
    }
}
