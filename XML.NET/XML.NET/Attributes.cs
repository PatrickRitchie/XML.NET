// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Xml;

namespace XML
{
    public static class Attributes
    {

        public static bool Set(XmlDocument doc, string xPath, string attributeName, string attributeValue)
        {
            bool result = false;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                var node = element.SelectSingleNode(xPath);
                if (node == null) node = Nodes.Add(doc, xPath);
                if (node != null)
                {
                    var attr = doc.CreateAttribute(attributeName);
                    attr.Value = attributeValue;

                    node.Attributes.SetNamedItem(attr);

                    result = true;
                }
            }

            return result;
        }

        public static string Get(XmlNode node, string attributeName)
        {
            string result = null;

            if (node != null && node.Attributes != null)
            {
                var attribute = node.Attributes[attributeName];
                if (attribute != null) result = attribute.Value;
            }

            return result;
        }

    }
}
