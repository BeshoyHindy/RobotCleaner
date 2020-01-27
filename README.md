# What is the RobotCleaner? 

 **RobotCleaner** is a soultion written in .NET Core 3.1
 
The goal of the project is to implement a prototype of a robot designed to clean a place based on specific commands od directions and steps and then can read the unique cleaning positions.
# How to use:

- You will need the latest Visual Studio 2019 and the .NET Core SDK 3.1.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Project in Visual Studio Code (Windows, Linux or MacOS).


# Solution Behaviors

-  starting the application by write start or -s.
-  given the first argument the number of commands.
-  then given the starting positions coordinates whitespace-separated.
-  then given the  newline-separated commands by writing the direction  and  count of steps whitespace-separated.
-  then to read the cleaned positions write report or -r.


Starting the robrot
```sh
$ -s or start
$ 2
$ 10 22
$ E 2
$ N 1
```

Reading the cleaned positions
```sh
$ -r or report
$ Cleaned: 4
```