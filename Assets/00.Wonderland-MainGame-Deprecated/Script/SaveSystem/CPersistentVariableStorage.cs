using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Yarn.Unity;
using Unity.Plastic.Newtonsoft.Json;

namespace PointClickerEngine
{
public class CPersistentVariableStorage : VariableStorageBehaviour
{
 // File path for saving variable data
        private string filePath = "Assets/SaveData/variables.json";
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        private Dictionary<string, Type> variableTypes = new Dictionary<string, Type>();
        private Dictionary<string,string> dialogueHistory = new Dictionary<string,string>();

        private void Awake()
        {
            LoadVariables();
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
            saveData.DialogueHistory = dialogueHistory.Values.ToList();
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
                    dialogueHistory.Add(item,item);
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
        if(variableTypes.ContainsKey(variableName))
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
           
           dialogueHistory[dialogueName]=dialogueName;
            
            SaveVariables();
        }
        public bool HasDialogueBeenExecuted(string dialogueName)
        {
           
            return dialogueHistory.ContainsKey(dialogueName);
        }
    }

}