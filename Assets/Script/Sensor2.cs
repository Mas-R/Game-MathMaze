using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor2 : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.GetComponent<Operation>() != null)
        {
            string nameOperation = collision.gameObject.GetComponent<Operation>().nameOperation;
            

            if(nameOperation == "Equal")
            {
                anim.SetBool("False", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.GetComponent<Operation>() != null)
        {
            string nameOperation = collision.gameObject.GetComponent<Operation>().nameOperation;
            float index = collision.gameObject.GetComponent<Operation>().index;
            switch (nameOperation)
            {
                case "Addition":
                    {
                        PlayerManager.playernumber = float.Parse((PlayerManager.playernumber + index).ToString("F2"));
                        FindObjectOfType<AudioManager>().PlayOperator();
                        break;
                    }
                case "Subtraction":
                    {
                        PlayerManager.playernumber = float.Parse((PlayerManager.playernumber / index).ToString("F2"));
                        FindObjectOfType<AudioManager>().PlayOperator();
                        break;
                    }
                case "Multiplication":
                    {
                        PlayerManager.playernumber = float.Parse((PlayerManager.playernumber * index).ToString("F2"));
                        FindObjectOfType<AudioManager>().PlayOperator();
                        break;
                    }
                case "Division":
                    {
                        PlayerManager.playernumber = float.Parse((PlayerManager.playernumber - index).ToString("F2"));
                        FindObjectOfType<AudioManager>().PlayOperator();
                        break;
                    }
                case "Equal":
                    {
                        if(PlayerManager.playernumber == index)
                        {
                            anim.SetBool("Correct", true);
                            FindObjectOfType<AudioManager>().CheckFinish("True");
                            PlayerManager.finish = true;
                        }
                        else
                        {
                            FindObjectOfType<AudioManager>().CheckFinish("False");
                            anim.SetBool("False", true);
                        }
                        break;
                    }
                default:
                    break;

            }

            if(collision.gameObject.GetComponent<Animator>())
            {
                StartCoroutine(StartAnim(collision.gameObject.GetComponent<Animator>(), collision));
            }
            
            

        }

    }

    

    IEnumerator StartAnim(Animator anim, Collider2D collision)
    {

        anim.SetBool("Destroy", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(collision.gameObject);

    }
}
