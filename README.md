# Unity3D Tower Defence Game (Thunder Warriors)

## [Makers Academy](http://www.makersacademy.com) - Week 11/12 - Final Group Project

![Thunder Warriors Poster](https://d541d4157b28d9cb38c5-cf41a704c6c093350fcb8a1fb943b3e5.ssl.cf5.rackcdn.com/github-readme-images/thunder-warriors/thunder-warriors-poster-smaller-text.png)

## Technologies
* [Unity3D](https://unity3d.com/)
* [C#](https://en.wikipedia.org/wiki/C_Sharp_programming_language)
* [NUnit](https://www.nunit.org/)

## Jump To
* [User Stories](#user-stories)
* [Game Rules](#rules)
* [Installation](#install)
* [Heroku Demo](#demo)
* [Youtube Presentation Video](http://www.youtube.com/watch?v=nKK-ov95Q9E&t=18m25s)
* [Screenshots](#screenshots)

## The Project

This is the [Makers Academy](http://www.makersacademy.com) final two-week group project. [We](#collaborators) decided to build a 3D [Tower Defence] video game using the [Unity3D](https://unity3d.com/) multi platform game development tool.

After some discussion, we settled on an 80s theme for the game, and the name "Thunder Warriors" came from an 80s random name generator!

[None of us](#collaborators) had ever created a video game, or coded in C# before, so it was a brand new challenge for all of us. We had two weeks to learn how to use the Unity platform, learn a new language, and to create a video game using this newly acquired knowledge.

The first few days were spent researching and playing about with Unity, and then we were ready to start building. By the end of the first week, we had hit our Minimum Viable Product, but we were not happy with the quality of the code base and it ignored a lot of the design patterns and best practices that we’d learned over the last 12 weeks at Makers Academy.

On the Monday of the second (and final) week, we took the brave step of starting a huge refactor of the existing code, so that we could hopefully finish the project with a well structured and testable code base.

Cleaning up the code and making it testable, whilst trying to keep the same level of game functionality was a challenge, and one that took as long to achieve as it did for us to hit our Minimum Viable Product.

But it was worth it, we learnt a lot during the process and the code is now much more extendable. We now plan on developing new features and levels for the game.

[You can watch a recording of our live-streamed presentation of the project here.](http://www.youtube.com/watch?v=nKK-ov95Q9E&t=18m25s)

## <a name="user-stories">User Stories</a>

```
As a player,
So that I can play this awesome game,
I want to be able to start a game.

As a player,
So that I can play for more than one level,
I want there to be more than one playable level.

As a player,
So that I can defend the route,
I want to be able to place a tower along the route.

As a player,
So that my towers have something to shoot at,
I want to enemies to spawn at the start of the route.

As a player,
So that I can prevent enemies from reaching the end of the route,
I want to be able to destroy enemies with my towers.

As a player,
So that I can win a game,
I need to be able to kill all enemies (of n waves).

As a player
So that I can lose a game,
I will lose a life an enemy makes it to the end of the route.

As a player
So that I can see how many enemy waves remain,
I want to be able to see the number remaining on the screen.

As a player,
So that I can enjoy this awesome game even more,
I want to be able to hear some funky music.

As a player,
So that I can make my towers more powerful,
I want to be able to upgrade a tower.

As a player,
So that I can remove a tower that I no longer need,
I want to be able to sell a tower.

As a player,
So that I can get the best view of the action,
I want to be able to pan and zoom the camera.
```

## <a name="rules">Game Rules</a>

* Players can place towers on the designated tower nodes in order to destroy enemies.
* Towers cost gold to buy.
* Each enemy killed gives the player additional gold.
* Some towers can be upgraded (this also costs gold).
* Towers can be sold in return for gold.
* If an enemy makes it to the end of the route, the player loses a life.
* If the player loses all their lives, the game is over.
* If the player endures all of the enemy waves without losing all their lives, the level is complete.

## <a name="install">Installation</a>

The game cannot be installed as such from this repo, as it relies on paid assets from the Unity Asset Store. This repo serves as an example of the code behind the game mechanics. The C# scripts driving the game can be found in the folder: /Assets/80std/Script/

We have an associated [repo here](https://github.com/treborb/thunder-warriors), which contains instructions for installing the game so that it can be run locally and played in the browser.

## <a name="demo">[Heroku Demo](https://thunder-warriors.herokuapp.com)</a>
Click on the link above to play a live, web browser based demo

## <a name="screenshots">Screenshots</a>

![Thunder Warriors Screenshot 1](https://d541d4157b28d9cb38c5-cf41a704c6c093350fcb8a1fb943b3e5.ssl.cf5.rackcdn.com/github-readme-images/thunder-warriors/1.png)

![Thunder Warriors Screenshot 2](https://d541d4157b28d9cb38c5-cf41a704c6c093350fcb8a1fb943b3e5.ssl.cf5.rackcdn.com/github-readme-images/thunder-warriors/2.png)

![Thunder Warriors Screenshot 3](https://d541d4157b28d9cb38c5-cf41a704c6c093350fcb8a1fb943b3e5.ssl.cf5.rackcdn.com/github-readme-images/thunder-warriors/4.png)

## <a name="collaborators">Collaborators</a>

[Rob Brentnall](https://github.com/treborb)
[Ben Carson](https://github.com/BenJohnCarson)
[Peter Grant-Hay](https://github.com/Putterhead)
[James Turner](https://github.com/JamesTurnerGit)
