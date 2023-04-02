using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using AC;

public class PlayerUser : MonoBehaviour
{
    public string[] _takenNames = { "bad)omen", "@expendable", "civil_soul", "pixel64", "polkaP0P!", "TRUEHERO"};//list of illigal names
    //takes and displays user name
    public Text _User;
    public InputField _display;
    GVar MGActive2;//defines variable from AC


    // Start is called before the first frame update
    void Start()
    {
        MGActive2 = AC.GlobalVariables.GetVariable(1);//addresses the variable of 'var' 1 from AC
        _User.text = PlayerPrefs.GetString("user_name");
        _display.characterLimit = 20;//sets a max limit for the username
    }


    //is called on 'login' button press
    public void StoreName()
    {
        //checks for illigal names
        if (_takenNames.Contains(_display.text, StringComparer.OrdinalIgnoreCase))
        {
            _User.text = _display.text;
            MGActive2.IntegerValue = 1;
            Debug.Log("that aint good m8");
        }
        //checks for white spaces or empty text
        else if (string.IsNullOrEmpty(_display.text) || Regex.IsMatch(_display.text, @"\s"))
        {
            _User.text = _display.text;
            MGActive2.IntegerValue = 0;
            Debug.Log("cannot contain white spaces or null");
        }
        //actually lets you keep your sick name
        else
        {
            _User.text = _display.text;
            PlayerPrefs.SetString("user_name", _User.text);
            PlayerPrefs.Save();
            MGActive2.IntegerValue = 2;
            Debug.Log("nice name");
        }
    }
}
