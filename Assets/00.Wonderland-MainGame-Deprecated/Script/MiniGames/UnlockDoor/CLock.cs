using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLock : MonoBehaviour
{
    [SerializeField]private Transform transformKnifeOriginalPositionLocal;
    [SerializeField]private Transform TransfoKniferTrasnalateLocal;

    [SerializeField]private Transform transformLockPositionOriginal;
    [SerializeField]private Transform transformLockPositionLockOriginalTarget;
    
    [Range(0.0f, 1.0f)]
    private float PushKnifeForce = 0f;

    private float PushKniIncrement = 0.4f;
    private float PushKnifeForceMax = 1f;

    [Range(0.0f, 1.0f)]
    private float RoundKnifeForce = 0f;

    [Range(0.0f, 1.0f)]
    private float RoundKnifeForceMin;

    //private float RoundKnifeIncremene = 0.4f;
  



    [Range(0.0f, 1.0f)]
    private float fatigue = 0f;

    [Range(0.0f, 1.0f)]
    private float PushKnifeForceMin;


    private float RoundKnifeForceMax = 1f;

        void Update()
    {
        ForceLock();
    }

    void ForceLock()
    {
        PushKnife();
        RoundKnife();
        LearpKnife();
    }

    void PushKnife()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PushKnifeForce += PushKniIncrement;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            fatigue += 00.1f;
            PushKnifeForce -= fatigue;
        }
    }

    void RoundKnife()
    {
       

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RoundKnifeForce += PushKniIncrement;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {   
            fatigue += 00.1f;
            RoundKnifeForce -= fatigue;
        }

      
    }

    void LearpKnife()

    {
        Vector3 KnifecurrentOriginal = new Vector3(transformKnifeOriginalPositionLocal.position.x,transformKnifeOriginalPositionLocal.position.y,transformKnifeOriginalPositionLocal.position.z);
        Vector3 KnifecurrentOriginalMovement = new Vector3(TransfoKniferTrasnalateLocal.position.x,TransfoKniferTrasnalateLocal.position.y,TransfoKniferTrasnalateLocal.position.z);

        Vector3  LockPositionOriginal= new Vector3(transformLockPositionOriginal.position.x,transformLockPositionOriginal.position.y,transformLockPositionOriginal.position.z);
        Vector3 LockPositionLockOriginalTarget = new Vector3(transformLockPositionLockOriginalTarget.position.x,transformLockPositionLockOriginalTarget.position.y,transformLockPositionLockOriginalTarget.position.z); 
        if(PushKnifeForce >= PushKnifeForceMin && PushKnifeForce <= PushKnifeForceMax)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position,KnifecurrentOriginalMovement,Time.deltaTime);
            transform.position = currentPosition;
        }
    
        else
        {
              Vector3 currentPosition = Vector3.Lerp(transform.position,KnifecurrentOriginal,Time.deltaTime);
            transform.position = currentPosition;
        }

        if(RoundKnifeForce >= RoundKnifeForceMin && PushKnifeForce <= RoundKnifeForceMax)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position,LockPositionLockOriginalTarget,Time.deltaTime);
            transform.position = currentPosition;
        }
    
        else
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position,LockPositionOriginal,Time.deltaTime);
            transform.position = currentPosition;
        }


    }
        
}
