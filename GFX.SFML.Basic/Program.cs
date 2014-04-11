﻿using System;
using SFML.Graphics;
using SFML.Window;

namespace StarterKits.SFMLDotNet
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var contextSettings = new ContextSettings {
                DepthBits = 32
            };
            var window = new RenderWindow(new VideoMode(640, 480), "JukeSaver spike: SFML Basic", Styles.Default, contextSettings);
            window.SetActive();

            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;

            int r = 0, g = 0, b = 0;

            const float pulseModifier = (float)Math.PI * 0.002f; // To convert a vealue from 0-1000 to a smooth 'pulse'
            var shape = new CircleShape() {
                Position = new Vector2f(320, 240),
            };

            while (window.IsOpen()) {
                window.DispatchEvents();
                window.Clear(new Color((byte)r, (byte)g, (byte)b));

                shape.Radius = 50 + Math.Abs(pulseModifier * DateTime.Now.Millisecond) * 100;

                window.Display();
            }
        }

        static void OnClosed(object sender, EventArgs e)
        {
            var window = (Window)sender;
            window.Close();
        }

        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            var window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
                window.Close();
        }

    }
}
