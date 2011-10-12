﻿using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{EAEDD6AB-B8DE-4D90-BD62-DD3C00FDA6C1}", "@VirtualMethodAchievementName",
        AchievementDescription = "@VirtualMethodAchievementDescription",
        AchievementCategory = "@Class")]
    public class VirtualMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if(methodDeclaration.Modifier.HasFlag(Modifiers.Virtual))
                    UnlockWith(methodDeclaration);
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{56BCD937-CF59-4993-8A69-0A4E13842745}", "@OverrideMethodAchievementName",
        AchievementDescription = "@OverrideMethodAchievementDescription",
        AchievementCategory = "@Class")]
    public class OverrideMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Modifier.HasFlag(Modifiers.Override))
                    UnlockWith(methodDeclaration);
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}