﻿using Constructor5.Base.ElementSystem;
using Constructor5.UI.Shared;
using System.Reflection;
using System.Windows;

namespace Constructor5.UI.AutoGeneratedEditors
{
    public class AutoEditorReferenceList : AutoEditorAttribute
    {
        public AutoEditorReferenceList()
        {

        }

        public AutoEditorReferenceList(string elementTypeName, string itemTypeName = "ReferenceListItem")
        {
            ElementTypeName = elementTypeName;
            ItemTypeName = itemTypeName;
        }

        public string EditorCategory { get; set; } = "ElementMini";
        public string EditorTag { get; set; }
        public string ElementTypeName { get; set; }
        public string ItemTypeName { get; set; } = "ReferenceListItem";
        public bool ShowCreateButton { get; set; }

        public override UIElement CreateControl(object obj, PropertyInfo prop)
        {
            var result = new ReferenceListControl()
            {
                EditorCategory = EditorCategory,
                EditorTag = EditorTag,
                ElementReferenceList = (ReferenceList)prop.GetValue(obj),
                ElementTypeName = ElementTypeName,
                ItemTypeName = ItemTypeName,
                ShowCreateButton = ShowCreateButton
            };
            result.CreateElementFunction += () =>
            {
                return CreateElementFunction(obj);
            };
            return result;
        }

        protected virtual Element CreateElementFunction(object obj)
        {
            return null;
        }
    }
}