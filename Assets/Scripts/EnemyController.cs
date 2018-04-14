using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public PlayerController player;
    public GameController controller;
    public float Damage = 10;
    public float MaxHealth = 100;
    public float AttackSpeed = 5; //attacks per second
    public float Deffense = 0; //percent
    public bool isDead = false;
    public int level = 1;

    private float Health;
    private float Speed;
    private float Level;
    private float Def;

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth * level;
        Speed = AttackSpeed * level;
        Def += Deffense * level;

        Level = level;
        InvokeRepeating("DoDamage", 0, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(!controller.isBattling || isDead)
        {
            CancelInvoke();
        } else
        {
            InvokeRepeating("DoDamage", 0, Speed);
            InvokeRepeating("HealOverTime", 60, Speed * 10);
        }

        
    }

    public void HealOverTime()
    {
        this.Health += 30;
        Debug.Log("Enemy healed for 30 points");
    }

    public void TakeDamage(float damage)
    {
        this.Health -= damage * (1 - (Deffense / 100));
        if (this.Health <= 0)
        {
            CancelInvoke();
            this.Health = 0;
            Debug.Log("Enemy is dead");
            controller.isBattling = false;
            isDead = true;
        }
    }

    public void DoDamage()
    {
        player.TakeDamage(this.Damage);
    }

    public void LevelUpEnemy()
    {
        isDead = false;
        level += 1;
    }
}
