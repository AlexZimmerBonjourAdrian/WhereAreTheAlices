using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PointClickerEngine;

public class CLevelDialogue : CLevelGeneric
{

   [SerializeField] private TextMeshProUGUI SanityText;
   [SerializeField] private TextMeshProUGUI EmpatyText;
   [SerializeField] private TextMeshProUGUI CharmText;
   [SerializeField] private TextMeshProUGUI WitsText;
   [SerializeField] private TextMeshProUGUI ComposureText;
   [SerializeField] private TextMeshProUGUI NameArquetipe;


   void Start()   
   {
    
    //Testing With Loop Dialogue, succesfull
    //  if(!CManagerDialogue.Inst.GetIsDialogueRunning())
    //   {
        
    //       CManagerDialogue.Inst.SetListYarn(0);
    //       CManagerDialogue.Inst.StartDialogueRunner();
    //   }
       //Testing With Loop Dialogue, funciona

      if(!CManagerDialogue.Inst.GetIsDialogueRunning() && CEngineManager.Inst.GetIsDebug()== true)
      {
        
          CManagerDialogue.Inst.SetListYarn(1);
          CManagerDialogue.Inst.StartDialogueRunner(0);
      }

      
       CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.Detective); 
        //CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.LocaPerturbada); 
       //CMICILSPSystem.Instance.PrintStats(CMICILSPSystem.Instance.CurrentStatsTemplate);
        CMICILSPSystem.Instance.PrintStats(CMICILSPSystem.Instance.CurrentStatsTemplate);



       //CMICILSPSystem.Instance.IncreaseStat(CMICILSPSystem.Stats.Sanity, 2);

 
       CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Sanity).ToString();
       
 

   }

   private void Update()
   {
      if(CEngineManager.Inst.GetIsDebug())
      {
      if(Input.GetKeyDown(KeyCode.E))
      {

         CMICILSPSystem.Instance.IncreaseStat(CMICILSPSystem.Stats.Charm, 2);
      }

      
      if(Input.GetKeyDown(KeyCode.Q))
      {

         CMICILSPSystem.Instance.DecreaseStat(CMICILSPSystem.Stats.Charm, 2);
      }

      //set random arquetipe by pressed Button R
      if(Input.GetKeyDown(KeyCode.R))
      {
         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.GetRandomTemplate()); 
      }
   }

      if(EmpatyText != null && SanityText != null && CharmText != null && WitsText != null && ComposureText != null)
       {
          NameArquetipe.text = CMICILSPSystem.Instance.CurrentStatsTemplate.Name;
         SanityText.text = CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Sanity).ToString();
         EmpatyText.text = CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Empathy).ToString();
         CharmText.text= CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Charm).ToString();
         WitsText.text= CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Wits).ToString();
         ComposureText.text= CMICILSPSystem.Instance.GetStat(CMICILSPSystem.Stats.Composure).ToString();
        
       }
      else
      {
         Debug.LogError("Hay una stat no cargada");
      }
  
   }
}
   
