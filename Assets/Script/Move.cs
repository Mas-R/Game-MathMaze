using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float threshold = 10f;
    private Vector3 startPos, endPos;
    private bool nexttouche = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        startPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (nexttouche == true && PlayerManager.moveplayer == true)
        {
            MoveInput();
        }
#elif UNITY_ANDROID
        if (nexttouche == true && PlayerManager.moveplayer == true)
        {
             MoveTouche();
        }
#endif
    }

    void MoveInput()
    {
        if(Input.GetMouseButton(0))
        {
            if(Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            endPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {

            if (DecidedDirection() != Vector3.zero)
            {
                StartCoroutine(MoveObject(DecidedDirection()));
            }
        }
    }

    void MoveTouche()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            if(touch.phase == TouchPhase.Moved)
            {
                endPos = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if(DecidedDirection() != Vector3.zero)
                {
                    StartCoroutine(MoveObject(DecidedDirection()));
                }
                
            }
        }
    }

    Vector3 DecidedDirection()
    {
        Vector3 direction = Vector3.zero;

        if(Mathf.Abs(endPos.x-startPos.x)> Mathf.Abs(endPos.y - startPos.y))
        {
            if (Mathf.Abs(endPos.x - startPos.x) > threshold)
            {
                if(endPos.x > startPos.x && PlayerManager.bRight == true)
                {
                    
                    if(PlayerManager.abRight)
                    {
                        direction = Vector3.right;
                    }
                    else if (PlayerManager.abRight != true && PlayerManager.abcRight == true)
                    {
                        direction = Vector3.right*2;
                        
                    }
                }
                else if(endPos.x < startPos.x && PlayerManager.bLeft == true)
                {
                    if (PlayerManager.abLeft)
                    {
                        direction = Vector3.left;
                    }
                    else if(PlayerManager.abLeft != true && PlayerManager.abcLeft == true)
                    {
                        direction = Vector3.left * 2;
                        
                    }
                }
                else
                {
                    direction = Vector3.zero;
                }
            }
        }
        else if (Mathf.Abs(endPos.x - startPos.x) < Mathf.Abs(endPos.y - startPos.y))
        {
            if (Mathf.Abs(endPos.y - startPos.y) > threshold)
            {
                if (endPos.y > startPos.y && PlayerManager.bUp == true)
                {
                    if (PlayerManager.abUp)
                    {
                        direction = Vector3.up;
                    }
                    else if(PlayerManager.abUp != true && PlayerManager.abcUp == true)
                    {
                        direction = Vector3.up * 2;
                        
                    }
                }
                else if (endPos.y < startPos.y && PlayerManager.bDown == true)
                {
                    if (PlayerManager.abDown)
                    {
                        direction = Vector3.down;
                    }
                    else if(PlayerManager.abDown != true && PlayerManager.abcDown == true)
                    {
                        direction = Vector3.down * 2;
                        
                    }
                }
                else
                {
                    direction = Vector3.zero;
                }
            }
        }
        return direction;
    }
    

    public IEnumerator MoveObject(Vector3 v3)
    {
        
        nexttouche = false;
        float totalMovementTime = 0.25f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        Vector3 origin = transform.position;
        Vector3 moveto = transform.position + v3;
        while (Vector3.Distance(transform.position, moveto) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.position = Vector3.Lerp(origin, moveto, currentMovementTime / totalMovementTime);

            yield return null;

        }
        nexttouche = true;
    }

}
