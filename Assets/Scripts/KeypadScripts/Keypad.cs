using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string correctCode;
    public string currentCode;
    public KeypadZoom keypadZoom;

      void Awake()
    {
        keypadZoom = GetComponent<KeypadZoom>();
    }
    public void AddDigit(string digit)
    {
        currentCode += digit;
        if(currentCode.Length == correctCode.Length)
        {
            checkCode();
        }
        
    }

    public void checkCode()
    {
        if(currentCode == correctCode)
        {
            Debug.Log("Correct Code!");
            if(keypadZoom != null)
            {
                keypadZoom.ExitZoom();
            }
            //todo unlcock door animation
        } else
        {
            Debug.Log("Wrong Code!");
        }
        currentCode = "";
    }   
}