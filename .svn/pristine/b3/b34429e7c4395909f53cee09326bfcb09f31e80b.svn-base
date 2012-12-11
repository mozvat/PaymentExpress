using System.Collections.Generic;

namespace PayPal
{
    public class Response
    {
        Dictionary<string, string> _fieldValueCollection;
        string _ack;
        string _optionalTimeStamp;
        string _optionalCorrelationID;    
        string _optionalVersion;
        string _optionalBuild;
        string _optionalShortMessage;
        string _optionalLongMessage;
        string _optionalSeverityCode;

        public Dictionary<string, string> FieldValueCollection
        {
          get { return _fieldValueCollection; }  
        }
        public string ACK
        {
            get { return _ack; }
        }
        public string OptionalTimeStamp
        {
            get { return _optionalTimeStamp; }
        }
        public string OptionalCorrelationID
        {
            get { return _optionalCorrelationID; }
        }
        public string OptionalVersion
        {
            get { return _optionalVersion; }
        }
        public string OptionalBuild
        {
            get { return _optionalBuild; }
        }
        public string OptionalShortMessage
        {
            get { return _optionalShortMessage; }
        }
        public string OptionalLongMessage
        {
            get { return _optionalLongMessage; }
        }
        public string OptionalSeverityCode
        {
            get { return _optionalSeverityCode; }
        }

        public Response(Dictionary<string, string> fieldValueCollection)
        {
            _fieldValueCollection = fieldValueCollection;
            this.parseFieldValueCollection(_fieldValueCollection);
        }

        private void parseFieldValueCollection(Dictionary<string, string> collection)
        {
            if (collection.ContainsKey("ACK")) _ack = collection["ACK"];
            if (collection.ContainsKey("TIMESTAMP")) _optionalTimeStamp = collection["TIMESTAMP"];
            if (collection.ContainsKey("CORRELATIONID")) _optionalCorrelationID = collection["CORRELATIONID"];
            if (collection.ContainsKey("VERSION")) _optionalVersion = collection["VERSION"];
            if (collection.ContainsKey("BUILD")) _optionalBuild = collection["BUILD"];
            if (collection.ContainsKey("L_SHORTMESSAGE0")) _optionalShortMessage = collection["L_SHORTMESSAGE0"];
            if (collection.ContainsKey("L_LONGMESSAGE0")) _optionalLongMessage = collection["L_LONGMESSAGE0"];
            if (collection.ContainsKey("L_SEVERITYCODE0=")) _optionalSeverityCode = collection["L_SEVERITYCODE0="];
        }

    }
}
