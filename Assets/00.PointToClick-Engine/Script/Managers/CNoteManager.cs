using UnityEngine;

public class CNoteManager : MonoBehaviour
{
   
    public static CNoteManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("ManagerDialogue");
                return obj.AddComponent<CNoteManager>();
            }
            return _inst;

        }
    }

private static CNoteManager _inst;


private void Start()
{

}


}
