using UnityEngine;
using UnityEngine.UI;

public class ThrowObject : MonoBehaviour
{
    public Button button;
    public GameObject throwObj;
    public Transform cameraTransform;

    public float throwForce = 5f;

    void Start()
    {
        button.onClick.AddListener(Throw);
    }


    // Update is called once per frame
    void Throw() 
    {
        GameObject obj = Instantiate(throwObj, cameraTransform.position, cameraTransform.rotation);


        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)        
        {
            rb.linearDamping = 2f;
            rb.AddForce(cameraTransform.forward * throwForce, ForceMode.Impulse);
        }
    }
}
