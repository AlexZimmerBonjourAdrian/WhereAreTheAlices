using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


    public class CSwitch : MonoBehaviour
    { 
        
        public static CSwitch Inst
        {
            get
            {
                if (_inst == null)
                {
                    GameObject obj = new GameObject("Switch");

                    return obj.AddComponent<CSwitch>();
                }
                return _inst;
            }
        }
        private static CSwitch _inst;
        // Start is called before the first frame update
        private void Awake()
        {
            if (_inst != null && _inst != this)
            {
                Destroy(gameObject);
                return;
            }
           // DontDestroyOnLoad(this.gameObject);
            _inst = this;
        }

        // Update is called once per frame
    
        void Update()
        {
          //  Example Change Map in te Game
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                CLevelManager.Inst.LoadScene(SceneManager.GetActiveScene().name);
            }
           
        
        }
    
    
        public void SwitchScene()
        {

        
            CLevelManager.Inst.LoadNextScene();
        
        }


        public void LoadScene( int index)
        {

        
            CLevelManager.Inst.LoadScene(index);
        
        }

        public void LoadScene( string name)
        {

        
            CLevelManager.Inst.LoadScene(name);
        
        }


        
    

    
    }

