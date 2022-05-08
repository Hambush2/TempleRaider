using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //gets the raw movement of the mouse
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //smooths the movement of the camera
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        //Stops the camera being aimed to far up or down
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        //rotates the camera and the player model based on the smoothed movement of the mouse
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}