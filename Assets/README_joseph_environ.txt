SETUP:

Lever uses a child object for solid collider and a trigger collider on the parent to activate; (press e)
Sprites are included for on and off positions, may need to be resized.

FireExtinguisher needs to be tagged "Extinguisher" to function.
Also uses the same parent collider setup as lever.
In the editor, set the player gameobject in the corresponding slot
Press e to pickup the object and douse fires, Press f to drop.

FireController has a slider for damage value, Fires greater than 50 damage cannot be extinguished by the extinguisher.
An extinguished fire has its damage value set to 0. 
Uses only one isTrigger collider.
Method for damaging player is not implemented.

Door has a child object with a hard collider, and a parent with an isTrigger collider.
Sprites are included for open and closed positions.

Wrench is just a copy of fire extinguisher with no sprites

