using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.LootActionSets
{
    public abstract class LootAction : INotifyPropertyChanged, IHasSettableLabel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ActionGuid
        {
            get
            {
                if (_actionGuid == null)
                {
                    ActionGuid = GuidUtility.GenerateGuid(UsedGuids);
                }

                return _actionGuid;
            }
            set
            {
                if (_actionGuid != null)
                {
                    UsedGuids.Remove(_actionGuid);
                }

                _actionGuid = value;
                UsedGuids.Add(ActionGuid);
            }
        }

        [XmlAttribute]
        public string CustomLabel { get; set; }

        [XmlAttribute]
        public string GeneratedLabel { get; set; }

        [XmlIgnore]
        public string Label => CustomLabel ?? GeneratedLabel;

        string IHasSettableLabel.SettableLabel
        {
            get => CustomLabel;
            set => CustomLabel = value;
        }

        protected internal abstract void OnExport(LASExportContext originalContext);

        private string _actionGuid;
        private static HashSet<string> UsedGuids { get; } = new HashSet<string>();
    }
}