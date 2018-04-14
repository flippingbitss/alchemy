using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Publics
    public float Damage = 10;
    public float MaxHealth = 100;
    public float AttackSpeed = 5; //attacks per second
    public float Deffense = 0; //percent

    //Privates
    private float Health;
    private GameObject Enemy = null;
    private GameController gameController = null;


	// Use this for initialization
	void Start () {
        Health = MaxHealth;
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
