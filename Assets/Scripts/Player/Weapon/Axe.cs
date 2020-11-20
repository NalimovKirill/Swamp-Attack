using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Axe : Weapon
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayers;
    private Animator _animator;


    private void Start()
    {
        _animator.GetComponent<Animator>();
    }

    public override void Shoot(Transform shootPoint)
    {
        
    }

    public override void AttackWithAxe()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_shootPoint.position, _attackRange, _enemyLayers);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Takedamage(_damage);
        }
    }
}
