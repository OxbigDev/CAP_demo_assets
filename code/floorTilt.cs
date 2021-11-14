using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTilt : MonoBehaviour
{

    // Public attributes which are controlled in the unity editor
    [Header("Place Gameobjects here")]
    [Tooltip("Drag your ground here")]
    public Transform rotation;
    [Tooltip("This number will control how fast the floor moves when you tilt your phone")]
    public float tiltSpeed;

    // Private atributes which are used by this class
    // notice that they are invisible in the unity editor
    Vector3 phoneTilt; // this is where we will store input from the phone
    float smooth = 5f; // used to make our rotation more fluid

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from phone's accelerometer
        phoneTilt = Input.acceleration;

        // Ensure that erroneous values are corrected back to 1
        if (phoneTilt.sqrMagnitude > 1)
        {
            phoneTilt.Normalize();
        }

        // Debug statement test phone tilt reading
        print($"detected tilt at : {phoneTilt}");

        // A quaternion is a special type of 4D number used for tracking rotation
        // this command converts our Vector3 phone input into a quaternion
        // read more here: https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
        Quaternion target = Quaternion.Euler(phoneTilt * tiltSpeed);

        // before we update the rotation of the floor we need to create some boundaries
        // if we don't do this our playing space will be doing barrel rolls
        if (Mathf.Abs(rotation.rotation.x) >= 90) {
            target.x = 89f;
        }
        if (Mathf.Abs(rotation.rotation.z) >= 90) {
            target.z = 89f;
        }

        // Now we need to apply this rotation to our current rotation of the floor
        // Slerp stands for shereical interpolation
        // what we are doing here is saying we want to go from a to b in steps of deltatime*smooth
        // this function fills in the blanks between a and b
        // Read more here: https://docs.unity3d.com/ScriptReference/Quaternion.Slerp.html
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
