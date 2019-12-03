using Assets.Scripts.Engine.Network;
using Assets.Scripts.Game;
using System.Runtime.InteropServices;

using UnityEngine;


namespace Hired_Ops_Aimbot
{
    public class Hacks : MonoBehaviour
    {
        #region DllImport("user32.dll")
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        #endregion

        void Update()
        {
            EnableHighlight();
            Aimbot();
        }

        public void EnableHighlight()
        {
            var Lobby = UnityNetworkConnection.ClientGame;

            if (Lobby)
            {
                var LokalerSpieler = Lobby.LocalPlayer;

                // Loop through all alive Players
                foreach (EntityNetPlayer Player in Lobby.AlivePlayers)
                {
                    if (!Player.IsTeammate(LokalerSpieler)) // Enemy?
                    {
                        Player.playerInfo.highlighted = true; // If yes, enable Highlight
                    }
                }
            }
        }

        public void Aimbot()
        {
            float minDist = 99999; // Reset Distance to some high number because we know that the Enemies will be closer to us than that number.
            Vector2 AimTarget = Vector2.zero; // Declare a new Vector2 for the Screen Position where the mouse will aim at.
            int smooth = 5; // Smooth that gets used to move your mouse. If you make it smaller it will be more snapy.

            try
            {
                var Lobby = UnityNetworkConnection.ClientGame;

                if (Lobby)
                {
                    var LokalerSpieler = Lobby.LocalPlayer;

                    foreach (EntityNetPlayer Player in Lobby.AlivePlayers)
                    {
                        if (Player.IsTeammate(LokalerSpieler)) // If the Player is us, skip. We don't want to aim at ourselves which would probably cause us to spin.
                        {
                            continue;
                        }

                        // Get the World Position of the Enemys Body Part..
                        Vector3 Enemy_Bodypart_Position = Player.playerBoneFinder.NPC_Head.position;
                        // ..and convert it to Screen Positions.
                        var shit = Camera.main.WorldToScreenPoint(Enemy_Bodypart_Position);

                        if (shit.z > 0f) // If the enemy isn't behind the camera (us), do...
                        {
                            // Get Distance.
                            float dist = System.Math.Abs(Vector2.Distance(new Vector2(shit.x, Screen.height - shit.y), new Vector2((Screen.width / 2), (Screen.height / 2))));
                            if (dist < 300) // FOV
                            {
                                if (dist < minDist) // If we find a closer target, set him as the aim target.
                                {
                                    minDist = dist;
                                    AimTarget = new Vector2(shit.x, Screen.height - shit.y);
                                }
                            }
                        }
                    }
                    if (AimTarget != Vector2.zero) // If the Vector isn't empty (there is no enemy position converted to screen position), don't aim.
                    {
                        // Center of the Screen
                        double DistX = AimTarget.x - Screen.width / 2.0f;
                        double DistY = AimTarget.y - Screen.height / 2.0f;

                        // Aimbot Smooth.
                        DistX /= smooth;
                        DistY /= smooth;

                        if (Input.GetKey(KeyCode.V)) // Aimbot Key.
                        {
                            mouse_event(0x0001, (int)DistX, (int)DistY, 0, 0); // Move Mouse to that point.
                        }
                    }
                }
            }
            catch
            {
                // Handle Errors here.
            }
        }
    }
}