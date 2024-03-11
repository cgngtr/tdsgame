using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int ID;
    public int Health;
    public int Damage;
    public int moveSpeed;
    public float attackCooldown;
    
}
