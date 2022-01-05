﻿using Constructor5.Base.Export;
using Constructor5.Xml;
using System.IO;

namespace Constructor5.Base.ExportSystem.Tuning.Utilities
{
    public static class TuningExport
    {
        public static void AddToQueue(TuningHeader tuning)
        {
            var memoryStream = new MemoryStream();
            XmlSaver.SaveStream(tuning, memoryStream);
            Exporter.Current.QueueFile(tuning.GetHexTypeKey(), tuning.GetHexGroupKey(), tuning.GetHexInstanceKey(), memoryStream);

            if (tuning.SimDataHandler != null)
            {
                Exporter.Current.QueueFile("545AC67A", FNVHasher.FNV24(tuning.InstanceType).ToString("X"), tuning.GetHexInstanceKey(), tuning.SimDataHandler.Stream);
            }
            if (tuning.SimDataBuilder != null)
            {
                Exporter.Current.QueueFile("545AC67A", FNVHasher.FNV24(tuning.InstanceType).ToString("X"), tuning.GetHexInstanceKey(), tuning.SimDataBuilder.Stream);
            }
        }
    }
}
