using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lol : MonoBehaviour {

    float time = 0;
    public GameObject p;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, p.transform.position, 0.01f);
        time += Time.deltaTime;
        if (time > 5)
        {

            SceneManager.LoadScene("menu");
            SceneManager.UnloadSceneAsync("void");
            Cursor.visible = true;
        }
	}
}
