using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Exstentions
{
    public static class XDocumentExtensions
    {
        public static string GetValueFromDocument(this XDocument document, string elementName)
        {
            var errorMessage = $"The document has no element with name='{elementName}'";
            var root = document.Root;
            return GetValue(root, elementName, errorMessage);
        }

        private static string GetValue(XElement parent, string childName, string errorMessage)
        {
            if (parent == null)
                throw new Exception(errorMessage);

            var element = parent.Element(XName.Get(childName, parent.Name.NamespaceName));

            if (element == null)
                throw new Exception(errorMessage);

            return element.Value;
        }

        public static string GetValue(this XElement containingElement, string childName)
        {
            var errorMessage = $"Element '{containingElement.Name}' does not have a child element '{childName}'";

            return GetValue(containingElement, childName, errorMessage);
        }
    }
}
