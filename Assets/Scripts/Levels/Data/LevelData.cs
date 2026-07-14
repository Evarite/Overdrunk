using UnityEngine;
using UnityEngine.UI;

namespace Overdrunk.Level
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Overdrunk/Levels/Level Data")]
    public class LevelData : ScriptableObject
    {
        
        [Header("Level Basic Data")]
        [SerializeField] private int _levelNumber = 0;
        [SerializeField] private Image _preview = null;

        public int LevelNumber {get => _levelNumber; set => _levelNumber = value;}
        public Image Preview {get => _preview; set => _preview = value;}


        [Header("Stars cost")]
        [SerializeField] private int _firstStarCost = 100;
        [SerializeField] private int _secondStarCost = 200;
        [SerializeField] private int _thirdStarCost = 300;
        
        public int FirstStarCost {get => _firstStarCost; set => _firstStarCost = value;}
        public int SecondStarCost {get => _secondStarCost; set => _secondStarCost = value;}
        public int ThirdStarCost {get => _thirdStarCost; set => _thirdStarCost = value;}


    }
}