using UnityEngine;

public class PetCatch : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Alimento"))
        {
            // destruir o objeto após 0.3s (dá tempo da animação reagir)
            Destroy(other.gameObject);

            animator.SetTrigger("Eating");
        }
    }
}
