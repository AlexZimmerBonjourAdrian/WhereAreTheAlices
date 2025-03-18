using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PointClickerEngine;


public class CGenericObject : MonoBehaviour
{
    [SerializeField]
    protected int id;
    [SerializeField]
    protected CItemData item;
    [SerializeField]
    protected new string name;
    [SerializeField]
    protected string descripcion;
    [SerializeField]
    protected Texture2D imageItem;
    [SerializeField]
    protected bool optional;
    [SerializeField]
    protected bool isActive;

    [SerializeField]

    protected virtual void Start()
    {
       // imageItem = item.imageItem;
     //   optional = item.Optional;
       // isActive = item.isActive;
    }


}
