using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ARObjectSelector : MonoBehaviour
{
    public XRBaseInteractor interactor;
    public GameObject selectedObject;

    void OnEnable()
    {
        interactor.selectEntered.AddListener(OnSelectEntered);
        interactor.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        interactor.selectEntered.RemoveListener(OnSelectEntered);
        interactor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        selectedObject = args.interactableObject.transform.gameObject;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        //selectedObject = null;
    }

    public void DeleteSelected()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
            selectedObject = null;
        }
    }
}
