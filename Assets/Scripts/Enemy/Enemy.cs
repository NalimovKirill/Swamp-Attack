using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
   [SerializeField] private int _health;
   [SerializeField] private int _reward;

   [SerializeField] private Player _target;

   private Animator _animator;

   public event UnityAction<Enemy> Dying;

   public int Reward => _reward;
   public Player Target => _target;

   private void Start()
   {
      _animator = GetComponent<Animator>();
   }

   public void Init(Player target)
   {
      _target = target;
   }

   public void Takedamage(int damage)
   {
      _health -= damage;

      if (_health <=0)
      {
         Dying?.Invoke(this);
         _animator.Play("Die");
         Destroy(gameObject,.3f);
      }
   }

   
}
