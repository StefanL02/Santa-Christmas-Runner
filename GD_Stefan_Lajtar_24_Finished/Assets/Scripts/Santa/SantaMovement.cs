using Assets.Scripts.Observer;
using System.Collections;
using UnityEngine;

public class SantaMovement : Subject<IObserver>
{
    public static float movementSpeed = 5f;
    public float leftAndRightSpeed = 5.0f;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject santaObject;

    private void Start()
    {
        //Debug.Log("Testing debug.log");
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World);

        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > MapBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftAndRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < MapBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftAndRightSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if(isJumping == false)
                {
                    isJumping = true;
                    santaObject.GetComponent<Animator>().Play("HumanoidJumpUp");
                    StartCoroutine(JumpSequence());
                }
            }
        }
        if (isJumping == true)
        {
            if(comingDown== false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
            }

            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -4, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");
            NotifyObservers();
        }
    }
    IEnumerator JumpSequence()
    {
        float initialHeight = transform.position.y;
        yield return new WaitForSeconds(0.5f);
        comingDown = true;
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
        comingDown = false;
        santaObject.GetComponent<Animator>().Play("HumanoidRun");
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
    }
}
