using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : IPotion
{
    public float healing = 30;
    public string Name { get { return "Health Potion"; } }
   

    public void Consume(PlayerController pc)
    {
        pc.Health += healing;
        if (pc.Health > pc.MaxHealth)
        {
            pc.Health = pc.MaxHealth;
        }
    }
}
