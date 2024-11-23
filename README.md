## About
Last Quiver is a 2D top-down roguelike game where players must survive relentless waves of enemy attacks. Players control an archer, using the mouse to aim at enemies and shoot arrows to defeat them. The game features a scoring system based on the number of enemies defeated, along with power-ups and item drops that enhance gameplay, offering a dynamic and thrilling survival experience.

<tbody>
    <tr>
      <td><img src="https://github.com/Swiper0/Swiper0/blob/main/GIF/LastQuiverDemo.gif"/></td>
    </tr>
  
<br>

## Scripts and Features
Scripts:
|  Script       | Description                                                  | Development Time |
| ------------------- | ------------------------------------------------------------ | -------------- |
| `AudioManager.cs` | Handles background music playback, volume control, and persistence across scenes using PlayerPrefs | ≈ 1 hours |
| `BackgroundScroller.cs` | Handles the scrolling of the background by adjusting the texture offset over time, creating a moving background effect based on the scrollSpeed. | ≈ 1 hours |
| `Enemy.cs` | Handles the behavior of the enemy in the game, including movement, damage, health management, and death. The enemy moves towards the player, takes damage from projectiles or the player, flashes briefly when hit, and plays a death animation when defeated. It also handles dropping items and power-ups upon death. | ≈ 5 hours |
| `GameOverPanelManager.cs` | Handles the display of the game over panel. When triggered, it activates the game over panel and updates the score and best score text based on the current score and the stored best score in PlayerPrefs. | ≈ 2 hours |
| `HealthBar.cs` | Handles updating the health bar. It takes the current health value and the maximum health value, then adjusts the slider's value to reflect the player's health percentage. | ≈ 1 hours |
| `HealthPickup.cs` | Handles health pickup interactions. When the player collides with the health pickup, it checks if the player's health is below the maximum. If so, it adds health (up to the max health) and updates the player's health display. | ≈ 2 hours |
| `LevelLoader.cs` | 
Handles level loading with a transition effect. When LoadNextLevel() is called, it triggers an animation for the transition, waits for the specified time (transitionTime), and then loads the next scene based on the current scene's build index. | ≈ 1 hours |
| `MainMenu.cs` | Handles the main menu interactions. When PlayGame() is called, it triggers the LoadNextLevel() function from the LevelLoader to start the game. If LevelLoader is not set, it logs an error. QuitGame() is used to exit the application when called. | ≈ 1 hours |
| `PauseMenu.cs` | Handles the pause menu functionality. Toggles pause/resume with the Escape key. Resume() hides the menu and resumes the game, while Pause() shows the menu and freezes the game. Restart() reloads the current scene and resets the score. LoadMainMenu() returns to the main menu and unpauses the game. | ≈ 2 hours |
| `PlayerController.cs` | Handles player movement, shooting, dashing, and health. The player moves with WASD, shoots with the mouse, and can dash with space. Health is shown with hearts, and the game over screen appears when health reaches zero. Rapid-fire power-up reduces shooting cooldown. | ≈ 4 hours |
| `Powerup1.cs` | Handles the activation of a rapid-fire power-up when the player collides with it. Upon collision, it triggers the ActivateRapidFire method in the PlayerController for the specified duration and then destroys the power-up object. | ≈ 2 hours |
| `Projectile.cs` | Handles the movement of the projectile upwards at a specified speed and destroys it if it goes beyond the screen bounds or collides with any object that isn't tagged as "Player." It calculates the screen boundaries using the camera's viewport and checks if the projectile moves out of bounds, destroying itself in that case. Additionally, it destroys the projectile upon collision with any object that isn’t the player. | ≈ 2 hours |
| `ScoreManager.cs` | Handles the player's score, updates the score display, tracks the best score, and saves it using PlayerPrefs. The score can be reset, and the best score can be accessed. | ≈ 2 hours |
| `Sound.cs` | Handles the sound data by storing the name and the corresponding `AudioClip` for each sound. | ≈ 1 hours |
| `Spawner.cs` | Handles enemy spawning at random spawn points after a specified delay (timeBetweeenSpawns). It checks the current time and, when the next spawn time arrives, selects a random spawn point and instantiates the enemy at that location. | ≈ 1 hours |
| `UIController.cs` | Handles the music settings in the UI, allowing the player to adjust the music volume using a slider. On start, it loads the saved volume setting from PlayerPrefs and applies it. The ToggleMusic method allows the player to toggle the music on/off, while the MusicVolume method updates the music volume based on the slider value. | ≈ 2 hours |
| `etc`  |  | ≈ 12 hours |


Post Processing used:
- Bloom
- Lens Distortion
- Vignette
- Grain
- Screen Space Reflections
- Ambient Occlusion

The game has:
- Player Controls
- Power-up
- Score System
- Health System
- Audio Manager
- Post Processing 

<br>

## Game controls
The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| Mouse1           | Shoot |
| Spacebar           | Dash |
| Esc           | Pause / Volume Setting |

<br>

## Notes
this game is developed in **Unity Editor 2022.3.7f1**

Asset used:
- Enemy : https://diogo-vernier.itch.io/pixel-art-slime
- Effect : https://bdragon1727.itch.io/free-smoke-fx-pixel-2
- Music : https://pixel-boy.itch.io/ninja-adventure-asset-pack
- Heart : https://dani-maccari.itch.io/platformer-metroidvania-pixel-items-free-assets
- Power-up : https://bontt.itch.io/power-up
- Bow : https://xxashuraxx.itch.io/bow
- Character : https://lucky-loops.itch.io/character-satyr
- Tiles : https://pine-druid.itch.io/damp-dungeon-tileset-and-sprites
- Heart UI : https://clipartmag.com/download-clipart-image#heart-png-images-with-transparent-background-24.png
- Font : https://www.1001fonts.com/video-game-fonts.html?page=2
