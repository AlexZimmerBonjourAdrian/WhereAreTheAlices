using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevel0 : CLevelGeneric
{
  
  [SerializeField]
    private List<int> SequencePuzzle;
    [SerializeField]
    private List<int> CorrectSequence;
    [SerializeField]
    private EPuzzleType.Puzzle TypePuzzle;
   
    private bool isSuccesfull = false;
    private bool isComplete  = false;

    [SerializeField]
    public List<GameObject> LevelRooms;

    public static CLevel0 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level0");
                return obj.AddComponent<CLevel0>();
            }

            return _inst;
        }
    }

    private static CLevel0 _inst;

      public void Awake()
    {
        TypePuzzle = EPuzzleType.Puzzle.Sequence;
         List<int> SequencePuzzle = new List<int>();
        _inst = this;
    }
private void Start()
{   
      _inst = this;
}
private void MoficiationSequencePuzzle(int post, int code)
{
    SequencePuzzle[post] = code;
      CheckSuccesfull(SequencePuzzle);

}
 public void CheckSuccesfull(List<int> sequenceCheck)
    {
       
     if (TypePuzzle == EPuzzleType.Puzzle.Sequence)
        {
         
            // Comparar las secuencias hasta el tamaño de la secuencia más corta
            for (int i = 0; i <= CorrectSequence.Count-1; i++)
            {
                if (SequencePuzzle[i] != CorrectSequence[i])
                {
                    CManagerSFX.Inst.PlaySound(1);
                    isSuccesfull = false;
                    break;
                }
                else
                {
                        isSuccesfull = true;
                }
            }

            // Si se llega al final del bucle sin encontrar errores, la secuencia es correcta
          
        }
    }

    protected override void CompleteRoom()
    {
        var ObjectsPuzzles = FindObjectOfType<CLightSwitch>();
        if (isSuccesfull == true)
        {
            ObjectsPuzzles.CompleteLight();
            isComplete = true;
            Debug.Log("El nivel esta completado");
            CLevelController.Inst.checkCompleteLevel();
        }
    }

    public override bool GetIsComplete()
    {
        return this.isComplete;
    }


}
