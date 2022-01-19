using Constructor5.Base.ElementSystem;
using Constructor5.UI.AutoGeneratedEditors;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public partial class ObjectEditorControl : UserControl
    {
        public ObjectEditorControl() => InitializeComponent();

        public string EditorCategory
        {
            get => (string)GetValue(EditorCategoryProperty);
            set => SetValue(EditorCategoryProperty, value);
        }

        public static readonly DependencyProperty EditorCategoryProperty =
            DependencyProperty.Register("EditorCategory", typeof(string), typeof(ObjectEditorControl), new PropertyMetadata(null));

        public string EditorTag
        {
            get => (string)GetValue(EditorTagProperty);
            set => SetValue(EditorTagProperty, value);
        }

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(ObjectEditorControl), new PropertyMetadata(null));

        public object Object
        {
            get => GetValue(ObjectProperty);
            set => SetValue(ObjectProperty, value);
        }

        public static readonly DependencyProperty ObjectProperty =
            DependencyProperty.Register("Object", typeof(object), typeof(ObjectEditorControl),
                new PropertyMetadata(null, (dp, e) =>
                {
                    var control = (ObjectEditorControl)dp;
                    control.OnChanged(e.OldValue);
                }));

        private void OnChanged(object oldValue)
        {
            if (EditorCategory == null)
            {
                throw new Exception("Category must be set before object");
            }

            var oldAutosaveableObject = oldValue as Element;

            if (oldAutosaveableObject != null && ObjectEditorManager.HasEditor(oldAutosaveableObject, EditorCategory))
            {
                ElementSaver.Unmark(oldAutosaveableObject, this);
            }

            if (Object == null)
            {
                ContentPresenter.Content = null;
                return;
            }

            var editor = ObjectEditorManager.CreateEditor(Object, EditorCategory, EditorTag);
            ContentPresenter.Content = editor;

            if (editor == null)
            {
                return;
            }

            MarkForAutosave();
        }

        private void MarkForAutosave()
        {
            var autosaveableObject = Object as Element;

            if (autosaveableObject != null)
            {
                ElementSaver.Mark(autosaveableObject, this);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Object == null)
            {
                return;
            }

            if (ObjectEditorManager.HasEditor(Object, EditorCategory))
            {
                MarkForAutosave();
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            var autosaveableObject = Object as Element;

            if (autosaveableObject == null)
            {
                return;
            }

            if (ObjectEditorManager.HasEditor(Object, EditorCategory))
            {
                ElementSaver.Unmark(autosaveableObject, this);
            }
        }
    }
}
