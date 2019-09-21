Some improvement suggestions and improvements 21.9.:

-Currently camera rotation only works when you drag the planet, in orbit view (press s on keyboard)
it is hard to rotate camera. The reason for this is because the script for rotating camera is
attached to playersplanet gameobject which has an onMouseDrag method which checks if
player drags his mouse on planet. I recommend a change that the uses keyboard to move camera instead
of mouse. (just update method that uses arrow keys to move rotatetemp.) (this would also remove
the need for a rotatecamera button) (also removes the need for a global variable enablerotate).

-TODO: help button that displays intructions to player.

-Attached camera rotate axis as a child object of planet so that if planet moves or rotates (for some reason)
the camera moves with it, but not the other way around.

-moved some files around to make it easier to navigate and arrange stuff

-started creating enemies

-Maybe a main menu scene

-created a player gameobject which holds values for HP, current Wave and monies