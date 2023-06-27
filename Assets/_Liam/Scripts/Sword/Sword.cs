using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    //Input action
    public InputActions action;
    
    public Animator animator;

    [Header("Attack Transform Object and Parameters")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    [Header("Enemy Layer Mask")]
    public LayerMask enemyLayers;

    [Header("Sword Variables")]
    public bool swordEquipped;
    public bool isAttackPressed;
    public int swordCount;

    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();
    }


    // Update is called once per frame
    void Update()
    {
        // Player input for attacking
        if (swordEquipped && !isAttackPressed)
        {
            //Debug.Log("If Statement Worked");
            action.PlayerActions.SwordAttack.started += Attack;
        }

        AttackAnimations();
    }
    // Running Player attack systems
    public void Attack(InputAction.CallbackContext context)
    {
        isAttackPressed = true;
        // Play Attack Anims
        //animator.SetBool("attack", true);

        // Detect Enemies in range of Attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage Enemies
        foreach(Collider enemy in hitEnemies)
        {
            //Debug.Log("We Hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

        swordCount += 1;
    }
    // Running Player Attack Animations
    public void AttackAnimations()
    {
        //Start Attack animation
        if (isAttackPressed && swordCount == 1)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool("Sword", true);
            StartCoroutine(Wait1());
        }
        else if (isAttackPressed && swordCount == 2)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool("Sword", true);
            StartCoroutine(Wait1());
        }
        else if (isAttackPressed && swordCount == 3)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool("Sword", true);
            StartCoroutine(Wait1());
            StartCoroutine(SetZero());
        }
    }

    // Coroutine to deactive bool and animation
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.1f);
        isAttackPressed = false;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sword", false);
    }
    // Coroutine to set sword count to 0
    IEnumerator SetZero()
    {
        yield return new WaitForSeconds(1f);
        swordCount = 0;
        animator.SetInteger("swordCount", swordCount);
    }
    // Function to draw gizmo of attack area
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //Disable and Enable action maps
    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }

}
