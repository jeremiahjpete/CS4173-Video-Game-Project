using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float attackRange = 2f;
    public float speed, health;
    public float damage = 1;
    public float attackSpeed = 1f;

    public GameObject Oni;
    public Transform player;

}
