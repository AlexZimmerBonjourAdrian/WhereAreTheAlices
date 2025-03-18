using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExposedProperties
{
     public static ExposedProperties CreateInstance()
    {
        return new ExposedProperties();
    }

    public string PropertyNameCharacter = "New String";
    public string PropertyName = "New String";
    public string PropertySprite = "New Sprite";
    public string PropertyValue = "New Value";
}
