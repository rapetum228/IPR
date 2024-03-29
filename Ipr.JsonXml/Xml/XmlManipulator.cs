using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ipr.JsonXml.Xml
{
    public static class XmlManipulator
    {
        private static string _pathToCars = "C:\\Users\\User\\source\\iprs\\IPR\\Ipr.JsonXml\\Xml\\FIles\\Cars.xml";
        public static void WriteToConsoleXml()
        {
            XmlDocument xDoc = new XmlDocument(); //представляет весь xml-документ

            xDoc.Load(_pathToCars);
            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                //XmlElement - представляет отдельный элемент. Наследуется от класса XmlNode
                foreach (XmlElement xnode in xRoot)
                {
                    //представляет узел xml. В качестве узла может использоваться весь документ, так и отдельный элемент
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");

                    Console.WriteLine(attr?.Value);

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        Console.WriteLine($"{childnode.Name}: {childnode.InnerText}");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static async Task ReadXmlToConsoleUsingStreamApiAsync()
        {

            using (StreamReader fs = new StreamReader(_pathToCars, Encoding.Unicode))
            {
                XmlReader xmlReader = XmlReader.Create(fs, new XmlReaderSettings
                {
                    Async = true
                });
                while (xmlReader.Read())
                {
                    if (xmlReader.HasAttributes)
                    {
                        var attrCounts = xmlReader.AttributeCount;
                        for (var attr = 0; attr < attrCounts; attr++)
                        {
                            Console.WriteLine(xmlReader.GetAttribute(attr));
                        }
                    }
                    if (!xmlReader.IsEmptyElement)
                    {
                        var value = await xmlReader.GetValueAsync();
                        if (!String.IsNullOrWhiteSpace(value) && !value.Contains("\n") && !value.Contains("\t"))
                            await Console.Out.WriteLineAsync(xmlReader.Name + value);
                    }
                }
            }
        }

        public static XmlNode? FindNodeByName(XmlNode? xRoot, string nodeName, string? valueText = null)
        {
            //перебор узлов документа (cars)
            foreach (XmlElement xnode in xRoot!)
            {
                //поиск по атрибутам каждой car
                foreach (XmlAttribute attr in xnode.Attributes)
                {
                    if (attr.Name == nodeName)
                    {
                        if (valueText != null)
                        {
                            if (valueText == attr.Value)
                                return xnode;
                        }
                        else
                            return xnode;
                    }
                }

                //поиск по первым дочерним узлам каждой car
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == nodeName)
                    {
                        if (valueText != null)
                        {
                            if (valueText == childnode.InnerText)
                                return xnode;
                        }
                        else
                            return xnode;
                    }
                }
            }

            return null;
        }

        public static void AppendOwnerToCar(Person person, string carName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_pathToCars);
            XmlElement? xRoot = xDoc.DocumentElement;

            var nodeWithCarName = FindNodeByName(xRoot, "name", carName);

            if (nodeWithCarName == null)
                return;

            XmlElement personElem = xDoc.CreateElement("person");

            XmlNode? owners = default;

            foreach (XmlNode childnode in nodeWithCarName.ChildNodes)
            {
                if (childnode.Name == "owners")
                {
                    owners = childnode;
                    break;
                }
            }

            if (owners == default)
                owners = xDoc.CreateElement("owners");

            // создаем элементы company и age
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlElement ageElem = xDoc.CreateElement("age");

            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode(person.Name);
            XmlText ageText = xDoc.CreateTextNode(person.Age.ToString());

            //добавляем узлы
            nameElem.AppendChild(nameText);
            ageElem.AppendChild(ageText);

            // добавляем элементы company и age
            personElem.AppendChild(nameElem);
            personElem.AppendChild(ageElem);
            // добавляем в корневой элемент новый элемент person
            owners?.AppendChild(personElem);
            nodeWithCarName?.AppendChild(owners);
            // сохраняем изменения xml-документа в файл
            xDoc.Save(_pathToCars);
        }

        public static void RemoveOwnerFromCar(string personName, string carName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_pathToCars);
            XmlElement? xRoot = xDoc.DocumentElement;

            var nodeWithCarName = FindNodeByName(xRoot, "name", carName);

            if (nodeWithCarName == null) return;

            XmlNode? ownersNode = default;

            foreach (XmlNode childnode in nodeWithCarName.ChildNodes)
            {
                if (childnode.Name == "owners")
                {
                    ownersNode = childnode;
                    break;
                }
            }

            if (ownersNode == null) return;

            var personNode = FindNodeByName(ownersNode, "name", personName);

            if (personNode == null) return;

            ownersNode.RemoveChild(personNode);

            if (ownersNode.ChildNodes.Count == 0)
            {
                nodeWithCarName.RemoveChild(ownersNode);
            }

            xDoc.Save(_pathToCars);
        }

        public static IEnumerable<Person>? GetCarOwners(string carName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_pathToCars);
            XmlElement? xRoot = xDoc.DocumentElement;

            var nodes = xRoot?.SelectNodes($"car[name='{carName}']/owners/person");
            if (nodes == null || nodes.Count == 0)
                nodes = xRoot?.SelectNodes($"car[@name='{carName}']/owners/person");

            if (nodes == null || nodes.Count == 0)
                return null;

            var owners = new List<Person>(nodes.Count);

            foreach (XmlNode node in nodes)
            {
                var name = node.SelectSingleNode("name")?.InnerText;
                var age = Convert.ToInt32(node.SelectSingleNode("age")?.InnerText);

                owners.Add(new Person
                {
                    Name = name!,
                    Age = age
                });
            }

            return owners;
        }
    }
}
