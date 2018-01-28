using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public GameObject[] sattelites = new GameObject[0];
    public int packetsRequired = 5;
    public int packetsSent = 0;
    public int sattelitesLeft = 5;
    public bool movedMoon = false;
    public GameObject button;
    bool gameIsPaused=false;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name != "Base") movedMoon = true;
        gameObject.GetComponent<LineRenderer>().material.color = Color.red;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            packetsSent = 100;
        }
        if (packetsSent >= packetsRequired)
        {
            ChangePlanet();
            if (!movedMoon) { Camera.main.gameObject.GetComponent<LookAtPlanet>().MoveToMoon(); movedMoon = true; }
            else
            {
                MoveToOtherPlanet();
            }
            packetsRequired = 1;
            packetsSent = 0;
            sattelitesLeft = 10;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else Pause();
        }
	}
    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }
    void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }
    public void CheckSattelites()
    {
        
        sattelites = GameObject.FindGameObjectsWithTag("Sattelite");
        print("checked");
        print(sattelites.Length);
    }
    public void SendPacket()
    {
        GameObject[] ob = GameObject.FindGameObjectsWithTag("observatory");
        foreach (var obvs in ob)
        {
            if (obvs.GetComponent<Radar>().sender)
            {
                obvs.GetComponent<Radar>().SendPacket();
            }
        }
    }
    public void ChangePlanet()
    {
        foreach (var sat in sattelites)
        {
            Destroy(sat);
            CheckSattelites();
        }
    }
    public void MoveToOtherPlanet()
    {
        print(SceneManager.GetActiveScene().name);
        if (movedMoon && SceneManager.GetActiveScene().name == "Base")
        {
            SceneManager.LoadScene("mars");
            SceneManager.UnloadSceneAsync("Base");
        }
        else if (SceneManager.GetActiveScene().name == "mars")
        {

        }
    }
    public void Close()
    {
        Application.Quit();
    }
}
