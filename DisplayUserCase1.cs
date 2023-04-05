using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUserCase1 : MonoBehaviour
{
    private Text _User;//gets username from PlayerUser script


    // Start is called before the first frame update
    void Start()
    {
        _User = GameObject.FindGameObjectWithTag("playerBT").GetComponent<Text>();//finds the object with the playerBT tag to print the entered user onto it
        _User.text = PlayerPrefs.GetString("user_name");
    }
}
