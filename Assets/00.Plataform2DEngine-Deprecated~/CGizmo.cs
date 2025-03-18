using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGizmo : MonoBehaviour
{
    [SerializeField]private float _SizeCircule=0;

    // Start is called before the first frame update
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _SizeCircule);
    }
}
