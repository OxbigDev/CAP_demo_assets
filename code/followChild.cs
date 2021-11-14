using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followChild : MonoBehaviour
{
    
    // Here we assign values which are unique to this
    Vector3 deltapos;
    // This static keyword is called an accessor method
    // essentially it means that this variable will never change in value
    static Vector3 childpos;

    // Start is called before the first frame update
    void Start()
    {
        // get the position of the child in world coordinates
        childpos = UpdateChildPos();
        // delta from player to cam
        // this is a constant value used to calulate the new coordinates of the camera
        deltapos = this.transform.position - childpos;
    }

    // Update is called once per frame
    void Update()
    {
        // calculate new position
        this.transform.position = childpos + deltapos;
        
        // Update the position of the ball
        childpos = UpdateChildPos();        
    }

    Vector3 UpdateChildPos()
    {
        // get the position of the ball and conver the local coordinates of the ball to world coordinates
        return transform.TransformPoint(this.gameObject.transform.GetChild(0).position);
    }
}
