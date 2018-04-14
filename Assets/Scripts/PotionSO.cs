// Eddie Song 2017-07-04
// Scriptable object to contain potion data

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Potion", order = 1)]
public class PotionSO : ScriptableObject
{

    public float HealingAmount;
}