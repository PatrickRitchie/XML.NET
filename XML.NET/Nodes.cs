// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Linq;
using System.Xml;

namespace XML
{
    public static class Nodes
    {

        public static XmlNode Add(XmlDocument doc, string xPath)
        {
            XmlNode result = null;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                if (doc.DocumentElement != null)
                {
                    var node = CreatePath(doc, doc.DocumentElement as XmlNode, xPath);
                    if (node != null) result = node;
                }
            }

            return result;
        }

        private static XmlNode CreatePath(XmlDocument doc, XmlNode parent, string xPath)
        {
            // grab the next node name in the xpath; or return parent if empty
            string[] partsOfXPath = xPath.Trim('/').Split('/');

            string nextNodeInXPath = partsOfXPath.First();
            if (string.IsNullOrEmpty(nextNodeInXPath)) return parent;

            // get or create the node from the name
            XmlNode node = parent.SelectSingleNode(nextNodeInXPath);
            if (node == null) node = parent.AppendChild(doc.CreateElement(nextNodeInXPath));

            // rejoin the remainder of the array as an xpath expression and recurse
            string rest = string.Join("/", partsOfXPath.Skip(1).ToArray());

            return CreatePath(doc, node, rest);
        }

    }
}
