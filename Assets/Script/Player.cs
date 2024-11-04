using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public TextMeshProUGUI textnumber;
    [SerializeField] int index;
    // Start is called before the first frame update
    private void Start()
    {
        PlayerManager.playernumber = index;
    }
    

    // Update is called once per frame
    void Update()
    {
        textnumber.text = ""+PlayerManager.playernumber;
    }
}
