using System;
using Bubbles;
using General;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private string levelToStart;
        
        [SerializeField] private Button startBtn;
        [SerializeField] private Button infoBtn;
        [SerializeField] private Button exitBtn;
        [SerializeField] private Button backBtn;
        
        
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject infoMenu;

        private void OnEnable()
        {
            startBtn.onClick.AddListener(StartGame);
            exitBtn.onClick.AddListener(ExitGame);
            infoBtn.onClick.AddListener(EnterInfoPage);
            backBtn.onClick.AddListener(EnterMainMenu);
        }

        private void OnDisable()
        {
            startBtn.onClick.RemoveAllListeners();
            exitBtn.onClick.RemoveAllListeners();
            infoBtn.onClick.RemoveAllListeners();
            backBtn.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            EnterMainMenu();
        }

        private void StartGame()
        {
            SceneLoader.LoadScene(levelToStart);
        }
        private void ExitGame()
        {
            Application.Quit();
        }
        private void EnterInfoPage()
        {
            infoMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        
        private void EnterMainMenu()
        {
            mainMenu.SetActive(true);
            infoMenu.SetActive(false);
        }
    }
}