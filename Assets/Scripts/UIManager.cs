using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class UIManager : MonoBehaviour
{
    public GameObject itemsMenu;
    public GameObject backButton;
    private UIDocument uiDoc;
    private ObjectSpawner spawner;

    public bool isMenuOpen = false;

    private void Awake()
    {
        uiDoc = itemsMenu.GetComponent<UIDocument>();
    }

    public void OpenItems()
    { 
        uiDoc.rootVisualElement.visible = true;
        isMenuOpen = true;
    }

     
    public void CloseItems()
    {
        uiDoc.rootVisualElement.visible = false;
        isMenuOpen = false;
    }

    public void EnableButton()
    {
        backButton.SetActive(true);
    }

    public void DisableButton()
    {
        backButton.SetActive(false);
    }

    public string url;
    public void OpenLink() {
        Application.OpenURL(url);
    }
}
