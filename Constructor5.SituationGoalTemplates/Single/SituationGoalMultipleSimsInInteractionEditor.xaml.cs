﻿using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [ObjectEditor(typeof(SituationGoalMultipleSimsInInteractionTemplate))]
    public partial class SituationGoalMultipleSimsInInteractionEditor : UserControl, IObjectEditor
    {
        public SituationGoalMultipleSimsInInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}