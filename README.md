# Project Description
This project was made to complete a university course called 'Game Development'. <br>
It's a 2D aracde game.

## 🛠️ Applied technologies
- **Game engine**: Unity 6.1 <br>
- **Game editor**: Unity Editor <br>
- **Gameplay recorder**: Unity Recorder (Unity’s internal recorder in Unity Editor) <br>
- **Programming language**: C# <br>
- **IDE**: Visual Studio 2019 Community Edition <br>
- **Graphics**: I edited the graphics to remove the unnecessary background in https://www.photoroom.com/tools/background-remover. I also used MS Power Point, Paint and Chat GPT. <br>
- **SFX and music**: I edited SFX in https://twistedwave.com/online  <br>

Folder **&ldquo;GameRelease&ldquo;**  contains the released game, you can download the .zip file and run &ldquo;FirstProject.exe&ldquo;.
<br>
<br>

# GAME DESIGN DOCUMENT

## 1. Executive Summary, Quick overview
Bird Adventure is a classical 2D arcade game relying on repetitive and rapid gameplay cycles. The well-known Flappy Bird was the initial source of inspiration for this game. <br>
The main concept of the game is to keep the bird alive as long as possible to maximize the score in the current gameplay. 
To earn the scores the player has to maneuver the bird through the appearing pipes without touching them or completely going off the screen. <br>
Next to the pipes, there are other objects (listed in chapter 6) that show up on the screen and the bird can interact with them. Player can decide to pick or avoid these objects as it&#39;s up to the special effect of the certain object. <br>
The game ends when the bird collides with the walls of the screen or pipes. <br>
Game states: Start -> Main Menu -> Playing -> Game Over -> High Score Board

## 2. Target Audience
The target audience of Bird Adventure is high-school teenage people who likes simple but action-packed games. Due to the pursuit of high scores, there can be a small competition among the pupils in the classroom. 
Beyond this, the less tech-savvy people around age 50 are also promising as they show interest towards modest 2D mobile games such as platformer and puzzle games these days. They likely to play simple but entertaining games nowadays. Perhaps it reminds them their childhood in the early 90s. 

## 3. Main Characters
In Bird Adventure, player can control a single main character over the gameplay. The main character is a red bird called &ldquo;Larry Bird&ldquo; in the game. The bird is drawn in cartoon style (like Angry Birds) to make it even friendlier.

## 4. Main Features
### 4.1 Main mechanics
The main objective of the player is to drive the bird in order to get through the pipes and earn scores. When the bird flies through the pipes it is worth one score.
Crossing after every 10th pipe, the player gets into the next level. This means that the pipes are spawned quicker in the game. More the score the player have, more difficult to keep the bird alive. <br>
The bird is controlled by flips in a vertical direction and must get through the pipes. Here is a picture of the releasable game to illustrate the game. <br>
Game state loop: Start -> Playing -> Game Over -> High Score Board
 

### 4.2 Movement
The bird&#39;s position is fixed along the horizontal axis. The vertical movement is controlled by the player. The bird flips (rises) when the player press the **SPACE** button which applies an upward force. If the player does not hit **SPACE**, then the bird automatically falls and dies. In practice, the player can govern the character only upwards in the game. <br>
Core movement loop: Hit SPACE -> Flip -> Dodge -> Score <br>
<br>
Due to the bird is being fixed on the horizontal axis in the same position along the gameplay therefore all other objects are being moved towards the bird in the game. Hence, each object (listed in chapter 6) have a fixed move speed and transformed frame by frame. This emulates the moving/sliding effect on the screen. 
### 4.3 Physics
The bird&#39;s movement is managed by Unity&#39;s own physics system. Gravity constantly pulls the bird downward due to RigidBody2D component applied on the bird&#39;s game object in Unity. This embodies the necessary gravitation effect on the bird. The gravity scale is set to 0 which corresponds to the force of gravity (Mass * 9.81 m/s/s).
In the game, each object has collision detection implemented via Circle Collider 2D or Box Collider 2D. These are responsible for making the object interactable by triggers when the bird collides with them.

