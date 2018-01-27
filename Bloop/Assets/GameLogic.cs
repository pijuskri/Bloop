using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    [HideInInspector] public GameObject[] sattelites = new GameObject[0];
    [HideInInspector] public int packetsRequired = 5;
    [HideInInspector] public int packetsSent = 0;
    [HideInInspector] public int sattelitesLeft = 5;
    public GameObject button;
    bool gameIsPaused=false;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (packetsSent >= packetsRequired)
        {
            Camera.main.gameObject.GetComponent<LookAtPlanet>().MoveToMoon();
            packetsRequired = 5;
            packetsSent = 0;
            sattelitesLeft = 5;
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
    public void Close()
    {
        Application.Quit();
    }
}
