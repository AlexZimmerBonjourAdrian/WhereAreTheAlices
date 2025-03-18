using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace PointClickerEngine
{
public class CKeywordHandler : MonoBehaviour
{

  
    // Start is called before the first frame update

  
     public static void OnKeywordClick(string keyword)
    {
        // Busca el nodo correspondiente a la palabra clave
        string nodeName = keyword;
        Debug.Log("OnKeywordClick " + nodeName); // Ajusta según tu nomenclatura
        if (CManagerDialogue.Inst.FindNode(nodeName) == true)
        {    
            CManagerDialogue.Inst.StopDialogueRunner();

            // Inicia el diálogo en el nodo encontrado
            CManagerDialogue.Inst.StartDialogueRunner(nodeName);

        }
    }

    [YarnCommand("keyword")]
    public static void UpdateDialogueText(string text)
    {
        GameObject keywordObject = new GameObject("Keyword");
        keywordObject.transform.SetParent(CManagerDialogue.Inst.getText().transform);

        RectTransform keywordRectTransform = keywordObject.GetComponent<RectTransform>();
        if (keywordRectTransform == null)
        {
            keywordRectTransform = keywordObject.AddComponent<RectTransform>();
        }

        // Establece la escala del RectTransform a 1, 1, 1
        keywordRectTransform.localScale = new Vector3(1f, 1f, 1f);

          keywordRectTransform.localPosition = new Vector3(0f, 0f, 0f);
        // Añade el componente TextMeshProUGUI
        TextMeshProUGUI keywordText = keywordObject.AddComponent<TextMeshProUGUI>();
        keywordText.text = text;

        // Copia el estilo del texto principal
        keywordText.font = CManagerDialogue.Inst.getText().font;
        keywordText.fontSize = CManagerDialogue.Inst.getText().fontSize;

        // Resalta la palabra clave (opcional)
        keywordText.color = Color.blue; 

        LayoutRebuilder.ForceRebuildLayoutImmediate(keywordText.rectTransform);
        // Añade un componente Button al objeto
        Button keywordButton = keywordObject.AddComponent<Button>();
        keywordButton.onClick.AddListener(() => OnKeywordClick(text));
            
           
         
    }

  
}
}
