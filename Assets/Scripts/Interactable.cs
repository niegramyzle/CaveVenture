using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
