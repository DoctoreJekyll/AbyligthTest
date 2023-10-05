using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class ButtonInitBehaviour : MonoBehaviour
    {

        private Button button;

        private enum ButtonBehaviour
        {
            GoToMenu,
            GotToGame
        }

        [SerializeField] private ButtonBehaviour buttonBehaviour;
        

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(FindFlowManager);
        }

        private void FindFlowManager()
        {
            switch (buttonBehaviour)
            {
                case ButtonBehaviour.GoToMenu:
                    FlowManager.Instance.GoToMenu();
                    break;
                
                case  ButtonBehaviour.GotToGame:
                    FlowManager.Instance.GoToInGame();
                    break;
                
                default:
                    break;

            }
            
        }
    }
}
