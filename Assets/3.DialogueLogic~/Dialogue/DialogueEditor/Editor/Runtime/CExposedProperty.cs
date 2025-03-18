using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CExposedProperty : MonoBehaviour
{
    public static CExposedProperty CreateInstance()
    {
        return new CExposedProperty();
    }

    public string PropertyName = "New String";
    public string PropertyValue = "New Value";

}
