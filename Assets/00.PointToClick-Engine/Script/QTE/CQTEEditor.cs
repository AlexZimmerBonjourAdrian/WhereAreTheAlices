using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CQTEData))]
public class CQTEDataEditor : Editor
{ private SerializedProperty qteIdProp;
    private SerializedProperty typePuzzleProp;
    private SerializedProperty keyToPressProp;
    private SerializedProperty durationProp;
    private SerializedProperty requiredPressesProp;
    private SerializedProperty incrementSpeedProp;
    private SerializedProperty debugTextProp;
    private SerializedProperty successThresholdProp;
    private SerializedProperty partialSuccessThresholdProp;



    private void OnEnable()
    {
        qteIdProp = serializedObject.FindProperty("QTEId");
        typePuzzleProp = serializedObject.FindProperty("TypePuzzle");
        keyToPressProp = serializedObject.FindProperty("KeyToPress");
        durationProp = serializedObject.FindProperty("Duration");
        requiredPressesProp = serializedObject.FindProperty("RequiredPresses");
        incrementSpeedProp = serializedObject.FindProperty("IncrementSpeed");
        debugTextProp = serializedObject.FindProperty("DebugText");
        successThresholdProp = serializedObject.FindProperty("SuccessThreshold");
        partialSuccessThresholdProp = serializedObject.FindProperty("PartialSuccessThreshold");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(qteIdProp);
        EditorGUILayout.PropertyField(typePuzzleProp);
        EditorGUILayout.PropertyField(debugTextProp);


        QTETypePuzzle type = (QTETypePuzzle)typePuzzleProp.enumValueIndex;

        switch (type)
        {
            case QTETypePuzzle.KeyPress:
                EditorGUILayout.PropertyField(keyToPressProp);
                EditorGUILayout.PropertyField(durationProp);
                EditorGUILayout.PropertyField(incrementSpeedProp);
                EditorGUILayout.PropertyField(successThresholdProp);
                EditorGUILayout.PropertyField(partialSuccessThresholdProp);

                break;
            case QTETypePuzzle.Sequence:
                EditorGUILayout.LabelField("Sequence-specific properties (to be implemented)");
                // Add properties for Sequence type here
                break;
            case QTETypePuzzle.Selection:
                EditorGUILayout.LabelField("Selection-specific properties (to be implemented)");
                // Add properties for Selection type here
                break;
        }


        serializedObject.ApplyModifiedProperties();
    }
}
