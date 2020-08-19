using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEditor;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5f;

        private Fighter fighter;
        private Mover mover;
        private Health health;
        private GameObject player;

        private Vector3 guardLocation;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");

            guardLocation = transform.position;
        }

        private void Update()
        {
            if (health.IsDead())
            {
                return;
            }

            if (InAttackRange() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                // cancel fighting and go back to start location
                mover.StartMoveAction(guardLocation);
            }
        }

        private bool InAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}