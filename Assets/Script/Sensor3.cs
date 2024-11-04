using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor3 : MonoBehaviour
{

    [SerializeField] string index;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            switch (index)
            {
                case "Right":
                    {
                        PlayerManager.abcRight = false;
                        break;
                    }
                case "Left":
                    {
                        PlayerManager.abcLeft = false;
                        break;
                    }
                case "Up":
                    {
                        PlayerManager.abcUp = false;
                        break;
                    }
                case "Down":
                    {
                        PlayerManager.abcDown = false;
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
                        PlayerManager.abcRight = true;

                        break;
                    }
                case "Left":
                    {
                        PlayerManager.abcLeft = true;

                        break;
                    }
                case "Up":
                    {
                        PlayerManager.abcUp = true;

                        break;
                    }
                case "Down":
                    {
                        PlayerManager.abcDown = true;

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
