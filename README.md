# CS4173-Video-Game-Project
## The Last Ronin
Final Video Game Project 

### General Plot
This video game follows The Lone Ronin and his journey of avenging the village he has failed to protect, as the invading alien species, known as the Oni, 
have infiltrated and taken over the planet, slaughtering and obliterating all humans in attempt to please their leader, who has come to be known only as The Blind Hunter.

### Characters
The Lone Ronin - The character the user plays as. Skilled with a plethora of weaponry, ranging from melee to ranged, they are able to utilize whatever resource they can get their hands on.

Shadelings - The average Oni type, they make up the vast majority of the Oni species. They deal and take an average amount of damage
Bolters - The fastest of the enemy types. For what they lack in durability, they make up for in blitzing the player with their unmatched speed. Less amount of hits to take down, but harder to hit.
Banebeast - The biggest and strongest enemy type of the horde. Their brute strength is something the player should avoid at all cost, as the game will end before the player knows it if they get within reach of one. They take the most hits to kill, as well as do the most damage.

The Blind Hunter - The leader of the Oni, very little is known about them other than the fact that they use their ears to hunt, rather than their eyes. Although it may not see, it more than makes up for it in the hearing department, and is the leader of the Oni for a reason. 
(Note: The asset we planned to use was located and dowmloaded, but this character was not implemented in time)

### Gameplay
The player plays the game from a first-person perspective. Upon loading the game, the player will be shown the start screen, which gives them the option to either jump right into the game or look at the options, which will allow certain aspects, such as seeing how to play, turning music on/off, and entering cheat codes, to be accessed (as of now, not yet fully implemented).
When the player presses play, they are loaded into the game, beginning in one of the corners of the maze with 70 health (which can be altered), and can freely move around by using the arrow keys, as well as the space button to jump. Pressing 'R' will cause the sword to swing. The enemies will spawn on start as well, ranging between the middle of the map and away from the player.
The enemies move towards and look at the player while playing, and once they reach a specific range near the player, they will perform attack animations. 
If the player is touched, their health will decrease by 1 point. If the player's health reaches 0, the game over screen will be displayed to the player, prompting them to return to the main menu. 
Alternatively, if all of the enemies are wiped out from the map, the player will load into the second level, which behaves as a traversal level, in which players will jump across the map, retrieving the lost souls of their village that the Oni took. 
Players can pause the game at any time by pressing 'P', which will present the options to 'Resume', toggle sound, and 'Quit'.
Note: Quitting here will not exit the application, rather return to the main menu, and from there the application can be exited by pressing the 'Exit Game' button.

### Advanced Features/Future
There is a cheat code section in the option canvas that has been partially implemented, going as far as accepting the cheat code 'watermelon', which should change the weapon to a watermelon sword.
It doesn't do this, as the bool value isn't properly changing, but the sword can still be seen in the dev mode by unchecking the 'isCheat' section in the WeaponManager script of the Weapon Manager object. 
A feature that wasn't implemented is the different sword types that could be picked up from weapon beacons. This was just due to time constraints, but the approach would have been similar to how the watermelon sword was implemented, although the kunai would have been made into a throwable instead of a melee. 
All of these assets were found in the assets store, but were not imported to the project since this portion wasn't reached in time.

### Sources
The Oni appearances were found on the Unity asset store, as well as the animations that go with them for running and attacking.
The weapons were also found from the asset store.
The player/weapon animations are personally created.
Sounds were found in both the Asset store and Youtube, with all music taken from the Creative Commons Audio Library of Youtube.
Much scripting logic was based off previous Create With Code projects combined with previous programming knowledge. 
The Standard Assets were given by Unity, which helped save time with the first person view, allowing us to put more focus on fleshing out the other parts of the game.

Overall this is a simple game that conceptually mimics aspects of DOOM, and is designed to be a fun, 10-15 minute playthrough that players can enjoy for free.

