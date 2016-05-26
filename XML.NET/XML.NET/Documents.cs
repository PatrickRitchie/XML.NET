// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;
using System.Xml;

namespace XML
{
    public static class Documents
    {

        public static XmlDocument FromString(string str)
        {
            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(str);

                return xml;
            }
            catch (Exception ex) { if (Configuration.Verbose) Console.WriteLine("XML.Documents.FromString() :: Exception :: " + ex.Message); }

            return null;
        }

        public static string ToString(XmlDocument doc)
        {
            try
            {
                using (var stringWriter = new StringWriter())
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex) { if (Configuration.Verbose) Console.WriteLine("XML.Documents.ToString() :: Exception :: " + ex.Message); }

            return null;
        }

    }
}
