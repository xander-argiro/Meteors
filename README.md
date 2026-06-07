# Changelog
Added a health system
- The player starts with 3 health
- Health is represented by small player ships on the bottom left
- Each enemy bullet deals one damage
- Reaching 0 health triggers a game over that reloads the scene
Added large, slowly moving meteors that come from below to create a constant threat of loss
- These objects will trigger a game over, no matter how many lives the player has left
- Meteors will despawn when they travel far enough up off screen
Added a score text on the bottom right that increments for every eliminated enemy ship
Added sound effects for taking damage, dying, and eliminating an enemy
