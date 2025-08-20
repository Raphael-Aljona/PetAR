using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PetSpawnerGround : MonoBehaviour
{
    [Header("Referências")]
    public GameObject petPrefab;
    public ARRaycastManager raycastManager;

    private GameObject spawnedPet;

    [Header("Input Actions")]
    public InputActionProperty touchPress;    // PrimaryContact
    public InputActionProperty touchPosition; // PrimaryPosition

    void OnEnable()
    {
        touchPress.action.Enable();
        touchPosition.action.Enable();
    }

    void OnDisable()
    {
        touchPress.action.Disable();
        touchPosition.action.Disable();
    }

    void Update()
    {
        // Ignora os toques feitos na UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (touchPress.action.WasPressedThisFrame())
        {
            Vector2 screenPosition = touchPosition.action.ReadValue<Vector2>();

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedPet == null)
                {
                    // Faz o pet spawnar na posição clicada e também olhando para a câmera
                    spawnedPet = Instantiate(petPrefab, hitPose.position, hitPose.rotation);
                    //spawnedPet = Instantiate(petPrefab, hitPose.position, Quaternion.LookRotation(Camera.main.transform.forward));
                    spawnedPet.transform.Rotate(0, 180f, 0, Space.Self);

                }
                else
                    spawnedPet.transform.position = hitPose.position;
            }
        }
    }
}
