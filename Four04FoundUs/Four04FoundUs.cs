using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using Robocode.TankRoyale.BotApi.Graphics;



using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

// ------------------------------------------------------------------
// MyFirstBot
// ------------------------------------------------------------------
// A sample bot original made for Robocode by Mathew Nelson.
//
// Probably the first bot you will learn about.
// Moves in a seesaw motion and spins the gun around at each end.
// ------------------------------------------------------------------
public class Four04FoundUs : Bot
{
    double moveAmount; // How much to move
    int turnDirection = 1;
    bool movingForward;
    bool peek; // Don't turn if there's a bot there
    int speed;



    // The main method starts our bot
    static void Main(string[] args)
    {
        new Four04FoundUs().Start();
    }

    // Called when a new round is started -> initialize and do some movement
    public override void Run()
    {
        // Set colors
        BodyColor = Color.Pink;
        TurretColor = Color.Cyan;
        RadarColor = Color.Cyan;
        BulletColor = Color.Cyan;
        ScanColor = Color.Pink;



        // Repeat while the bot is running
        while (IsRunning)
        {

        
            while (true)
            {
                GunTurnRate = 15;
                SetTurnRight(10_000);

                // Limit our speed to 5
                MaxSpeed = 4;
                // Start moving (and turning)
                Forward(10_000);

                // SetForward(15);
                // // SetBack(10);
                // SetTurnRight(50);
                // Fire(1);
            }
        }
    }


    // We saw another bot -> fire!
    public override void OnScannedBot(ScannedBotEvent e)
    {
        SetTurnLeft(5);
        SetForward(10);
        Fire(1);

        Rescan(); // Might want to move forward again!
    }

    // We were hit by a bullet -> turn perpendicular to the bullet
    public override void OnHitBot(HitBotEvent e)
    {

        TurnToFaceTarget(e.X, e.Y);

        // Determine a shot that won't kill the bot...
        // We want to ram it instead for bonus points
        if (e.Energy > 50)
            Fire(3);
        else if (e.Energy > 20)
        {
            Fire(2);
            SetBack(10);

        }
        else if (e.Energy > 4)
        {
            Fire(1);
            SetBack(10);
        }
        else if (e.Energy > 2)
        {
            Fire(0.5);
            SetBack(10);
        }
        else if (e.Energy > .4)
        {
            Fire(0.1);
            SetBack(10);
        }

    }


    private void TurnToFaceTarget(double x, double y)
    {
        var bearing = BearingTo(x, y);
        if (bearing >= 0)
            turnDirection = 1;
        else
            turnDirection = -1;

        TurnLeft(bearing);
    }

}

// using System;
// using Robocode.TankRoyale.BotApi;
// using Robocode.TankRoyale.BotApi.Events;
// using Robocode.TankRoyale.BotApi.Graphics;

// // ------------------------------------------------------------------
// // Walls
// // ------------------------------------------------------------------
// // A sample bot original made for Robocode by Mathew Nelson.
// //
// // This robot navigates around the perimeter of the battlefield with
// // the gun pointed inward.
// // ------------------------------------------------------------------
// public class Walls : Bot
// {
//     bool peek; // Don't turn if there's a bot there
//     double moveAmount; // How much to move

//     // The main method starts our bot
//     static void Main()
//     {
//         new Walls().Start();
//     }

//     // Called when a new round is started -> initialize and do some movement
//     public override void Run()
//     {
//         // Set colors
//         BodyColor = Color.Black;
//         TurretColor = Color.Cyan;
//         RadarColor = Color.Orange;
//         BulletColor = Color.Cyan;
//         ScanColor = Color.Cyan;

//         // Initialize moveAmount to the maximum possible for the arena
//         moveAmount = Math.Max(ArenaWidth, ArenaHeight);
//         // Initialize peek to false
//         peek = false;

//         // turn to face a wall.
//         // `Direction % 90` means the remainder of Direction divided by 90.
//         TurnRight(Direction % 90);
//         Forward(moveAmount);

//         // Turn the gun to turn right 90 degrees.
//         peek = true;
//         TurnGunLeft(90);
//         TurnLeft(90);
//         TurnLeft(360);
        
    
//         // Main loop
//         while (IsRunning)
//         {
//             {
//                 // Peek before we turn when forward() completes.
//                 peek = true;
//                 // Move up the wall
//                 Forward(moveAmount);
//                 // Don't peek now
//                 peek = false;
//                 // Turn to the next wall
//                 TurnLeft(90);
                


//             }
//         }
//     }
//     // We hit another bot -> move away a bit
//     public override void OnHitBot(HitBotEvent e)
//     {
//         // If he's in front of us, set back up a bit.
//         var bearing = BearingTo(e.X, e.Y);
//         if (bearing > -90 && bearing < 90)
//         {
//             Back(50);
//         }
//         else
//         { // else he's in back of us, so set ahead a bit.
//             Forward(50);
//             TurnLeft(30);
//         }
//     }

//     // We scanned another bot -> fire!
//     public override void OnScannedBot(ScannedBotEvent e)
//     {
//         SetFire(2);
//         // Note that scan is called automatically when the bot is turning.
//         // By calling it manually here, we make sure we generate another scan event if there's a bot
//         // on the next wall, so that we do not start moving up it until it's gone.
//         TurnGunLeft(360);
//         Forward(0);
//         SetFire(2);
//         SetFire(1);
//         Rescan();
//         if (peek)
//             Rescan();
//     }
// }