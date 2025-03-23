using UnityEngine;
using System.Collections.Generic;
using Yarn.Unity;
using TMPro;
using System.IO;
using System.Linq;
using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine.Events;

namespace PointClickerEngine
{
    //[RequireComponent(typeof(CKeywordHandler),typeof(CRoleplayDialogue),typeof(CDiceRollDialogue))]
    public class CManagerDialogue : VariableStorageBehaviour
    {
        [SerializeField]
        private DialogueRunner dialogueRunner;

        [SerializeField]
        private List<string> dialogueHistory = new List<string>();

        [SerializeField]
        private HashSet<string> executedDialogues = new HashSet<string>();


        [SerializeField] public TextMeshProUGUI dialogueText;

        public CSaveSystem saveSystem;

        public UnityEvent OnDialogueStart;
        public UnityEvent OnDialogueEnd;

        public enum GameMode
        {
            PointAndClick,
            VisualNovel
        }

        private static CManagerDialogue _inst;
        public GameMode CurrentGameMode { get; private set; }
        public static CManagerDialogue Inst
        {
            get
            {
                if (_inst == null)
                {
                    GameObject obj = new GameObject("ManagerDialogue");
                    return obj.AddComponent<CManagerDialogue>();
                }
                return _inst;
            }
        }

        public void SetGameMode(GameMode mode)
        {
            CurrentGameMode = mode;
        }

        public GameMode getGameMode()
        {
            return CurrentGameMode;
        }

        // File path for saving variable data
        private string filePath = "Assets/SaveData/variables.json";
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        private Dictionary<string, Type> variableTypes = new Dictionary<string, Type>();
        private Dictionary<string, string> dialogueHistorySaved = new Dictionary<string, string>();
      //  private DialogueSaver dialogueSaver;

        public void Awake()
        {
            if (_inst != null && _inst != this)
            {
                Destroy(gameObject);
                return;
            }
          //  DontDestroyOnLoad(this.gameObject);
            _inst = this;

            AutoSetDialogueRunner();

            CGameEvents.OnGameDialogueRunner.Subscribe(AutoSetDialogueRunner);
           // dialogueSaver = new DialogueSaver();
            // Load variables on start
            LoadVariables();
        }

        private void Start()
        {
            CurrentGameMode = 0;
        }

        [SerializeField]
        private List<YarnProject> ListYarnDialogueText;

        [SerializeField]
        private List<YarnProject> ListYarnDialogueVisualNovel;

        [SerializeField]
        private YarnProject ActualYarn;

        public void SetYarnProject(YarnProject Dialogs)
        {
            if (dialogueRunner != null)
            {
                dialogueRunner.SetProject(Dialogs);
            }
        }


        public void AutoSetDialogueRunner()
        {
            dialogueRunner = FindObjectOfType<DialogueRunner>();
            if (dialogueRunner == null)
            {
                Debug.LogError("No se encontró un DialogueRunner en la escena. Asegúrate de que haya uno presente.");
            }
            else
            {
                dialogueRunner.VariableStorage = this;
            }
        }

        public YarnProject GetYarnProject()
        {
            if (dialogueRunner != null)
            {
                return dialogueRunner.GetYarnProject();
            }
            return null;
        }

        public void SetListYarn(int IndexYarn)
        {
            if (dialogueRunner != null)
            {
                if (CurrentGameMode == GameMode.PointAndClick)
                {
                    ActualYarn = ListYarnDialogueText[IndexYarn];
                    dialogueRunner.SetProject(ActualYarn);
                }
                else if (CurrentGameMode == GameMode.VisualNovel)
                {
                    ActualYarn = ListYarnDialogueVisualNovel[IndexYarn];
                    dialogueRunner.SetProject(ActualYarn);
                }
            }
        }

        public void StartDialogueRunner(int IndexYarn)
        {
            if (dialogueRunner != null)
            {
                dialogueRunner.StartDialogue(ActualYarn.NodeNames[IndexYarn]);
            }
        }

