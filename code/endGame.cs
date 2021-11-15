using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    [Header("Place Game Objects here")]
    [Tooltip("Drag and drop your game over screen here")]
    public GameObject gameOverPanel;
    [Tooltip("Drag and drop the goal post here")]
    public GameObject goalPost;
    [Tooltip("Drag and drop the ball here")]
    public GameObject ball;
    [Tooltip("Enter the time to restart the level here")]
    public float restartTime = 12.0f;
    
    Scene _thisScene;

    // Start is called before the first frame update
    void Start()
    {
        _thisScene = SceneManager.GetActiveScene();

        if (gameOverPanel.activeSelf) {
            gameOverPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            gameOverPanel.SetActive(true);
            Invoke("restartLevel", restartTime);
        }
    }

    void restartLevel() {
        SceneManager.LoadScene(_thisScene.name);
    }
}
