using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Moving MovementScript;
    public Text Text;

    void Update()
    {
        Text.text = MovementScript.Speed.ToString(CultureInfo.CurrentCulture);
    }
}
