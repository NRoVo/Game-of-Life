# Game-of-Life
A console simulation of a "zero player" Game of Life invented by mathematician Conway.

# What
The game is "played" on a grid, where it advances in generations, with cells becoming alive or dying, based on certain conditions. If a particular cell in the grid is empty (dead)
then it can come to life if exactly three neighbors that are alive. Therefore the alive cell dies in case it has more than three neighbors (overcrowding) or it has 0 or 1 
neighbors. This program is console based and has no GUI. The program is based on Command design pattern.

# How to
The simulation reacts on a set of commands:
* ```help```. Displays the list of all available commands and its usages with keys if exists.
* ```exit```. Exits the program.
* ```start```. Begins the animation.
* ```clear```. Empties the entire board. Literally kills each cell.
* ```randomize {percent}```. Randomly turns all cells on the grid on or off. The parameter is the float number from 0 to 1 where 0 is 0% of the grid population and 1 is the 100%
of the grid population (Ex: ```randomize 0.25```). The default parameter when the simulation starts is 0.5 which is the most balanced. The skew towards 0 or 1 will provoke faster 
cells "extinction" because of deficit or overcrowding.
* ```turn on|off {x} {y}```. Turns individual cell on or off (Ex: ```turn on 4 6```).
* ```grid on|off```. Turns the display of the grid on or off (Ex: ```grid on```).
* ```wrap on|off```. Allows the board to wrap around from side to side and from top to bottom. In case of activation the cells on the opposite sides of row or column will count
as neighbors. Disabled by default. (Ex: ```wrap off```)
* Premade commands. Each command described below takes one particular item of premade grid fragments stored in Resources directory. Each "draws" a particular pattern on the
location defined by user. These patterns has very interesting behavior. Their evolution is looped.
  * ```blinker {x} {y}```. Places a blinker on the grid at a specific location (Ex: ```blinker 4 6```).
  * ```diehard {x} {y}```. Places a diehard on the grid at a specific location (Ex: ```diehard 4 6```).
  * ```glider {x} {y}```. Places a glider on the grid at a specific location (Ex: ```glider 4 6```).
  * ```pulsar {x} {y}```. Places a pulsar on the grid at a specific location (Ex: ```pulsar 4 6```).
