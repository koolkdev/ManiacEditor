using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using System.IO;


namespace RSDKv5
{
    public class Objects
    {
        static List<ObjectInfo> objects = new List<ObjectInfo>();
        static Dictionary<string, ObjectInfo> hashToObject = new Dictionary<string, ObjectInfo>();

        public static void InitObjects(Stream stream)
        {
            var parser = new IniParser.StreamIniDataParser();
            IniData data = parser.ReadData(new StreamReader(stream));
            foreach (var section in data.Sections)
            {
                List<AttributeInfo> attributes = new List<AttributeInfo>();
                foreach (var key in section.Keys)
                {
                    AttributeTypes type;
                    switch (key.Value)
                    {
                        case "UINT8":
                            type = AttributeTypes.UINT8;
                            break;
                        case "UINT16":
                            type = AttributeTypes.UINT16;
                            break;
                        case "UINT32":
                            type = AttributeTypes.UINT32;
                            break;
                        case "INT8":
                            type = AttributeTypes.INT8;
                            break;
                        case "INT16":
                            type = AttributeTypes.INT16;
                            break;
                        case "INT32":
                            type = AttributeTypes.INT32;
                            break;
                        case "VAR":
                            type = AttributeTypes.VAR;
                            break;
                        case "BOOL":
                            type = AttributeTypes.BOOL;
                            break;
                        case "STRING":
                            type = AttributeTypes.STRING;
                            break;
                        case "POSITION":
                            type = AttributeTypes.POSITION;
                            break;
                        case "COLOR":
                            type = AttributeTypes.COLOR;
                            break;
                        default:
                            // Unknown attribute
                            continue;
                    }

                    attributes.Add(new AttributeInfo(new NameIdentifier(key.KeyName), type));
                }
                objects.Add(new ObjectInfo(new NameIdentifier(section.SectionName), attributes));
            }
            hashToObject = objects.ToDictionary(x => x.Name.HashString());
        }

        public static ObjectInfo GetObjectInfo(NameIdentifier name)
        {
            ObjectInfo res = null;
            hashToObject.TryGetValue(name.HashString(), out res);
            return res;
        }
    }
}
