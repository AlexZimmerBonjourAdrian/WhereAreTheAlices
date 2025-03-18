using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3DPointToClick : MonoBehaviour
{
    private static int ACTIONSTATE_NONE = 0;
    private static int ACTIONSTATE_HOVE = 1;
    private static int ACTIONSTATE_INTERACT = 2;
    GameObject anyObject;
    private int _actionState;
    private Component _actionObj;

    public static C3DPointToClick Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("3DPointMechanic");

                return obj.AddComponent<C3DPointToClick>();
            }
            return _inst;
        }
    }
    private static C3DPointToClick _inst;



    public void Awake()
    {

        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }
    void Update()
    {
        InteractionPointToClick();
    }

    public void InteractionPointToClick()
    {
        if (_actionState == ACTIONSTATE_NONE)
        {
            GameObject obj = RayCollision();
            if (obj == null)
                return;

            Component actionObj = obj.GetComponent(typeof(Iinteract));
            if (actionObj != null && actionObj is Iinteract) // Check if the component implements Iinteract
            {
                _actionObj = actionObj;
                _actionState = ACTIONSTATE_HOVE;
            }
        }
        else if (_actionState == ACTIONSTATE_HOVE)
        {
            GameObject obj = RayCollision();
            if (obj == null)
            {
                _actionObj = null;
                _actionState = ACTIONSTATE_NONE;
                return;
            }

            Component actionObj = obj.GetComponent(typeof(Iinteract));
            if (actionObj == null)
            {
                _actionObj = null;
                _actionState = ACTIONSTATE_NONE;
            }
            else if (actionObj != _actionObj)
            {
                _actionObj = actionObj;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _actionState = ACTIONSTATE_INTERACT;
            }
        }
        else if (_actionState == ACTIONSTATE_INTERACT)
        {
            (_actionObj as Iinteract).Oninteract();
            _actionState = ACTIONSTATE_NONE;
            _actionObj = null;
        }
    }

    private GameObject RayCollision()
    {

        // Convertir la posición del ratón a un rayo 3D
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Realizar un raycast 3D
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Si el raycast golpea un objeto, devolverlo
            anyObject = hit.collider.gameObject;
            return anyObject;
        }

        // Si no golpea ningún objeto, devolver null
        return null;
    }

    private void OnDrawGizmos()
    {
        // Convertir la posición del ratón a un rayo 3D 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Dibujar el raycast en el Gizmo
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction * 10f); // Dibujar el rayo hasta 10 unidades de distancia

        // Dibujar una esfera en el punto de impacto si hay uno
        //if (Physics.Raycast(ray, out RaycastHit hit))
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.2f); // Dibujar una esfera verde en el punto de impacto
        }
    }
    public void CreatePoint()
    {


    }
}
