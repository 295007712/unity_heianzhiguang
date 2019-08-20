using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayState
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;
    public PlayState state = PlayState.Idle;
    private PlayerDir dir;
    private CharacterController controller;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        dir = this.GetComponent<PlayerDir>();
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(dir.targetPosition, transform.position);
        if(distance > 0.1f)
        {
            isMoving = true;
            state = PlayState.Moving;
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            isMoving = false;
            state = PlayState.Idle;
        }
    }
}
