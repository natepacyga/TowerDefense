Alt Space Code Test README

For my object manipulation code test I choose to go with a Tower Defense / City Building game.  Since the most important piece of functionality is the actual object manipulation, I want to point that out first:

*** Once in game, plop any object down. This is Placement Object Mode. Then hit the "Q" Key to enter Game mode. Then click on any building you have placed to see some boxes appear next to the building. Blue will scale the building up and down, purple will rotate, red will delete it and black will close the UI. ***

For the actual gameplay, you want to build up a town, gain resources and kill the trolls that spawn at the corners of the map. To gain resources you need to put down banks (red buildings) and lumberyards (long gray buildings). However for these to earn resources you need their counter parts. For banks you need residences (shack looking buildings) and trees for lumberyards. These act as multipliers and will gain you resources ever second. You start out with a good amount of resources for playablility reasons so you won't be overrun. Also, you will want to place towers and walls in strategic locations to protect your city.

If you really want to win and play the game well object manipulation is key. Especially since the enemy movement and target finding is so basic.

Keys:
* ASWD to move
* E and R to rotate through objects
* Q to enter "object placement" mode and "game" mode  

As for code, I went for a pretty basic and straight forward architecture. Controllers house a lot of the variables and logic for specific game objects and managers are the glue to bind it all together. The Managers Game Object house the managers for easy access to classes that need them. It's a poor man's service locator pattern that could be easily switch to something like dependency injection. 

Third party stuff:
For assets, I got them all off the asset store as free models and did use Unity's First Person Controller.