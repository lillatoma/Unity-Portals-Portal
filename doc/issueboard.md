# Fixed issues of the project

## Issue 01: 
### Description
When using the portal, it keeps teleporting back and forth.
### Solution
Added a boolean `isActive` to the PortalGate script, that enables and disables the teleportation process.  
When the portal was used, the end-portal (the portal on the end) has `isActive` set to false.  
In order to reenable the portal, when `OnTriggerExit` is called with the player as collider, `isActive` is set to true.

## Issue 02:
### Description
The portal renders white texture.
### Solution
I added a camera to each portal, and set up a `Render Texture` for them.  
The material of the portal was changed to the `Render Texture` output.  

## Issue 03:
### Description
The portal's texture static.
### Solution
Made a script that corrects the portal's camera's position and rotation.  
The camera's position should be exactly as far from the end-portal as the player's camera is far from the local-portal.  
This distance-vector should be rotated by the angular difference of the two portals.  
The camera's rotation should be the player's rotation rotated by the angular difference of the two portals.  
**Angular difference:** (Rotation of the end-portal)-(Rotation of the local-portal)

## Issue 04:
### Description
The portal's camera acts correctly, but the portal's texture seems distorted.
### Solution
The portal's camera renders everything that the camera sees, including the other portal's frame.  
Only the other portal's frame should be rendered.  
I used a shader that makes the surface of the portal act as if it was a mask for the camera's rendertexture output.  

## Issue 05:
### Description
The portal's texture is dark.
### Solution
I used a shader that doesn't take lighting into account.  

## Issue 06:
### Description
When the rotations of the 2 portals don't match, teleportation isn't accurate.
### Solution
The difference-vector between the player and the local-portal should be rotated by the angular difference of the two portals.  
The rotated difference-vector should be added to the end-portal's location, thus giving the correct position for the teleportation process.

# Issues remaining

## Issue 07:
### Description
Rotating a portal to face up or down makes it function strangely.  

## Issue 08:
### Description
Two portals that face each other don't produce accurate image.  

## Issue 09:
### Description
Teleportation isn't seamless. The portal's plane might flicker.  

## Issue 10:
### Description
The player isn't visible in both portals when halfway through the portals.




