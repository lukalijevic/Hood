using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    private Vector2 lastMove;
    private Animator anim;
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager theDM;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if(walkZone != null)
        { 
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (!theDM.dialogueActive)
        {
            canMove = true;  
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            
            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            anim.SetFloat("MoveX", Mathf.Sign(myRigidbody.velocity.x));
            if (myRigidbody.velocity.x == 0)
                anim.SetFloat("MoveX", 0.0f);
            anim.SetFloat("MoveY", Mathf.Sign(myRigidbody.velocity.y));
            if (myRigidbody.velocity.y == 0)
                anim.SetFloat("MoveY", 0.0f); // ako radi stavit vector 2 u neku varijablu
            //anim.SetBool("DadoMoving", isWalking);
            //anim.SetFloat("LastMoveX", lastMove.x);
            //anim.SetFloat("LastMoveY", lastMove.y);

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
        anim.SetBool("DadoMoving", isWalking);
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
        //nije dobro
        lastMove = new Vector2(Mathf.Sign(myRigidbody.velocity.x), Mathf.Sign(myRigidbody.velocity.y));
    }

}
