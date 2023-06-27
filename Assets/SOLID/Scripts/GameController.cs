using SOLID.Scripts.Inputs;
using SOLID.Scripts.Objects;
using SOLID.Scripts.Player;
using UnityEngine;

namespace SOLID.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private InputsReader inputsReader;
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private Enemy.Enemy[] enemiesArray;
        [SerializeField]
        private MiscObject[] miscObjectArray;

        private void Awake()
        {
            SetFrameRate();

            Initialization();
        }

        /// <summary>
        /// Since this is a demo and there is no section with settings. The method is here
        /// This is not according the S.O.L.I.D.
        /// I'll just leave this note here to avoid unnecessary questions in the future
        /// </summary>
        private static void SetFrameRate()
        {
            var _numerator = Screen.currentResolution.refreshRateRatio.numerator;
            var _denominator = Screen.currentResolution.refreshRateRatio.denominator;

            var _refreshRate = Mathf.RoundToInt((float)_numerator / _denominator);

            Application.targetFrameRate = _refreshRate;

#if UNITY_EDITOR
            Debug.Log("Refresh rate: " + _refreshRate + " Hz");
#endif

        }

        /// <summary>
        /// Entry point for project
        /// </summary>
        private void Initialization()
        {
            PlayerInitialization();
            EnemiesInitialization();
            ObjectsInitialization();
        }

        private void PlayerInitialization()
        {
            inputsReader.Initialization(playerController);
            playerController.Initialization(inputsReader, mainCamera);
        }

        private void EnemiesInitialization()
        {
            foreach (var _enemy in enemiesArray)
            {
                _enemy.Initialization(mainCamera);
            }
        }

        private void ObjectsInitialization()
        {
            foreach (var _miscObject in miscObjectArray)
            {
                _miscObject.Initialization(mainCamera);
            }
        }
    }
}