### 4.4 Multiplayer mode
No multiplayer mode is implemented in this release of Bird Adventure.

## 5. Genre, Setting, Concept Art book
The genre is 2D arcade game. The game scene is happening in the skies where the player can control the flipping bird.
I attach pictures of the objects that are available in the game.

<p align="center">
  <strong>Bird</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/3474f0106eae4b48a04074b8ce8066fbe33b25f9/GitImgs/Healthy_bird.png" alt="Bird" width="400">
</p>
<br>
<p align="center">
  <strong>Poisoned Bird</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/3474f0106eae4b48a04074b8ce8066fbe33b25f9/GitImgs/Poisoned_bird.PNG" alt="Poisoned Bird" width="400">
</p>
<br>
<p align="center">
  <strong>Pipe</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/3474f0106eae4b48a04074b8ce8066fbe33b25f9/GitImgs/Pipe.png" alt="Pipe" width="200" height="400" >
</p>
<br>
<p align="center">
  <strong>Rotten Apple</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/d99414b4a98d38674fddaea9774b3d8e1c2664d5/GitImgs/Rotten_apple.png" alt="Rotten Apple" width="200">
</p>
<br>
<p align="center">
  <strong>Coin</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/3474f0106eae4b48a04074b8ce8066fbe33b25f9/GitImgs/Coin.png" alt="Coin" width="200">
</p>
<br>
<p align="center">
  <strong>Green Potion</strong><br>
  <img src="https://github.com/mustDestroy/BirdAdventure/blob/d99414b4a98d38674fddaea9774b3d8e1c2664d5/GitImgs/Green_Potion.PNG" alt="Green Potion" width="200">
</p>
<br>

## 6. Enemies, NPCs, Other objects

<table style="border-collapse: collapse; width: 100%; text-align: center; border: 2px solid black">
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" rowspan="5"><b>Pipe</b></th>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" ><b>Type</b></th>
    <td style="border: 1px solid black; padding: 6px;"> Moving statix obstacle</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center; "><b>Special Effect</b></th>
    <td style="border: 1px solid black; padding: 6px; ">Instant game over</td> 
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Controllable</b></th>
    <td style="border: 1px solid black; padding: 6px;">No</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Impact</b></th>
    <td style="border: 1px solid black; padding: 6px;">Bird dies<br> Triggers to play an SFX</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Spawn Rate</b></th>
    <td style="border: 1px solid black; padding: 6px;">Dynamic, the rate decreases after every 10th crossed pipe by 0.1 which results in faster spawning cycles</td>
  </tr>
</table>


<table style="border-collapse: collapse; width: 100%; text-align: center; border: 2px solid black">
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" rowspan="5"><b>Coin</b></th>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" ><b>Type</b></th>
    <td style="border: 1px solid black; padding: 6px;">Neutral</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center; "><b>Special Effect</b></th>
    <td style="border: 1px solid black; padding: 6px; ">Increases the earned coins by 1</td> 
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Controllable</b></th>
    <td style="border: 1px solid black; padding: 6px;">Yes</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Impact</b></th>
    <td style="border: 1px solid black; padding: 6px;">Triggers to play an SFX</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Spawn Rate</b></th>
    <td style="border: 1px solid black; padding: 6px;">Fixed</td>
  </tr>
</table>




<table style="border-collapse: collapse; width: 100%; text-align: center; border: 2px solid black">
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" rowspan="5"><b>Rotten Apple</b></th>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" ><b>Type</b></th>
    <td style="border: 1px solid black; padding: 6px;">Harmful</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center; "><b>Special Effect</b></th>
    <td style="border: 1px solid black; padding: 6px; ">When the bird picks, it changes the bird’s sprite and set its status to “poisoned” until next Green Potion is picked up</td> 
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Controllable</b></th>
    <td style="border: 1px solid black; padding: 6px;">No</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Impact</b></th>
    <td style="border: 1px solid black; padding: 6px;">Triggers SFX to play <br> Set the current gravity scale to strogner (=4.0)</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Spawn Rate</b></th>
    <td style="border: 1px solid black; padding: 6px;">Fixed</td>
  </tr>
