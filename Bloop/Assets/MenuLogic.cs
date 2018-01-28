using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {

    public GameObject credits;
    public GameObject menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Menu()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }
    public void Credits()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Base");
        SceneManager.UnloadSceneAsync("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
