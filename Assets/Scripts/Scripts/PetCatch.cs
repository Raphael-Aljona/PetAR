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
            // destruir o objeto ap�s 0.3s (d� tempo da anima��o reagir)
            Destroy(other.gameObject);

            animator.SetTrigger("Eating");
        }
    }
}
