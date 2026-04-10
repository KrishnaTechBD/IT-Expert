# Dodecahedron (Unity Mobile Board Game)

Initial Unity-oriented project bootstrap for the Dodecahedron mobile board game.

## Structure

- `Assets/Scripts/Core/GameManager.cs` - theme state, tile tracking, win checks.
- `Assets/Scripts/Gameplay/DiceResolutionController.cs` - strict X → Z → Y dice resolution.
- `Assets/Textures`, `Assets/Models`, `Assets/UI` - art and interface placeholders.
- `.github/workflows/build-apk.yml` - CI workflow to build and upload Android APK artifacts.

## CI/CD Notes

The GitHub Actions Android build requires repository secrets:

- `UNITY_LICENSE`
- `UNITY_EMAIL`
- `UNITY_PASSWORD`

The workflow triggers on pushes to `main` and manual dispatch.
