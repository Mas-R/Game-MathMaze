using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] string index ;
   
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Operation" && collision.name != "EqualPlace")
        {
            switch (index)
            {
                case "Right":
                    {
                        PlayerManager.abRight = false;
                        break;
                    }
                case "Left":
                    {
                        PlayerManager.abLeft = false;
                        break;
                    }
                case "Up":
                    {
                        PlayerManager.abUp = false;
                        break;
                    }
                case "Down":
                    {
                        PlayerManager.abDown = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        if (collision.tag == "Wall")
        {
            switch(index)
            {
                case "Right":
                    {
                        PlayerManager.bRight = false;
                        break;
                    }
                case "Left":
                    {
                        PlayerManager.bLeft = false;
                        break;
                    }
                case "Up":
                    {
                        PlayerManager.bUp = false;
                        break;
                    }
                case "Down":
                    {
                        PlayerManager.bDown = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            switch (index)
            {
                case "Right":
                    {
                        PlayerManager.bRight = true;
                        
                        break;
                    }
                case "Left":
                    {
                        PlayerManager.bLeft = true;
                        
                        break;
                    }
                case "Up":
                    {
                        PlayerManager.bUp = true;
                        
                        break;
                    }
                case "Down":
                    {
                        PlayerManager.bDown = true;
                        
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        if (collision.tag == "Operation")
        {
            switch (index)
            {
                case "Right":
                    {
                        PlayerManager.abRight = true;

                        break;
                    }
                case "Left":
                    {
                        PlayerManager.abLeft = true;

                        break;
                    }
                case "Up":
                    {
                        PlayerManager.abUp = true;

                        break;
                    }
                case "Down":
                    {
                        PlayerManager.abDown = true;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
