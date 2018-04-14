using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BuffsController : MonoBehaviour
{

    public List<IPotion> potions;
    public IPotion activePotion;

    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (activePotion != null)
            {
                activePotion.Consume(playerController);
            }
        }

    }

    public void AddPotion(IPotion potion){
        Debug.Log("added potion " + potion.Name);
        potions.Add(potion);
    }

    public void SelectPotion(int index){
        if (index < 0 || index >= potions.Count) return;
        activePotion = potions[index];
    }
}
