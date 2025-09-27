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

    // The main method starts our bot
    static void Main(string[] args)
    {
        new Four04FoundUs().Start();
    }

    // Called when a new round is started -> initialize and do some movement
    public override void Run()
    {
        // Set colors
        BodyColor = Color.Black;
        TurretColor = Color.Black;
        RadarColor = Color.Cyan;
        BulletColor = Color.Cyan;
        ScanColor = Color.Pink;

        // Repeat while the bot is running
        while (IsRunning)
        {
            // MAX SPEED
            MaxSpeed = 5;
            while (true)
            {
                SetTurnRight(100);
                Fire(0.1);
            }
        }
    }

    // We saw another bot -> fire!
    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(1);
    }

    // We were hit by a bullet -> turn perpendicular to the bullet
    public override void OnHitByBullet(HitByBulletEvent evt)
    {
    }
}