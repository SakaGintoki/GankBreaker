using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gang : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gang1"))
        {
            Debug.Log("gang1");
            sceneToLoad = "FPS1";
            enterAllowed = true;
        }
        else if (collision.CompareTag("gang2"))
        {
            Debug.Log("gang2");
            sceneToLoad = "FPS2";
            enterAllowed = true;
        }
        else if (collision.CompareTag("gang3"))
        {
            Debug.Log("gang3");
            sceneToLoad = "FPS3";
            enterAllowed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enterAllowed && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
