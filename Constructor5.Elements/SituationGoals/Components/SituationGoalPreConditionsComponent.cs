﻿using Constructor5.Elements.TestConditions;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    public class SituationGoalPreConditionsComponent : SituationGoalComponent
    {
        public override string ComponentLabel => "AvailabilityConditions";

        public TestConditionList Conditions { get; set; } = new TestConditionList();

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            TestConditionTuning.TuneTestConditions(context.Tuning, Conditions.ToConditionList(), "_pre_tests", "GoalPreCondition");
        }
    }
}
