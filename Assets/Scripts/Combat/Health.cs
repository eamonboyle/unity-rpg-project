using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health = 100f;

        private bool dead = false;

        public bool IsDead()
        {
            return dead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            CheckDeath();
        }

        private void CheckDeath()
        {
            if (health <= 0 && !dead)
            {
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                dead = true;
            }
        }
    }
}
