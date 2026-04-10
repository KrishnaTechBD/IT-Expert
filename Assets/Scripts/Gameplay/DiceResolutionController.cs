using System;
using UnityEngine;
using Dodecahedron.Core;

namespace Dodecahedron.Gameplay
{
    public enum XOutcome
    {
        None,
        MultiplyY2,
        MultiplyY3,
        NullifyY,
        NullifyZ
    }

    public enum ZOutcome
    {
        None,
        PlaceObstacleOnOpponent,
        RemoveOwnObstacle,
        ForceOpponentMissTurn
    }

    public enum YOutcome
    {
        Add1,
        Add5,
        Add10,
        Add15,
        Remove5,
        Remove10
    }

    [Serializable]
    public struct DiceRollResult
    {
        public XOutcome x;
        public ZOutcome z;
        public YOutcome y;
    }

    [Serializable]
    public struct ResolutionResult
    {
        public int TileDelta;
        public bool ZApplied;
        public bool OpponentMissesTurn;
        public bool ObstaclePlaced;
        public bool ObstacleRemoved;
        public string ResolutionLog;
    }

    public class DiceResolutionController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        public event Action<ResolutionResult> TurnResolved;

        public ResolutionResult ResolveTurn(DiceRollResult roll)
        {
            bool yNullified = false;
            bool zNullified = false;
            int yMultiplier = 1;

            bool opponentMissesTurn = false;
            bool obstaclePlaced = false;
            bool obstacleRemoved = false;

            string log = "";

            // 1) Resolve X die first.
            switch (roll.x)
            {
                case XOutcome.MultiplyY2:
                    yMultiplier = 2;
                    log += "X: Multiplied Y by 2. ";
                    break;
                case XOutcome.MultiplyY3:
                    yMultiplier = 3;
                    log += "X: Multiplied Y by 3. ";
                    break;
                case XOutcome.NullifyY:
                    yNullified = true;
                    log += "X: Nullified Y. ";
                    break;
                case XOutcome.NullifyZ:
                    zNullified = true;
                    log += "X: Nullified Z. ";
                    break;
                default:
                    log += "X: No effect. ";
                    break;
            }

            // 2) Resolve Z die second.
            bool zApplied = false;
            if (!zNullified)
            {
                zApplied = true;
                switch (roll.z)
                {
                    case ZOutcome.PlaceObstacleOnOpponent:
                        obstaclePlaced = true;
                        log += "Z: Placed obstacle on opponent. ";
                        break;
                    case ZOutcome.RemoveOwnObstacle:
                        obstacleRemoved = true;
                        log += "Z: Removed one own obstacle. ";
                        break;
                    case ZOutcome.ForceOpponentMissTurn:
                        opponentMissesTurn = true;
                        log += "Z: Opponent misses next turn. ";
                        break;
                    default:
                        log += "Z: No effect. ";
                        break;
                }
            }
            else
            {
                log += "Z: Skipped due to X nullification. ";
            }

            // 3) Resolve Y die third.
            int tileDelta = 0;
            if (!yNullified)
            {
                tileDelta = MapYOutcomeToDelta(roll.y);
                tileDelta *= yMultiplier;

                if (tileDelta < 0)
                {
                    int setbackMagnitude = Mathf.Abs(tileDelta >= -10 ? tileDelta : tileDelta / yMultiplier);
                    string setbackName = gameManager != null
                        ? gameManager.GetThemeSetbackLabel(setbackMagnitude)
                        : "Setback";
                    log += $"Y: {setbackName} ({tileDelta}). ";
                }
                else
                {
                    log += $"Y: Applied {tileDelta} tiles. ";
                }
            }
            else
            {
                log += "Y: Skipped due to X nullification. ";
            }

            if (gameManager != null && tileDelta != 0)
            {
                gameManager.ApplyTileDelta(tileDelta);
            }

            ResolutionResult result = new ResolutionResult
            {
                TileDelta = tileDelta,
                ZApplied = zApplied,
                OpponentMissesTurn = opponentMissesTurn,
                ObstaclePlaced = obstaclePlaced,
                ObstacleRemoved = obstacleRemoved,
                ResolutionLog = log.Trim()
            };

            TurnResolved?.Invoke(result);
            return result;
        }

        private static int MapYOutcomeToDelta(YOutcome yOutcome)
        {
            switch (yOutcome)
            {
                case YOutcome.Add1:
                    return 1;
                case YOutcome.Add5:
                    return 5;
                case YOutcome.Add10:
                    return 10;
                case YOutcome.Add15:
                    return 15;
                case YOutcome.Remove5:
                    return -5;
                case YOutcome.Remove10:
                    return -10;
                default:
                    return 0;
            }
        }
    }
}
