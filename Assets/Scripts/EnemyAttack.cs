using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemyScript;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyScript.AttackPlayer();
        }
    }
}
