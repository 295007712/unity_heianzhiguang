using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMove move;
    private Animation animation;
    void Start()
    {
        move = this.GetComponent<PlayerMove>();
        animation = this.GetComponent<Animation>();
    }

    private void LateUpdate()
    {
        if(move.state == PlayState.Moving)
        {
            PlayAnim("Run");
        }else if(move.state == PlayState.Idle)
        {
            PlayAnim("Idle");
        }
    }

    void PlayAnim(string animName)
    {
        animation.CrossFade(animName);
    }
}
