using UnityEngine;

namespace Overdrunk.Level
{
    [System.Serializable]
    public class LevelPlayerData
    {
        [Header("Records")]
        [SerializeField] private int _starsRecord = 0;
        [SerializeField] private int _pointsRecord = 0;

        public int StarsRecord { get => _starsRecord; set => _starsRecord = value; }
        public int PointsRecord { get => _pointsRecord; set => _pointsRecord = value; }
    }
}