        public void StartDialogueRunner(string Dialogue)
        {
           if (dialogueRunner != null)
            {
                if (!dialogueHistory.Contains(Dialogue))
                {
                    dialogueHistory.Add(Dialogue);
                }
                else
                {
                    if (executedDialogues.Add(Dialogue))
                    {
                        dialogueRunner.StartDialogue(Dialogue);
                        OnDialogueStart?.Invoke();
                        SaveDialogue(Dialogue);
                    }
                    else
                    {
                        Debug.LogWarning("Dialogue '" + Dialogue + "' has already been executed.");
                    }
                }
            }
        }

        public void IterateDialogueViews()
        {
            if (dialogueRunner != null || dialogueRunner.dialogueViews != null)
            {
                Debug.LogError("DialogueRunner or dialogueViews is not assigned!");


                var dialogueView = dialogueRunner.dialogueViews;

                var LineViews = dialogueView[0];
                dialogueHistory.Add(LineViews.ToString());
            }
            else
            {
                Debug.LogError("DialogueRunner o dialogueViews no están asignados.");
            }
        }

        public void StopDialogueRunner()
        {
            if (dialogueRunner != null)
            {
                dialogueRunner.Stop();
                OnDialogueEnd?.Invoke();
            }
        }


        public bool FindNode(string nodeNameToFind)
        {
            if (ActualYarn != null)
            {
                Debug.Log("FindNode " + nodeNameToFind);
                foreach (string nodeName in ActualYarn.NodeNames)
                {
                    if (nodeName == nodeNameToFind)
                    {
                        Debug.Log("Nodo encontrado: " + nodeNameToFind);
                        // ¡Nodo encontrado! Puedes hacer algo aquí, como iniciar el diálogo.
                        return true;
                    }
                }
                Debug.Log("NO ENCUENTRA NODO: " + nodeNameToFind);
                // Si llega aquí, el nodo no se encontró.
            }
            return false;
        }

        public string FindNodeReturnNodeAcrossAllYarnProjects(string nodeNameToFind)
        {
            if (ListYarnDialogueText == null || ListYarnDialogueVisualNovel == null)
            {
                Debug.LogWarning("Yarn Project lists are not assigned.");
                return null;
            }

            string foundNode = FindNodeInYarnProjects(ListYarnDialogueText, nodeNameToFind);
            if (foundNode != null)
            {
                Debug.Log($"Node found in Point and Click Yarn Project: {nodeNameToFind}");
                return foundNode;
            }

            foundNode = FindNodeInYarnProjects(ListYarnDialogueVisualNovel, nodeNameToFind);
            if (foundNode != null)
            {
                Debug.Log($"Node found in Visual Novel Yarn Project: {nodeNameToFind}");
                return foundNode;
            }

            Debug.Log($"Node not found in any Yarn Project: {nodeNameToFind}");
            return null;
        }

        private string FindNodeInYarnProjects(IEnumerable<YarnProject> yarnProjects, string nodeNameToFind)
        {
            if (yarnProjects == null)
            {
                Debug.LogWarning("Yarn projects list is null.");
                return null;
            }

            foreach (YarnProject yarnProject in yarnProjects)
            {
                if (yarnProject.NodeNames.Contains(nodeNameToFind))
                {
                    return nodeNameToFind;
                }
            }
            return null;
        }

        public void StartDialogueRunnerAcrossAllYarnProjects(string dialogueName)
        {
            if (dialogueRunner == null)
            {
                Debug.LogError("DialogueRunner is not assigned!");
                return;
            }

            string foundNode = FindNodeReturnNodeAcrossAllYarnProjects(dialogueName);

            if (foundNode != null)
            {
                if (dialogueHistory == null)
                {
                    dialogueHistory = new List<string>();
                }

                if (!dialogueHistory.Contains(foundNode))
                {
                    dialogueHistory.Add(foundNode);
                }
                dialogueRunner.StartDialogue(foundNode);
                SaveDialogue(foundNode);
            }
            else
            {
                Debug.LogError($"Dialogue '{dialogueName}' not found in any Yarn Project.");
            }
        }

