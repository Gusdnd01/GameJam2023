using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
   public float speed = 5f;

   public float attackDistance = 2f;
   public float checkDistance = 2f;
   public float cycleDelay = 1f;
}
