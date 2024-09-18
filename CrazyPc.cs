using System;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Drawing;

namespace CrazyPc
{
    internal class CrazyPc
    {
        public static Random _random = new Random();

        public static void CrazyFunctionCall()
        {
            Thread crazyMouseThread = new Thread(CrazyMouseThread);
            Thread crazyKeyboardThread = new Thread(CrazyKeyboardThread);
            Thread crazySoundThread = new Thread(CrazySoundThread);
            Thread crazyPopupThread = new Thread(CrazyPopupThread);

            crazyMouseThread.Start();
            crazyKeyboardThread.Start();
            crazySoundThread.Start();
            crazyPopupThread.Start();

            DateTime future = DateTime.Now.AddSeconds(20);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            crazyMouseThread.Abort();
            crazyKeyboardThread.Abort();
            crazySoundThread.Abort();
            crazyPopupThread.Abort();

        }

        static void CrazyMouseThread()
        {
            int movex = 0;
            int movey = 0;

            while (true)
{
                movex = _random.Next(40) - 10;
                movey = _random.Next(40) - 10;
                Console.WriteLine($"Mouse move: X={movex}, Y={movey}");
                Cursor.Position = new Point(Cursor.Position.X + movex, Cursor.Position.Y + movey);
                Thread.Sleep(100);
            }
        }

        static void CrazyKeyboardThread()
        {
            Console.WriteLine("Keyboard Automation Started");

            while (true)
            {
                char key = (char)(_random.Next(26) + 65); 
                if (_random.Next(2) == 0)
                {
                    key = Char.ToLower(key);
                }

                SendKeys.SendWait(key.ToString());
                Thread.Sleep(_random.Next(2000));
            }
        }

        static void CrazySoundThread()
        {
            Console.WriteLine("Crazy Sound Thread Started.");

            while (true)
            {
                if (_random.Next(100) > 90)
                {
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }
Thread.Sleep(_random.Next(500));
            }
        }

        static void CrazyPopupThread()
        {
            Console.WriteLine("Popup Thread Started.");

            while (true)
            {
                MessageBox.Show("This is a crazy popup!", "CrazyPc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread.Sleep(_random.Next(5000, 10000)); 
            }
        }
    }
}
