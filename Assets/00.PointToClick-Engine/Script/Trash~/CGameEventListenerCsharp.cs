using UnityEngine;

namespace Patterns.GameEvents
{
    public class GameEventListenerCsharp : MonoBehaviour
    {
        void Start()
        {
            CObserverCsharpAction.OnStartGame += OnStartGame;
            CObserverCsharpAction.OnEndGame += OnEndGame;
            CObserverCsharpAction.OnPassTurn += OnPassTurn;
            CObserverCsharpAction.OnStartTurn += OnStartTurn;
            CObserverCsharpAction.OnEndTurn += OnEndTurn;

            //---------------- Or ----------------
            
            CObserverCsharpDelegates.OnStartGame += OnStartGame;
            CObserverCsharpDelegates.OnEndGame += OnEndGame;
            CObserverCsharpDelegates.OnPassTurn += OnPassTurn;
            CObserverCsharpDelegates.OnStartTurn += OnStartTurn;
            CObserverCsharpDelegates.OnEndTurn += OnEndTurn;
        }

        void OnDestroy()
        {
            CObserverCsharpAction.OnStartGame -= OnStartGame;
            CObserverCsharpAction.OnEndGame -= OnEndGame;
            CObserverCsharpAction.OnPassTurn -= OnPassTurn;
            CObserverCsharpAction.OnStartTurn -= OnStartTurn;
            CObserverCsharpAction.OnEndTurn -= OnEndTurn;

            //--------------- Or ----------------
            
            CObserverCsharpDelegates.OnStartGame -= OnStartGame;
            CObserverCsharpDelegates.OnEndGame -= OnEndGame;
            CObserverCsharpDelegates.OnPassTurn -= OnPassTurn;
            CObserverCsharpDelegates.OnStartTurn -= OnStartTurn;
            CObserverCsharpDelegates.OnEndTurn -= OnEndTurn;
        }

        //--------------------------------------------------------------------------------------------------------------

        void OnStartGame()
        {
        }

        void OnEndGame(int a, float b, bool c)
        {
        }

        void OnPassTurn()
        {
        }

        void OnStartTurn()
        {
        }

        void OnEndTurn()
        {
        }
    }
}