        public bool GetIsDialogueRunning()
        {
            if (dialogueRunner != null)
            {
                return dialogueRunner.IsDialogueRunning;
            }
            return false;
        }

        public TextMeshProUGUI getText()
        {
            return dialogueText;
        }

        public DialogueRunner GetDialogueRunner()
        {
            return dialogueRunner;
        }

        public List<String> getdialogueHistory()
        {
            return dialogueHistory;
        }

        public HashSet<string> getexecutedDialogues()
        {
            return executedDialogues;
        }

        #region Saving and Loading Variables

        [Serializable]
        private struct VariableData
        {
            public string Name;
            public string Value;
            public string Type;
        }
        [Serializable]
        private struct SaveData
        {
            public List<VariableData> Variables;
            public List<string> DialogueHistory;
        }
        public void SaveVariables()
        {
            SaveData saveData = new SaveData();
            saveData.Variables = new List<VariableData>();
            saveData.DialogueHistory = dialogueHistorySaved.Values.ToList();
            foreach (var variable in variables)
            {
                VariableData data = new VariableData();
                data.Name = variable.Key;
                data.Value = variable.Value.ToString();
                data.Type = variableTypes[variable.Key].ToString();
                saveData.Variables.Add(data);
            }
            // Serialize data to json format
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);

            // Save the json to file
            File.WriteAllText(filePath, json);
        }

        public void LoadVariables()
        {
            variables.Clear();
            variableTypes.Clear();

            if (File.Exists(filePath))
            {
                // load data from json
                string json = File.ReadAllText(filePath);
                SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

                // add variables to dictionaries.
                foreach (var item in saveData.Variables)
                {
                    switch (item.Type)
                    {
                        case "System.String":
                            SetValue(item.Name, item.Value);
                            break;
                        case "System.Single":
                            SetValue(item.Name, float.Parse(item.Value));
                            break;
                        case "System.Boolean":
                            SetValue(item.Name, bool.Parse(item.Value));
                            break;
                    }
                }
                // add dialogues to history.
                foreach (var item in saveData.DialogueHistory)
                {
                    dialogueHistorySaved.Add(item, item);
                }

            }
        }

        #endregion

        #region VariableStorageBehaviour Implementation

        public override void SetValue(string variableName, string stringValue)
        {
            variables[variableName] = stringValue;
            variableTypes[variableName] = typeof(string);
            SaveVariables();
        }

        public override void SetValue(string variableName, float floatValue)
        {
            variables[variableName] = floatValue;
            variableTypes[variableName] = typeof(float);
            SaveVariables();
        }

        public override void SetValue(string variableName, bool boolValue)
        {
            variables[variableName] = boolValue;
            variableTypes[variableName] = typeof(bool);
            SaveVariables();
        }

        public override bool TryGetValue<T>(string variableName, out T result)
        {
            // check for variables existance.
            if (variables.ContainsKey(variableName))
            {
                // if the variable exist get the type.
                if (typeof(T).IsAssignableFrom(variables[variableName].GetType()))
                {
                    result = (T)variables[variableName];
                    return true;
                }
                else
                {
                    // if the variable is not of the correct type.
                    throw new InvalidCastException($"Variable {variableName} exists, but is the wrong type (expected {typeof(T)}, got {variables[variableName].GetType()}");
                }
            }
            else
            {
                // if the variable not exist: try to get the default value from the yarn project.
                var initialValue = GetInitialValueFromYarnProject(variableName);
                // if the variable is on the project, it will be added.
                if (initialValue != null)
                {
                    SetValueFromInitialValue(variableName, initialValue);
                    return TryGetValue<T>(variableName, out result); // Recursive call to load the value.
                }

                // if the variable is not in the project it returns the default value
                result = default;
                return false;
            }

        }

