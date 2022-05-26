using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 input;
    [SerializeField]
    private float speedX, speedY, speedZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal") * speedX, Input.GetAxis("Fly") * speedY, Input.GetAxis("Vertical") * speedZ);
        if (Input.GetKey(KeyCode.LeftShift))
            input *= 3;
        transform.Translate(input*Time.deltaTime, Space.World);
    }
}
