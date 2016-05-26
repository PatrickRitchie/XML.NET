// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Xml;

namespace XML
{
    public static class InnerText
    {
        public static bool Set(XmlDocument doc, string xPath, string text)
        {
            bool result = false;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                var node = element.SelectSingleNode(xPath);
                if (node == null) node = AddNode(doc, xPath);

                node.InnerText = text;
                result = true;
            }

            return result;
        }

        public static string Get(XmlDocument doc, string xPath)
        {
            string result = null;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                var node = element.SelectSingleNode(xPath);
                if (node != null)
                {
                    result = node.InnerText;
                }
            }

            return result;
        }
    }
}
