using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int index = 0;
    public static int loopingAd = 4;
    public static bool bUp = true;
    public static bool bDown = true;
    public static bool bLeft = true;
    public static bool bRight = true;
    public static bool abUp = true;
    public static bool abDown = true;
    public static bool abLeft = true;
    public static bool abRight = true;
    public static int level;
    public static bool abcUp = true;
    public static bool abcDown = true;
    public static bool abcLeft = true;
    public static bool abcRight = true;
    public static float playernumber = 1f;
    public static bool finish = false;
    public static bool moveplayer = true;
    private void Awake()
    {
        moveplayer = true;
        Time.timeScale = 1f;
        bUp = true;
        bDown = true;
        bLeft = true;
        bRight = true;
        abUp = true;
        abDown = true;
        abLeft = true;
        abRight = true;
        abcUp = true;
        abcDown = true;
        abcLeft = true;
        abcRight = true;
        playernumber = 1f;
        finish = false;
    }     
}
