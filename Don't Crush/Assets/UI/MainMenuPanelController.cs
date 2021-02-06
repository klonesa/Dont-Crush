using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystems
{
    public class MainMenuPanelController : GenericUIPanelController
    {


        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _creditsButton;
        public bool startButton;


        private void Start()
        {
            _startGameButton.onClick.AddListener(StartButtonFunction);
            _settingsButton.onClick.AddListener(SettingsButtonFunction);
            _creditsButton.onClick.AddListener(CreditsButtonFunction);

            UImanager.Instance().currentUIPanelController = this;
        }


        #region Button Functions
        private void StartButtonFunction()
        {
            startButton = true;
            StartCoroutine(StartGameCoroutine());
        }

        public void SettingsButtonFunction()
        {
            ClosePanel();
            UImanager.Instance().OpenPanel(UIPanelTypes.settingsPanel, true);

        }

        private void CreditsButtonFunction()
        {
            ClosePanel();
            UImanager.Instance().OpenPanel(UIPanelTypes.creditsPanel, true);

        }
        #endregion

        public override void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }

        public override void OpenPanel()
        {
            this.gameObject.SetActive(true);
        }

        IEnumerator StartGameCoroutine()
        {
            ClosePanel();
            UImanager.Instance().OpenPanel(UIPanelTypes.gamePanel, true);
            
            yield return new WaitForSeconds(1);
        }
    }
    
    
}

