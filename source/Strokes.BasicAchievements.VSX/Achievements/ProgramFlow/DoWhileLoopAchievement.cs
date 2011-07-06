﻿using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("DoWhile loop", AchievementDescription = "Use a do-while loop", AchievementCategory = "Basic Achievements")]
    public class DoWhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                if (doLoopStatement.ConditionPosition == ConditionPosition.End) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
                {
                    IsAchievementUnlocked = true;
                }

                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
        }
    }
}