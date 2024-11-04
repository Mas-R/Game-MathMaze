using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Operation : MonoBehaviour
{
    public float index;
    public string nameOperation;
    public TextMeshProUGUI tmp;
    private void Start()
    {
        tmp.text = "" + index;
    }
}
