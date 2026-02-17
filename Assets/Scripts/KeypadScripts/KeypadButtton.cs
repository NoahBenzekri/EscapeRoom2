using UnityEngine;

public class KeypadButtton : MonoBehaviour
{
    public string number;
    public Keypad keypad;
  void Awake()
    {
        keypad = GetComponentInParent<Keypad>();
    }

    public void OnMouseDown()
    {
        if (keypad != null)
        {
                 keypad.AddDigit(number);
        }
    }       
}