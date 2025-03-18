
using UnityEngine;



[CreateAssetMenu(fileName = "New QTE", menuName = "Wherearethealices/QTE")]
[System.Serializable]
public class CQTEData : ScriptableObject

{
   
    public int QTEId;

    public QTETypePuzzle TypePuzzle;
    public KeyCode KeyToPress; // Example for KeyPress type
    public float Duration; 
    public int RequiredPresses; 

    public float IncrementSpeed;
    public string DebugText;

    public float SuccessThreshold;
    public float PartialSuccessThreshold;





    public void DebugFunction()
    {
        Debug.Log(DebugText);
    }
   

}

public enum QTETypePushComportament
{
    KeyPress,
    HoldKey,
    ButtonMash
};

public enum QTETypePuzzle
{
    KeyPress,
    Sequence,
    Selection,
};


