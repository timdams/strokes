﻿using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{54B78C8F-270F-49EB-B205-ABB66E7A6FB9}", "@TryFinallyStatementAchievementName",
        AchievementDescription = "@TryFinallyStatementAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class TryFinallyStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if (tryCatchStatement.CatchClauses.Count == 0 && !tryCatchStatement.FinallyBlock.IsNull)
                {
                    UnlockWith(tryCatchStatement);
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}