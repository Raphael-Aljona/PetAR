using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanager : MonoBehaviour
{

    public GameObject telaMenu;
    public GameObject telaCreditos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("foi");
    }

    public void quitar()
    {
        Application.Quit(); 
    }

    public void creditos()
    {
        telaMenu.SetActive(false);
        telaCreditos.SetActive(true);
    }

    public void quitCreditos()
    {
        telaCreditos.SetActive(false);
        telaMenu.SetActive(true);
    }
}
