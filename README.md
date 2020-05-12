# Snowball_Platformer_2D
School Project

Overview

Theme / Setting / Genre
	- <Winter collectible platformer>
  
Core Gameplay Mechanics Brief
	- <Growth>
  
Targeted platforms
	- <PC>
	- <Android>
  
Influences (Brief)
	- < Moonlighter >
		- <Game>
    - The graphisme without outline, simple but effective and an great ambiance.

	- < Celeste >
		- <Game>
		- The cold environnement
    
	- < Mario >
		- <Game>
    - Intuitive gameplay
    
	- < Metroid >
		- <Game>
		- Evolutive gameplay, path design .


The Pitch
You’re playing an old snowman head. You’re searching for a new corpse.

Project Description (Brief):
The project is based on the idea, « what if i let a snowball roll as a main character? »
It became the idea of a snowball that can gain mass and adapted her competences to that. Like this the platformer is not only about platform but also about reflexion on how you care about the mass to optimize your path to defeat your enemies or rech new land.

Core Gameplay Mechanics (Detailed)

	- <growth>
			Your health bar is an growth bar. By that it mean you grow up as you 
                                      gain mass (collect snow). More mass mean more damage but less 
                                      jump length
                                      
		- <How it works>
			/in fact this has 3 stades symbolise by a segmented health/growth bar. 

                                      1st : max jump’ length (double jump and wall jump possible if 
                                      unlocked) , does 1 damage to enemies.
                                      2nd : mid’jump, (double jump available) , does 1,5 damage
                                      3rd : no jump ( can use bumper to jump). Does 3 damage

                                      //you gain mass by collecting snow (on the ground or by collectible i
                                       don’t know yet) and loose it by taking damage or resting in hot spot.

Story and Gameplay

Story (Brief)

You’re snowy, an actual snowman head whose his corpse has been stolen. You’re searching a new corpse or indice on the thief through the adventure.
For that you explore the levels, gain power up, open new path while collecting snowball as scoring item.
Story (Detailed)

FOR LATER
Gameplay (Brief)
<The Summary version of below>
Gameplay (Detailed)
<Go into as much detail as needs be>
<Spare no detail>
<Combine this with the game mechanics section above>






Assets Needed

- 2D
	- Background
		- parallax background
		- platform
		- jump through platform
		-
	-Collectible
		- SnowBall score 1
		- SnowBall score 5
		- Power Up: Double Jump
		- Power Up: Wall Jump 
	-Dangers
		- Ice spikes
		- flames monster
	-Character

- Sound
	- Sound List (Ambient)
                 - Main_menu
                 - Level_one
                     - cave_ambient
                     - ice_ambiant




- Sound List (Player)
                 - jump
                 - dash
                 - damage_intake
                 - landing in snow
                 - stomp
                 - movement
    - collect object



- Code
	- Character Scripts (Player Pawn/Player Controller)
		- Control
			- Left/right
			- Jump / Double Jump / Wall jump
			- Dash / Stomp
	- Ambient Scripts (Runs in the background)
		- Score
		- AI_Enemy
		- Music_script
		- Interaction/Collision
		- Growth_Gestion ( variable int ?)
- Animation
	- Environment Animations 
		- Traps
		- Collectible ondulation
	- Character Animations 
- Player
			- Idle
			- Movement Left/Right
			- Jump / Wall Jump / Double Jump
			- Dash / Stomp
			- Taking damage
			- Collect something ?
			- using Bumper ?
			- Growth
				-Getting Losing growth bar.
			- Death
			- burned ?
			
- NPC
			- Flameche
				- Moving
				- Attack
				- taking damage (no need, OS monster.)
				- Dying (burned out/turning into ashes/Evaporate in the air?)
			- Infernal flame
				- Shooting
				- pre shoot/reload
				- Taking damage
				- Dying
