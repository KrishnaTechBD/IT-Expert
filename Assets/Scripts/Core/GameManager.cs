using System;
using UnityEngine;

namespace Dodecahedron.Core
{
    public enum GameTheme
    {
        Standard = 0,
        DeedsAndVirtues = 1,
        Climadice = 2
    }

    public class GameManager : MonoBehaviour
    {
        public const int MaxTilesToWin = 60;

        [Header("Game State")]
        [SerializeField] private GameTheme activeTheme = GameTheme.Standard;
        [SerializeField] private int playerTileCount;

        public event Action<int> TileCountChanged;
        public event Action<GameTheme> ThemeChanged;
        public event Action GameWon;

        public GameTheme ActiveTheme => activeTheme;
        public int PlayerTileCount => playerTileCount;

        public void SetTheme(GameTheme theme)
        {
            if (activeTheme == theme)
            {
                return;
            }

            activeTheme = theme;
            ThemeChanged?.Invoke(activeTheme);
        }

        public void ApplyTileDelta(int delta)
        {
            playerTileCount = Mathf.Clamp(playerTileCount + delta, 0, MaxTilesToWin);
            TileCountChanged?.Invoke(playerTileCount);

            if (playerTileCount >= MaxTilesToWin)
            {
                GameWon?.Invoke();
            }
        }

        public void ResetMatch(GameTheme theme)
        {
            activeTheme = theme;
            playerTileCount = 0;

            ThemeChanged?.Invoke(activeTheme);
            TileCountChanged?.Invoke(playerTileCount);
        }

        public bool HasMetWinCondition()
        {
            return playerTileCount >= MaxTilesToWin;
        }

        public string GetThemeSetbackLabel(int setbackMagnitude)
        {
            switch (activeTheme)
            {
                case GameTheme.DeedsAndVirtues:
                    return setbackMagnitude == 5 ? "Disillusion" : "Apathy";
                case GameTheme.Climadice:
                    return setbackMagnitude == 5 ? "Climate Crisis" : "Climate Catastrophe";
                default:
                    return setbackMagnitude == 5 ? "Setback" : "Major Setback";
            }
        }
    }
}
