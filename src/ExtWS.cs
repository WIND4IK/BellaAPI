using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace DomainBellaNS.API {
    [DataContract]
    public enum DomainError {
        [EnumMember]
         DomainError = 1
    }
    namespace ExternalService {
        [DataContract]
        public class ActiveBundle {
            [DataMember]
             public int id { get; set; }
            [DataMember]
             public string name { get; set; }
            public ActiveBundle() { }
        }
        [DataContract]
        public class BundleWithPrice {
            [DataMember]
             public int bundleId { get; set; }
            [DataMember]
             public string name { get; set; }
            [DataMember]
             public DateTime startDate { get; set; }
            [DataMember]
             public DateTime endDate { get; set; }
            [DataMember]
             public double amount { get; set; }
            public BundleWithPrice() { }
        }
        [ServiceContract]
        public interface ExternalService {
            [OperationContract]
            [FaultContract(typeof(DomainFault))]
            ActiveBundle[] ExternalCall1(string url);
            [OperationContract]
            [FaultContract(typeof(DomainFault))]
            BundleWithPrice[] ExternalCall2(string url, int[] body);
        }
    }
    namespace InvoiceAPI {
        [DataContract]
        public class GenerateInvoiceRequest {
            [DataMember]
             public int serviceAccountId { get; set; }
            [DataMember]
             public DateTime startDate { get; set; }
            [DataMember]
             public DateTime endDate { get; set; }
            public GenerateInvoiceRequest() { }
        }
        [DataContract]
        public class Invoice {
            [DataMember]
             public int id { get; set; }
            [DataMember]
             public string name { get; set; }
            [DataMember]
             public DateTime startDate { get; set; }
            [DataMember]
             public DateTime endDate { get; set; }
            [DataMember]
             public double amount { get; set; }
            [DataMember]
             public InvoiceItem[] items { get; set; }
            public Invoice() { }
        }
        [DataContract]
        public class InvoiceItem {
            [DataMember]
             public int id { get; set; }
            [DataMember]
             public string name { get; set; }
            [DataMember]
             public DateTime startDate { get; set; }
            [DataMember]
             public DateTime endDate { get; set; }
            [DataMember]
             public double amount { get; set; }
            public InvoiceItem() { }
        }
        [ServiceContract]
        public interface InvoiceAPI {
            [OperationContract]
            [FaultContract(typeof(DomainFault))]
            Invoice Invoice(GenerateInvoiceRequest GenerateInvoiceRequest);
        }
    }
    [DataContract]
    public class DomainFault {
        [DataMember]
        public DomainError Code;
        [DataMember]
        public string Message;
    }

}