</table>





<table style="border-collapse: collapse; width: 100%; text-align: center; border: 2px solid black">
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" rowspan="5"><b>Green Potion</b></th>
    <th style="border: 1px solid black; padding: 6px; text-align:center;" ><b>Type</b></th>
    <td style="border: 1px solid black; padding: 6px;">Healing</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center; "><b>Special Effect</b></th>
    <td style="border: 1px solid black; padding: 6px; ">When the bird picks, it changes the bird’s sprite and set it status to “cured” until next Rotten Apple is picked up</td> 
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Controllable</b></th>
    <td style="border: 1px solid black; padding: 6px;">No</td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Impact</b></th>
    <td style="border: 1px solid black; padding: 6px;">Triggers SFX to play <br> Set the gravity scale to normal (=2.5) </td>
  </tr>
  <tr>
    <th style="border: 1px solid black; padding: 6px; text-align:center;"><b>Spawn Rate</b></th>
    <td style="border: 1px solid black; padding: 6px;">Fixed</td>
  </tr>
</table>


## 7. Story board, script
### 7.1 Story overview
As I said above, there is no well-defined &ldquo;story&ldquo; concept in the game. The only concept here: player dies early and retry again while you can not break your own record in the game. It can be called like a self-challenge to the actual player which motivates him to take further tries.


## 8. Technical definitions, Tech guide
### 8.1 Platforms, versions
The current release supports Windows only.
It requires a working keyboard and mouse to be connected to the machine.
### 8.2 Control Scheme
### 8.3 Limitations
## 9. Business definitions
### 9.1 In-app purchases
### 9.2 DLC packs
## 10. Outsourced/Bought Assets
I found very assets over the Internet for free in case of personal use.
All the applied assets including music, SFX, graphics and fonts are free to use for non-commercial projects. <br>
 I will share the links to reference them below.

### 10.1 Music
- Fight music: 10- Sear The Time Vortex: FREE Music Pack (Lo-fi, Indie, Metal, Horror, Orchestral) (LOOPS!) | Orchestral Music | Unity Asset Store <br>
- Lobby music: 01- Hamster haven.wav: FREE Music Pack (Lo-fi, Indie, Metal, Horror, Orchestral) (LOOPS!) | Orchestral Music | Unity Asset Store <br>
- In-game music: 02-It&#39;s a Fight.wav: FREE Music Pack (Lo-fi, Indie, Metal, Horror, Orchestral) (LOOPS!) | Orchestral Music | Unity Asset Store <br>

### 10.2 SFX
- Cross pipes: Checkpoint_2.wav: https://assetstore.unity.com/packages/audio/sound-fx/hints-stars-points-rewards-sound-effects-lite-pack-295538#content
- Bird death: DM-CGS16: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116#content
- Mouse Click: DM-CGS30: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116#content
- Mouse Hoover: DM-CGS36: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116#content
- Collect coin: coin_6.wav: https://assetstore.unity.com/packages/audio/sound-fx/8-bits-elements-16848
- Bite apple: (cartoon bite): https://pixabay.com/sound-effects/search/bite-apple/
- Drink Potion: 085594_Potion: https://pixabay.com/sound-effects/085594-potion-35983/

### 10.3 Graphics
- Parallax: https://rengodev.itch.io/free-cloud-sky-parallax-background
- Bird: https://www.dropbox.com/scl/fo/h8k4jhq564idb46j31czk/AHeDl5TZW6pZi6ZmSCXiaaM?rlkey=hn50slzeizx0602xxduvzw8kc&e=1&dl=0
- Rotten apple: https://pixxilandartstudio.itch.io/2d-pixel-art-undead-rotten-apple-sprites
- Flas/Potion: https://pixel-hack.itch.io/boiling-flasks

### 10.4 Font
- Pixel font: 04b_30: https://www.dafont.com/font-comment.php?file=04b_30&fpp=200&back=bitmap
- Bright Aura font: https://www.dafont.com/bright-aura.font

















