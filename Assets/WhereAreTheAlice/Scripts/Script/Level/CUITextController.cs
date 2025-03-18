using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Drawing.Design;
using PointClickerEngine;
using Yarn.Unity;
using System;
public class CUITextController : MonoBehaviour
{

    private Color32 newBlack = HexToColor("676767");
    private Color32 newWhite = HexToColor("FFFFFF");
    
    private Color32 WhiteRabbitColor = HexToColor("EEE850");

    private Color32 JunoColor = HexToColor("F0A1F5");

    private Color32 NicoColor = HexToColor("C80808");

    private TextMeshProUGUI Character_Char;

    [SerializeField] DialogueRunner runner;


    private void Awake()
    {
        Character_Char = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        runner = CManagerDialogue.Inst.GetDialogueRunner();
        runner.AddCommandHandler<string>("CharacterColor", SetCharacterColor);

    }
    
   private static Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }


public void SetCharacterColor(string characterName)
    {
        if (Character_Char == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            return;
        }

        switch (characterName) // Case-insensitive comparison
        {
        
            case "CB": // Added for flexibility
                Character_Char.color = WhiteRabbitColor;
                break;
            case "Juno":
                Character_Char.color = JunoColor;
                break;
             case "Narrator":
                Character_Char.color = newWhite;
                break;
            case "Nico":
                Character_Char.color = NicoColor;
                break;
            default:
                Character_Char.color = newWhite; // Default color (you can change this)
                break;
        }
    }
}
    

    


