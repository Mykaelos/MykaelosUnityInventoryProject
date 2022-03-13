using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float Speed = 0.01f;



    private void Update() {

        float xMove = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        float yMove = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);
        Vector3 movement = new Vector3(xMove, yMove, 0);
        movement.Normalize();

        transform.position += movement * Speed;
            //new Vector3(transform.position.x , transform.position.y, transform.position.z);

    }
}
