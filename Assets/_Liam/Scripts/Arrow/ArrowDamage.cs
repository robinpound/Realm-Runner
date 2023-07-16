using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.2f;
    public int attackDamage = 15;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            gameObject.SetActive(false);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
