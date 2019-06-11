using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius;
    [SerializeField]
    private float combatRadius;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private CharacterMovement charMov;
    private Transform target;
    private CharacterStats stats; 

    public bool IsDied()
    {
        return stats.IsDied;
    }

    [SerializeField]
    Weapon weapon;

    private CombatController combatCont;

    private void Start()
    {
        target = PlayerManager.instance.Player.transform;
        combatCont = GetComponent<CombatController>();
        stats = GetComponent<CharacterStats>();
    }

    private void wander()
    {
        //todo
    }

    private void follow()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
            (target.position - transform.position), rotationSpeed * Time.deltaTime);
        charMov.movement(0, 1, false, false);
    }

    public void UpdateEnemy()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
            follow();
        else
            wander();
        if (distance < combatRadius)
        {
            Debug.Log("attack");
            weapon.hit();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, combatRadius);
    }
}
