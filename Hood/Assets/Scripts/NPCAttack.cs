using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour {

    public float WaitBeweenAttacks = 2.0f;

    public bool ShouldFollow = false;

    private float _stopwatch = 0.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShouldFollow = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _stopwatch += Time.deltaTime;
            if (_stopwatch >= WaitBeweenAttacks)
            {
                //TODO: hpmanager i animator
              /*  anim.SetFloat("MoveX", Mathf.Sign(myRigidbody.velocity.x));
                if (myRigidbody.velocity.x == 0)
                    anim.SetFloat("MoveX", 0.0f);
                anim.SetFloat("MoveY", Mathf.Sign(myRigidbody.velocity.y));
                if (myRigidbody.velocity.y == 0)
                    _stopwatch = 0.0f;*/
            }
        }
    }

    //TODO: vidjet dal želiš
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _stopwatch = 0.0f;
        }
    }
}
