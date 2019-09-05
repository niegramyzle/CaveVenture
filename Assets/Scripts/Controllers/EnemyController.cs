using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius;
    [SerializeField] private float combatRadius;
    private CharacterMovement charMov;
    private Transform target;
    private CharacterStats stats;
    private Animator anim;
    private bool diedFlag, deathAnimFlag;
    private float attackDistance = 2;

    [SerializeField]
    Weapon weapon;

    private CombatController combatCont;

    public bool IsDied()
    {
        if (!stats.IsDied)
        {
            return false;
        }
        else if (!diedFlag)
        {
            diedFlag = true;
            anim.SetTrigger("Active");
            StartCoroutine(death());
            return true;
        }
        return true;
    }

    private IEnumerator death()
    {
        do
        {
            yield return null;
        } while (!deathAnimFlag);
            anim.SetTrigger("Active");
            gameObject.SetActive(false);
    }

    private void endAnim()
    {
        deathAnimFlag = true;
    }

    private void Start()
    {
        target = PlayerManager.instance.Player.transform;
        combatCont = GetComponent<CombatController>();
        stats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
        charMov = GetComponent<CharacterMovement>(); 
    }

    public bool distanceToPlayer()
    {
        Vector3 distance = transform.position - PlayerManager.instance.Player.transform.position;
        return  Mathf.Sqrt(distance.x*distance.x+distance.y*distance.y+distance.z*distance.z)< attackDistance ? true: false;
    }

    private void follow()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
            (target.position - transform.position), stats.RotationSpeed * Time.deltaTime);
        if(!distanceToPlayer())
            charMov.movement(0, 1, false, false);
    }

    public void UpdateEnemy()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
            follow();
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
