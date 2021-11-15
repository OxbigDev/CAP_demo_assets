using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followChild : MonoBehaviour
{

    // Assign pulbic Variables for use in the unity editor
    [Header("Assign player object")]
    [Tooltip("Drag and drop the object you want the camera to follow here.")]
    public GameObject ball;

    // Assign the consisent offset for the camera
    static Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        // The distance from the ball to the camera
        camOffset = this.transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Update the camera position to the position of the ball
        this.transform.position = ball.transform.position + camOffset;
    }
}
