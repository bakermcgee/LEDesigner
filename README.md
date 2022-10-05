# LEDesigner
A simple C# Winforms application for creating quick LED Matrix patterns. It is meant to be used in conjunction with a seperate program running on a microcontroller. 
It was specifically written for use with a Raspberry Pi and a [custom microcontroller script](https://github.com/bakermcgee/LEDesignController).

![LEDesigner_Kirby](https://user-images.githubusercontent.com/26748231/193983059-732fd4c6-6d62-4cbf-8450-d5f65494b650.PNG)

## Features
- Simple user interface for designing matrix patterns.
- Ability to create static, scrolling, or frame by frame patterns.
- Ability to save patterns for use with some microcontroller script.

## Usage
1) Choose a design type and set the number of rows and columns.

2) Configure and design a pattern:
   - Static: No additional configuration needed.
   - Scrolling: Choose the direction and set the LED matrix's real number of rows and columns, as the scroll pattern may exceed the actual dimensions. In LED settings, set the gap color, if desired.
   - Frame by Frame: Set the number of frames desired and design each frame. Frames can be duplicated for ease if needed. 
   - In-Between: This allows for pausing before and/or after an animated pattern is executed.
   
3) Configure the LED Settings according to the physical matrix and microcontroller, if needed.

4) Save the pattern, allow the progress bar to finish before continuing.

5) Locate the pattern and verify that the pattern .txt and config.cfg files were created. 

6) Transfer the .txt and config.cfg files into the same directory as the microcontroller script when transfering to the microcontroller. 
