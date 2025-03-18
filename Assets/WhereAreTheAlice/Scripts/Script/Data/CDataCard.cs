


using UnityEngine;
using Unity;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Wherearethealices/NewCard")]

[System.Serializable]

public class CDataCard : ScriptableObject
{
   public int index;
   public string Name;
   [TextArea(5,5)]
   public string Description;

   public Image CardDesign;

   public int ValueUniverseSequence;
}