        public override void Clear()
        {
            variables.Clear();
            variableTypes.Clear();
            SaveVariables();
        }

        public override bool Contains(string variableName)
        {
            return variables.ContainsKey(variableName);
        }

        public override void SetAllVariables(Dictionary<string, float> floats, Dictionary<string, string> strings, Dictionary<string, bool> bools, bool clear = true)
        {
            if (clear)
            {
                Clear();
            }

            foreach (var variable in floats)
            {
                SetValue(variable.Key, variable.Value);
            }

            foreach (var variable in strings)
            {
                SetValue(variable.Key, variable.Value);
            }

            foreach (var variable in bools)
            {
                SetValue(variable.Key, variable.Value);
            }

            SaveVariables();
        }

        public override (Dictionary<string, float> FloatVariables, Dictionary<string, string> StringVariables, Dictionary<string, bool> BoolVariables) GetAllVariables()
        {
            var floatVariables = new Dictionary<string, float>();
            var stringVariables = new Dictionary<string, string>();
            var boolVariables = new Dictionary<string, bool>();

            foreach (var variable in variables)
            {
                if (variableTypes[variable.Key] == typeof(float))
                {
                    floatVariables[variable.Key] = (float)variable.Value;
                }
                else if (variableTypes[variable.Key] == typeof(string))
                {
                    stringVariables[variable.Key] = (string)variable.Value;
                }
                else if (variableTypes[variable.Key] == typeof(bool))
                {
                    boolVariables[variable.Key] = (bool)variable.Value;
                }
            }

            return (floatVariables, stringVariables, boolVariables);
        }
        public override Type GetVariableType(string variableName)
        {
            if (!Contains(variableName))
            {
                return null;
            }
            if (variableTypes.ContainsKey(variableName))
            {
                return variableTypes[variableName];
            }
            else
            {
                return base.GetVariableType(variableName);
            }
        }

        #endregion
        #region helpers

        // Helper method to retrieve the initial value from the Yarn Project
        private System.IConvertible GetInitialValueFromYarnProject(string variableName)
        {
            // Get the actual yarn project from the manager.
            YarnProject yarnProject = CManagerDialogue.Inst.GetYarnProject();
            // if the project is assigned.
            if (yarnProject != null)
            {
                // if the project contains the initial values.
                if (yarnProject.InitialValues != null)
                {
                    // if the initial values contains the variable.
                    if (yarnProject.InitialValues.ContainsKey(variableName))
                    {
                        // return the value.
                        return yarnProject.InitialValues[variableName];
                    }
                }
            }
            return null;
        }
        // Helper method to set the variable value based on the initial value's type
        private void SetValueFromInitialValue(string variableName, System.IConvertible initialValue)
        {
            // switch based on the type of the variable.
            switch (initialValue)
            {
                case string stringValue:
                    SetValue(variableName, stringValue);
                    break;
                case float floatValue:
                    SetValue(variableName, floatValue);
                    break;
                case bool boolValue:
                    SetValue(variableName, boolValue);
                    break;
                default:
                    Debug.LogError($"Unsupported initial value type for variable {variableName}: {initialValue.GetType()}");
                    break;
            }
        }

        #endregion
       public void SaveDialogue(string dialogueName)
        {
           
            dialogueHistorySaved[dialogueName]=dialogueName;
            
            SaveVariables();
        }
        public bool HasDialogueBeenExecuted(string dialogueName)
        {
           
            return dialogueHistorySaved.ContainsKey(dialogueName);
        }

         #region Public Methods for CSaveSystem

        /// <summary>
        /// Saves all Yarn variables to persistent storage.
        /// </summary>
        public void SaveGame()
        {
            SaveVariables();
        }

        /// <summary>
        /// Loads all Yarn variables from persistent storage.
        /// </summary>
        public void LoadGame()
        {
            LoadVariables();
        }

        #endregion

    }
}




