using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeeleCombatSystem : MonoBehaviour
{
    /*
    // Start is called before the first frame update

    //Cundo se tenga el sistema de animacion se usara esto;
   // public Animation animator;
    public Transform attackPoint;
    public float attackRange = 8.5f;
    public const float HIGTH_BOX = 4.0f;
    

     [SerializeField]public LayerMask EnemyLayer;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time ==  nextAttackTime )
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        //Esto es solo para el jugador pero se puede usar para IA
   
    }
    void Attack()
    {
       //animator.SetTrigger(Attack);
      Vector2 AttackRange = new Vector2(attackRange, HIGTH_BOX);
    Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, AttackRange, EnemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            //Esto va a tener que ser modificado para poder ser usado con varios enemigos tal vez tenga que hacer un "arbol de daño"
            //Usando un systema mas generico de arboles pueda hacer Crear un sistema de daños para cada arma y que el juego solo tenga que cargarlo
            // Hay que investigar sobre los nodos y claro sobre como hacer para que eso funcione por supuesto
            //otra solucion es poder crearlo de forma mas robusta y hacer que el daño se cargue automaticamente segun los parametros de las balas supongamos
            //Otra solucion es el polimorfismo no estoy seguro en este caso.
           
            enemy.GetComponent<CEnemy>().TakeDamage(attackDamage);
        } 
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Vector2 size = new Vector2(attackRange, HIGTH_BOX);
        Gizmos.DrawWireCube(attackPoint.position, size);
    }
    */
}

