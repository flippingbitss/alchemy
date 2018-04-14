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

    private float Health;
    private float Speed;

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth;
        Speed = AttackSpeed;
        InvokeRepeating("DoDamage", 0, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        this.Health -= damage * (1 - (Deffense / 100));
        if (this.Health <= 0)
        {
            this.Health = 0;
            Debug.Log("Enemy is dead");
            controller.isBattling = false;
            CancelInvoke();
        }
    }

    public void DoDamage()
    {
        player.TakeDamage(this.Damage);
    }
}
