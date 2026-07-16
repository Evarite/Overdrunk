using UnityEngine;

namespace Overdrunk
{
    [AddComponentMenu("Overdrunk/Game Manager")]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public InputActions InputActions { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            InputActions = new InputActions();
            InputActions.Enable();

            DontDestroyOnLoad(gameObject);
        }
    }
}