﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Data.Model;

namespace Strokes.Core
{
    public static class AchievementContext
    {
        // Disables the persistance of unlocked achievements. Practical for testing.
        public static bool DisablePersist = false;

        public delegate void AchievementsUnlockedHandler(object sender, AchievementsUnlockedEventArgs args);
        public static event AchievementsUnlockedHandler AchievementsUnlocked;
        public static event EventHandler AchievementDetectionStarting;

        public static void OnAchievementsUnlocked(object sender, IEnumerable<Achievement> unlockedAchievements)
        {
            if (AchievementsUnlocked != null)
            {
                AchievementsUnlocked(sender, new AchievementsUnlockedEventArgs
                {
                    Achievements = unlockedAchievements
                });
            }
        }

        public delegate void AchievementClickedHandler(object sender, AchievementClickedEventArgs args);
        public static event AchievementClickedHandler AchievementClicked;

        public static void OnAchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            if (AchievementClicked != null)
            {
                AchievementClicked(sender, args);
            }
        }

        public static void OnAchievementDetectionStarting(object sender, EventArgs e)
        {
            if (AchievementDetectionStarting != null)
            {
                AchievementDetectionStarting(sender, e);
            }
        }
    }

    public class AchievementsUnlockedEventArgs
    {
        public IEnumerable<Achievement> Achievements
        {
            get;
            set;
        }
    }

    public class AchievementClickedEventArgs
    {
        public Achievement AchievementDescriptor
        {
            get;
            set;
        }

        public object UIElement
        {
            get;
            set;
        }
    }
}
