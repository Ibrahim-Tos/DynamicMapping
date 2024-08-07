using Newtonsoft.Json;
using System.Xml.Serialization;

namespace DynamicMapping.Core
{
    public class ParserEngine : IParserEngine
    {
        public ParserEngine()
        {
        }

        public IMappingEngine ResolveMappingEngineByModel(MappingModelBase model, IEnumerable<IMappingEngine> mappingEngines)
        {
            var result = mappingEngines.FirstOrDefault(mappingEngine => string.Equals(mappingEngine.Name, model.OrganizationName, StringComparison.OrdinalIgnoreCase));

            return result ?? throw new ArgumentException($"No Mapping Engine for organization '{model.OrganizationName}' could be found");
        }

        public IMappingEngine ResolveMappingEngineByCustomerObject(string customerObject, IEnumerable<IMappingEngine> mappingEngines)
        {
            var isJson = IsJson(customerObject);

            // Imagine we have only 2 types (json and xml) for now
            ModelBaseCustomer modelBaseCustomer = isJson ?
                ParseModelBaseCustomerFromJson(customerObject) :
                ParseModelBaseCustomerFromXml(customerObject);

            var result = mappingEngines.FirstOrDefault(mappingEngine => string.Equals(mappingEngine.Name, modelBaseCustomer.Name, StringComparison.OrdinalIgnoreCase));

            return result ?? throw new ArgumentException($"No Mapping Engine for organization '{modelBaseCustomer.Name}' could be found");
        }

        private bool IsJson(string customerObject)
        {
            customerObject = customerObject.Trim();

            return customerObject.StartsWith("{") && customerObject.EndsWith("}")
                   || customerObject.StartsWith("[") && customerObject.EndsWith("]");
        }

        private ModelBaseCustomer ParseModelBaseCustomerFromJson(string jsonString)
        {
            var result = JsonConvert.DeserializeObject<ModelBaseCustomer>(jsonString);

            return result;
        }

        private ModelBaseCustomer ParseModelBaseCustomerFromXml(string xmlString)
        {
            ModelBaseCustomer result = new ModelBaseCustomer();

            try
            {
                using (TextReader reader = new StringReader(xmlString))
                {
                    try
                    {
                        result = (ModelBaseCustomer)new XmlSerializer(typeof(ModelBaseCustomer)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
            }


            return result;
        }
    }
}
