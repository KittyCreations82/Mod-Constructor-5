using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.Traits;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.UI.Shared;
using Constructor5.Core;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    [SharedWithTraits]
    [HasAutoEditor("BroadcastersNotice")]
    public class BuffBroadcastersComponent : BuffComponent
    {
        [AutoEditorReferenceList("Broadcaster", ShowCreateButton = true)]
        public ReferenceList Broadcasters { get; set; } = new ReferenceList();

        public override string ComponentLabel => "Broadcasters";

        protected internal override bool HasContent() => Broadcasters.HasItems();

        protected internal override void OnExport(BuffExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("broadcaster", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            var tunableList1 = tunableTuple1.Get<TunableList>("broadcaster_types");

            foreach (var key in ElementTuning.GetInstanceKeys(Broadcasters))
            {
                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                tunableTuple2.Set<TunableBasic>("item", key);
            }
        }
    }
}