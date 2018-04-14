using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Publics
    public float Damage = 10;
    public float MaxHealth = 100;
    public float AttackSpeed = 5; //attacks per second
    public float Deffense = 0; //percent
    public float Health;

    //Privates
    private EnemyController enemyController = null;
    private GameController gameController = null;


	// Use this for initialization
	void Start () {
        Health = MaxHealth;
        enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        InvokeRepeating("AttackEnemy", 1f, 1 / this.AttackSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameController.isBattling)
        {
            CancelInvoke();
        }
	}

    public void TakeDamage(float damage)
    {
        this.Health -= damage*(1-(Deffense/100));
        if (this.Health <= 0)
        {
            this.Health = 0;
            Debug.Log("Player is dead");
            gameController.isBattling = false;
        }
    }
    public void AttackEnemy()
    {
        enemyController.TakeDamage(this.Damage);
        Debug.Log("player attacks" + this.Damage);
    }

}
