﻿using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{779C753E-CBD6-4386-A22A-9A722BB39AA1}", "@DefaultCaseInSwitchSwitchAchievementName",
        AchievementDescription = "@DefaultCaseInSwitchSwitchAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class SwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                UnlockWith(switchStatement);
                return base.VisitSwitchStatement(switchStatement, data);
            }
        }
    }
}