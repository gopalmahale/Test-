using System;
using Sennit.SharepointAutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SKP.Gama.BO
{

    [SharepointListName("ArchivedSupportings")]
    [IgnoreInCAMLRestriction]
    public class ArchivedSupportings : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Update")]
        public String RSN { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]        
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("CheckoutUser")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CheckedOutTo { get; set; }
    }

    [SharepointListName("ArchivedDocuments")]
    [IgnoreInCAMLRestriction]
    public class ArchivedDocuments : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
   
       // [IgnoreInOperation("Update")]
        
        public string RSN { get; set; }

        [SharepointFieldName("Priority")]
      //  [IgnoreInOperation("Update")]
       
        public string Priority { get; set; }
     
        [SharepointFieldName("Status")]
    //    [IgnoreInOperation("Update")]
        public string Status { get; set; }

        [SharepointFieldName("Approver1")]

     //   [IgnoreInOperation("Update")]
        public LookupFieldMapper Approver1 { get; set; }

        [SharepointFieldName("Approver2")]
        public LookupFieldMapper Approver2 { get; set; }

        [SharepointFieldName("Approver3")]
        public LookupFieldMapper Approver3 { get; set; }

        [SharepointFieldName("HApprover1")]
        public string HApprover1 { get; set; }

        [SharepointFieldName("HApprover2")]
        public string HApprover2 { get; set; }

        [SharepointFieldName("HApprover3")]
        public string HApprover3 { get; set; }

        [SharepointFieldName("HCApprover1")]
        public string HCApprover1 { get; set; }

        [SharepointFieldName("HCApprover2")]
        public string HCApprover2 { get; set; }

        [SharepointFieldName("HCApprover3")]
        public string HCApprover3 { get; set; }

        [SharepointFieldName("DocumentApprovalStatus")]
        public string DocumentApprovalStatus { get; set; }

        [SharepointFieldName("HIparcInvoiceId")]
        public string HIparcInvoiceId { get; set; }

        [SharepointFieldName("BatchName")]
        public string BatchName { get; set; }

        [SharepointFieldName("HIparcBatchId")]
        public string HIparcBatchId { get; set; }

        [SharepointFieldName("ModifiedString")]
        public string ModifiedString { get; set; }

        [SharepointFieldName("DocumentType")]
        public string DocumentType { get; set; }

        [SharepointFieldName("InvoiceNo")]
        public string InvoiceNo { get; set; }

        [SharepointFieldName("InvoiceDate")]
        public DateTime? InvoiceDate { get; set; }

        [SharepointFieldName("VendorName")]
        public LookupFieldMapper VendorName { get; set; }

        [SharepointFieldName("Company")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("ApprovedOn1")]
        public DateTime? ApprovedOn1 { get; set; }

        [SharepointFieldName("ApprovedOn2")]
        public DateTime? ApprovedOn2 { get; set; }

        [SharepointFieldName("ApprovedOn3")]
        public DateTime? ApprovedOn3 { get; set; }

        [SharepointFieldName("ApprovedBy1")]
        public LookupFieldMapper ApprovedBy1 { get; set; }

        [SharepointFieldName("ApprovedBy2")]
        public LookupFieldMapper ApprovedBy2 { get; set; }

        [SharepointFieldName("ApprovedBy3")]
        public LookupFieldMapper ApprovedBy3 { get; set; }

        [SharepointFieldName("Approver1Status")]
        public string Approver1Status { get; set; }

        [SharepointFieldName("Approver2Status")]
        public string Approver2Status { get; set; }

        [SharepointFieldName("Approver3Status")]
        public string Approver3Status { get; set; }

        [SharepointFieldName("Approver1Remark")]
        public string Approver1Remark { get; set; }

        [SharepointFieldName("Approver2Remark")]
        public string Approver2Remark { get; set; }

        [SharepointFieldName("Approver3Remark")]
        public string Approver3Remark { get; set; }

        [SharepointFieldName("FMApprovalStatus")]
        public string FMApprovalStatus { get; set; }

        [SharepointFieldName("FMApprovalRemark")]
        public string FMApprovalRemark { get; set; }

        [SharepointFieldName("FMApprovedOn")]
        public DateTime FMApprovedOn { get; set; }

        [SharepointFieldName("FMApprovedBy")]
        public LookupFieldMapper FMApprovedBy { get; set; }

        [SharepointFieldName("QueryRaisedOn")]
        public DateTime QueryRaisedOn { get; set; }

        [SharepointFieldName("QueryResolvedOn")]
        public DateTime QueryResolvedOn { get; set; }

        [SharepointFieldName("MessageInfo")]
        public string MessageInfo { get; set; }

        [SharepointFieldName("Created")]
       // [IgnoreInOperation("Insert")]
        //[IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Modified")]
      //  [IgnoreInOperation("Insert")]
      //  [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Author")]
      //  [IgnoreInOperation("Insert")]
      //  [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
      //  [IgnoreInOperation("Insert")]
      //  [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("CheckoutUser")]
      //  [IgnoreInOperation("Insert")]
      //  [IgnoreInOperation("Update")]
        public LookupFieldMapper CheckoutUser { get; set; }

        [SharepointFieldName("FileLeafRef")]
     //   [IgnoreInOperation("Insert")]
     //   [IgnoreInOperation("Update")]
        public string FileName { get; set; }

        [SharepointFieldName("FileRef")]
      //  [IgnoreInOperation("Insert")]
     //   [IgnoreInOperation("Update")]
        public string FileName1 { get; set; }

        [SharepointFieldName("ScannerRemark")]
        public string ScannerRemark { get; set; }

        [SharepointFieldName("FMApprover")]
        public List<LookupFieldMapper> FMApprover { get; set; }

        [SharepointFieldName("ReleasedDate")]
        public DateTime? ReleasedDate { get; set; }

        [SharepointFieldName("VendorID")]
        public int?  VendorID { get; set; }

       [SharepointFieldName("VendorName1")]
        public string VendorName1 { get; set; }

        [SharepointFieldName("QueryDetails")]
        public string QueryDetails { get; set; }

        [SharepointFieldName("UploadedBy")]
        public LookupFieldMapper UploadedBy { get; set; }

    }

    [SharepointListName("Company Master")]
    [IgnoreInCAMLRestriction]
    public class CompanyMaster : IEntitySharepointMapper
    {

        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public Int32? Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string CompanyCode { get; set; }

        [SharepointFieldName("CompanyName")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string CompanyName { get; set; }
        
        [SharepointFieldName("LastRSN")]
        public double LastRSN { get; set; }

        [SharepointFieldName("Region")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string Region { get; set; }

        [SharepointFieldName("RSNDigit")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string RSNDigit { get; set; }

        [SharepointFieldName("RSNPrefix")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string RSNPrefix { get; set; }

        [SharepointFieldName("RSNLength")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public double RSNLength { get; set; }

        [SharepointFieldName("TempCol")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string TempCol { get; set; }

        [SharepointFieldName("Cal_x0020__x002d__x0020_Last_x00")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string CalLastRSN { get; set; }

        [SharepointFieldName("Calc_x0020__x002d__x0020_RSN_x00")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string CalcRSNLength { get; set; }

        [SharepointFieldName("Calc_x0020__x002d__x0020_RSN_x000")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string CalcRSNPrefix { get; set; }
        
        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("FMApprover")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper FMApproverGroup { get; set; }

        [SharepointFieldName("GamaAccounts")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper GamaAccountsGroup { get; set; }

        [SharepointFieldName("Gama_x0020_Approver_x0020_Group")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper GamaApproverGroup { get; set; }

        [SharepointFieldName("Gama_x0020_OPS_x0020_Group")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper GamaOPSGroup { get; set; }

        [SharepointFieldName("ScannerGroup")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ScannerGroup { get; set; }

    }

    [SharepointListName("Document Master")]
    [IgnoreInCAMLRestriction]
    public class DocumentTypeMaster : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string DocumentType { get; set; }

        [SharepointFieldName("ShortName")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string ShortName { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }
    }

    [SharepointListName("UserCompanyMapping")]
    [IgnoreInCAMLRestriction]
    public class UserCompanyMapping : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        public int Id { get; set; }

        [SharepointFieldName("Company")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("User")]
        public LookupFieldMapper User { get; set; }
        
        [SharepointFieldName("IsActive")]
        public bool IsActive { get; set; }

        [SharepointFieldName("Title")]
        public string UserCompanyMap { get; set; }

        //[SharepointFieldName("Modified")]
        //public DateTime Modified { get; set; }

        //[SharepointFieldName("Created")]
        //public DateTime Created { get; set; }

        //[SharepointFieldName("Author")]
        //public LookupFieldMapper CreatedBy { get; set; }

        //[SharepointFieldName("Editor")]
        //public LookupFieldMapper ModifiedBy { get; set; }
    }

    [SharepointListName("Vendor Master")]
    [IgnoreInCAMLRestriction]
    public class VendorMaster : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string VendorName { get; set; }

        [SharepointFieldName("VendorCode")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public String VendorCode { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("DocumentType")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper DocumentType { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }
    }

    [SharepointListName("Query Type Master")]
    [IgnoreInCAMLRestriction]
    public class QueryTypeMaster : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string QueryType { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }

    }

    [SharepointListName("Aircraft")]
    [IgnoreInCAMLRestriction]
    public class Aircraft : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string AircraftName { get; set; }

        [SharepointFieldName("Analyst")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public List<LookupFieldMapper> Analyst { get; set; }

        [SharepointFieldName("IsActive")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public bool IsActive { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper ModifiedBy { get; set; }
    }

    [SharepointListName("Invoice")]
    public class Invoice : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        public string RSN { get; set; }

        [SharepointFieldName("HUniqueRSN")]
        [IgnoreInOperation("Update")]
        public string HUniqueRSN { get; set; }

        [SharepointFieldName("HIntRSN")]
        [IgnoreInOperation("Update")]
        public double HIntRSN { get; set; }

        [SharepointFieldName("Priority")]
        public string Priority { get; set; }

        [SharepointFieldName("Status")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public string Status { get; set; }

        [SharepointFieldName("Approver1")]        
        public LookupFieldMapper Approver1 { get; set; }

        [SharepointFieldName("Approver2")]        
        public LookupFieldMapper Approver2 { get; set; }

        [SharepointFieldName("Approver3")]
        public LookupFieldMapper Approver3 { get; set; }

        [SharepointFieldName("HApprover1")]
        public string HApprover1 { get; set; }

        [SharepointFieldName("HApprover2")]
        public string HApprover2 { get; set; }

        [SharepointFieldName("HApprover3")]
        public string HApprover3 { get; set; }

        [SharepointFieldName("HCApprover1")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public string HCApprover1 { get; set; }

        [SharepointFieldName("HCApprover2")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public string HCApprover2 { get; set; }

        [SharepointFieldName("HCApprover3")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public string HCApprover3 { get; set; }

        [SharepointFieldName("DocumentApprovalStatus")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public string DocumentApprovalStatus { get; set; }

        [SharepointFieldName("HIparcInvoiceId")]
        [IgnoreInOperation("Insert")]
        public string HIparcInvoiceId { get; set; }

        [SharepointFieldName("BatchName")]
        [IgnoreInOperation("Insert")]
        public string BatchName { get; set; }

        [SharepointFieldName("HIparcBatchId")]
        [IgnoreInOperation("Insert")]
        public string HIparcBatchId { get; set; }

        [SharepointFieldName("ModifiedString")]
        public string ModifiedString { get; set; }

        [SharepointFieldName("Document_Type")]
        [IgnoreInOperation("Update")]        
        public LookupFieldMapper DocumentType { get; set; }

        [SharepointFieldName("HDocumentType")]
        [IgnoreInOperation("Update")]
        public string HDocumentType { get; set; }

        [SharepointFieldName("InvoiceNo")]
        public string InvoiceNo { get; set; }

        
        //public DateTime? InvoiceDate { get; set; }
        private DateTime? _InvoiceDate;

        [SharepointFieldName("InvoiceDate")]
        public DateTime? InvoiceDate
        {
            get {
                //if(_InvoiceDate != null)
                //    return System.TimeZone.CurrentTimeZone.ToLocalTime((DateTime)_InvoiceDate);
                return _InvoiceDate;
            }
            set {
                //if (value != null)
                //    _InvoiceDate = System.TimeZone.CurrentTimeZone.ToUniversalTime((DateTime)value);
                //else
                _InvoiceDate = value;
            }
        }


        [SharepointFieldName("VendorName")]
        public LookupFieldMapper VendorName { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("ScannerRemark")]
        public string ScannerRemark { get; set; }

        [SharepointFieldName("ApprovedOn1")]
        [IgnoreInOperation("Insert")]
        public DateTime? ApprovedOn1 { get; set; }

        [SharepointFieldName("ApprovedOn2")]
        [IgnoreInOperation("Insert")]
        public DateTime? ApprovedOn2 { get; set; }

        [SharepointFieldName("ApprovedOn3")]
        [IgnoreInOperation("Insert")]
        public DateTime? ApprovedOn3 { get; set; }

        [SharepointFieldName("ApprovedBy1")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper ApprovedBy1 { get; set; }

        [SharepointFieldName("ApprovedBy2")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper ApprovedBy2 { get; set; }

        [SharepointFieldName("ApprovedBy3")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Select")]
        public LookupFieldMapper ApprovedBy3 { get; set; }

        [SharepointFieldName("Approver1Status")]
        [IgnoreInOperation("Insert")]
        public string Approver1Status { get; set; }

        [SharepointFieldName("Approver2Status")]
        [IgnoreInOperation("Insert")]
        public string Approver2Status { get; set; }

        [SharepointFieldName("Approver3Status")]
        [IgnoreInOperation("Insert")]
        public string Approver3Status { get; set; }

        [SharepointFieldName("Approver1Remark")]
        [IgnoreInOperation("Insert")]
        public string Approver1Remark { get; set; }

        [SharepointFieldName("Approver2Remark")]
        [IgnoreInOperation("Insert")]
        public string Approver2Remark { get; set; }

        [SharepointFieldName("Approver3Remark")]
        [IgnoreInOperation("Insert")]
        public string Approver3Remark { get; set; }

        [SharepointFieldName("FMApprovalStatus")]
        [IgnoreInOperation("Insert")]
        public string FMApprovalStatus { get; set; }

        [SharepointFieldName("FMApprovalRemark")]
        [IgnoreInOperation("Insert")]
        public string FMApprovalRemark { get; set; }

        [SharepointFieldName("FMApprovedOn")]
        [IgnoreInOperation("Insert")]
        public DateTime FMApprovedOn { get; set; }

        [SharepointFieldName("FMApprovedBy")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper FMApprovedBy { get; set; }

        [SharepointFieldName("QueryRaisedOn")]
        [IgnoreInOperation("Insert")]
        public DateTime QueryRaisedOn { get; set; }

        [SharepointFieldName("QueryResolvedOn")]
        [IgnoreInOperation("Insert")]
        public DateTime QueryResolvedOn { get; set; }

        [SharepointFieldName("MessageInfo")]
        public string MessageInfo { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Select")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("CheckoutUser")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Select")]
        public LookupFieldMapper CheckoutUser { get; set; }

        [SharepointFieldName("FileLeafRef")]
        [IgnoreInOperation("Update")]
        public string FileName { get; set; }

        [SharepointFieldName("FileRef")]
        [IgnoreInOperation("Update")]
        public string FileName1 { get; set; }

        [SharepointFieldName("FMApprover")]
        [IgnoreInOperation("Select")]
        public List<LookupFieldMapper> FMApprover { get; set; }

        [SharepointFieldName("ReleasedDate")]
        [IgnoreInOperation("Insert")]
        public DateTime ReleasedDate { get; set; }

        [SharepointFieldName("Document")]
        [IgnoreInOperation("Update")]
        public string DocumentLink { get; set; }

        [SharepointFieldName("UploadedBy")]
        public LookupFieldMapper UploadedBy { get; set; }

        #region Aging and Aging Support Fields


        [SharepointFieldName("HFirstQueryRaisedOn")]
        [IgnoreInOperation("Insert")]
        public DateTime HFirstQueryRaisedOn { get; set; }

        [SharepointFieldName("LastApprovedOn")]
        [IgnoreInOperation("Insert")]
        public string LastApprovedOn { get; set; }



        [SharepointFieldName("PendingforApproval")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public double PendingforApprovalAging { get; set; }
        
        [SharepointFieldName("PendingwithSKP")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public double PendingwithSKPAging { get; set; }

        [SharepointFieldName("PendingwithSKPAfterQuery")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public double PendingwithSKPAfterQueryAging { get; set; }

        [SharepointFieldName("PendingwithSKPBeforeQuery")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public double PendingwithSKPBeforeQueryAging { get; set; }


        [IgnorePropertyInSharepoint]
        private int _PendingWithGamaAging;
        public int PendingWithGamaAging
        {
            get
            {

                int Ageing = 0;
                if (HFirstQueryRaisedOn != null)
                {
                    if (QueryResolvedOn == null)
                        Ageing = (int)Math.Round(((TimeSpan)(DateTime.Now - HFirstQueryRaisedOn)).TotalDays);
                    else
                        Ageing = (int)Math.Round(((TimeSpan)(QueryResolvedOn - HFirstQueryRaisedOn)).TotalDays);
                }
                else
                    Ageing = 0;

                return Ageing;
            }
            set { _PendingWithGamaAging = value; }
        }

        [IgnorePropertyInSharepoint]
        private int _TotalApprovalAging;
        public int TotalApprovalAging
        {
            get
            {

                int Ageing = 0;
                if (Status == "Pending for Approval" || Status == "Pending with FM" || Status == "Pending for Approval Rectification")
                    Ageing = (int)Math.Round(((TimeSpan)(DateTime.Now - Created)).TotalDays);
                else
                {
                    DateTime d;
                    if (DateTime.TryParse(LastApprovedOn, out d))
                        Ageing = (int)Math.Round(((TimeSpan)(d - Created)).TotalDays);
                    else
                        Ageing = 0;
                }

                return Ageing;
            }
            set { _TotalApprovalAging = value; }
        }

        #endregion


        #region Custom Columns Generated

        private Enums.InvoiceStatus _iStatus;

        /// <summary>
        /// Enum converted status of the invoice
        /// </summary>
        [IgnorePropertyInSharepoint]
        public Enums.InvoiceStatus iStatus
        {
            get
            {
                if (Status != null)
                {
                    if (Status.ToLower() == ("Pending for Approval").ToLower())
                        return Enums.InvoiceStatus.Pending_For_Approval;
                    if (Status.ToLower() == ("Pending with FM").ToLower())
                        return Enums.InvoiceStatus.Pending_With_FM_For_Approval;
                    if (Status.ToLower() == ("Pending for Approval Rectification").ToLower())
                        return Enums.InvoiceStatus.Pending_For_Approver_Rectification;
                    if (Status.ToLower() == ("Discard").ToLower())
                        return Enums.InvoiceStatus.Discard;
                    if (Status.ToLower() == ("Pending For Gama Overhead Processing").ToLower())
                        return Enums.InvoiceStatus.Pending_For_Gama_Overhead_Processing;
                    if (Status.ToLower() == ("Released").ToLower())
                        return Enums.InvoiceStatus.Released;
                    if (Status.ToLower() == ("In Query").ToLower())
                        return Enums.InvoiceStatus.InQuery;
                    if (Status.ToLower() == ("Pending with SKP").ToLower())
                        return Enums.InvoiceStatus.Pending_With_SKP;
                    return Enums.InvoiceStatus.Not_Initiated;
                }
                else
                    return Enums.InvoiceStatus.Not_Initiated;
            }
        }


        private Enums.InvoiceApprovalStatus _iApprover1Status;

        [IgnorePropertyInSharepoint]
        public Enums.InvoiceApprovalStatus iApprover1Status
        {
            get
            {
                if(Approver1Status != null)
                { 
                    if (Approver1Status.ToLower() == ("Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.Approved;
                    if (Approver1Status.ToLower() == ("Not Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.NotApproved;
                    if (Approver1Status.ToLower() == ("Send Back to Scanner").ToLower())
                        return Enums.InvoiceApprovalStatus.SendBackToScanner;
                    else
                        return Enums.InvoiceApprovalStatus.NoStatus;
                }
                else
                    return Enums.InvoiceApprovalStatus.NoStatus;
            }
        }


        private Enums.InvoiceApprovalStatus _iApprover2Status;

        [IgnorePropertyInSharepoint]
        public Enums.InvoiceApprovalStatus iApprover2Status
        {
            get
            {
                if (Approver2Status != null)
                {
                    if (Approver2Status.ToLower() == ("Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.Approved;
                    if (Approver2Status.ToLower() == ("Not Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.NotApproved;
                    if (Approver2Status.ToLower() == ("Send Back to Scanner").ToLower())
                        return Enums.InvoiceApprovalStatus.SendBackToScanner;
                    else
                        return Enums.InvoiceApprovalStatus.NoStatus;
                }
                else
                    return Enums.InvoiceApprovalStatus.NoStatus;
            }
        }


        private Enums.InvoiceApprovalStatus _iApprover3Status;

        [IgnorePropertyInSharepoint]
        public Enums.InvoiceApprovalStatus iApprover3Status
        {
            get
            {
                if (Approver3Status != null)
                {
                    if (Approver3Status.ToLower() == ("Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.Approved;
                    if (Approver3Status.ToLower() == ("Not Approved").ToLower())
                        return Enums.InvoiceApprovalStatus.NotApproved;
                    if (Approver3Status.ToLower() == ("Send Back to Scanner").ToLower())
                        return Enums.InvoiceApprovalStatus.SendBackToScanner;
                    else
                        return Enums.InvoiceApprovalStatus.NoStatus;
                }
                else
                    return Enums.InvoiceApprovalStatus.NoStatus;
            }
        }


        private Enums.InvoiceApprovalStatus _iFMApprovalStatus;

        [IgnorePropertyInSharepoint]
        public Enums.InvoiceFMApprovalStatus iFMApprovalStatus
        {
            get
            {
                if (FMApprovalStatus != null)
                {
                    if (FMApprovalStatus.ToLower() == ("Approved").ToLower())
                        return Enums.InvoiceFMApprovalStatus.Approved;
                    if (FMApprovalStatus.ToLower() == ("Discard").ToLower())
                        return Enums.InvoiceFMApprovalStatus.Discard;
                    return Enums.InvoiceFMApprovalStatus.NoStatus;
                }
                else
                    return Enums.InvoiceFMApprovalStatus.NoStatus;
            }
        }



        /// <summary>
        /// Running status of the invoice upload process
        /// </summary>
        [IgnorePropertyInSharepoint]
        public string RunningStatus { get; set; }

        /// <summary>
        /// Uniqueue datatime id for reference in uplaod process
        /// </summary>
        [IgnorePropertyInSharepoint]
        public string UniqueID { get; set; }

        /// <summary>
        /// Upload document path will be holded here
        /// </summary>
        [IgnorePropertyInSharepoint]
        public string AttachmentFilePath { get; set; }

        /// <summary>
        /// RSN number id which will be used while uploading invoice
        /// </summary>
        [IgnorePropertyInSharepoint]
        public int RSNID { get; set; }

        /// <summary>
        /// Current login user role on invoice will be defined in this
        /// </summary>
        [IgnorePropertyInSharepoint]
        public List<Enums.DocumentUserRoles> DocUserRole { get; set; }

        /// <summary>
        /// Invoice operation will be stored here. 
        /// Invoice field Visibility and Enability will be maintaned on the basis of this.
        /// </summary>
        [IgnorePropertyInSharepoint]
        public Enums.InvoiceOperations InvoiceOperation { get; set; }


        /// <summary>
        /// Selected state of the inovice for Invoice Ribbon
        /// </summary>
        [IgnorePropertyInSharepoint]
        public bool IsSelected { get; set; }
        

        #endregion

    }

    [SharepointFieldName("Query")]
    [IgnoreInCAMLRestriction]
    public class Query : IEntitySharepointMapper
    {

        [SharepointFieldName("ID")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Update")]
        public string RSN { get; set; }

        [SharepointFieldName("QueryType")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper QueryType { get; set; }

        [SharepointFieldName("Description")]
        [IgnoreInOperation("Update")]
        public string Description { get; set; }

        [SharepointFieldName("Resolution")]        
        public string Resolution { get; set; }

        [SharepointFieldName("PreviousAnswer")]
        public string PreviousAnswer { get; set; }

        [SharepointFieldName("Aircraft")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Aircraft { get; set; }

        [SharepointFieldName("Status")]
        [IgnoreInOperation("Update")]
        public string Status { get; set; }

        [SharepointFieldName("DoyouwanttoassigntoOPSteam_x003f")]
        public string DoYouWantToAssignToOPSTeam { get; set; }

        [SharepointFieldName("OPSAssignedTo")]
        public LookupFieldMapper OPSAssignedTo { get; set; }

        [SharepointFieldName("OPSAssignedOn")]
        public DateTime OPSAssignedOn { get; set; }

        [SharepointFieldName("ReviewedOn")]
        public DateTime? ReviewedOn { get; set; }

        [SharepointFieldName("ReviewComment")]
        [IgnoreInOperation("Insert")]
        public string ReviewComment { get; set; }

        [SharepointFieldName("DoyouwanttosendtoSKP_x003f_")]
        public string DoYouWantToSendToSKP { get; set; }

        [SharepointFieldName("HIparcQueryId")]
        [IgnoreInOperation("Update")]
        public string HIparcQueryId { get; set; }

        [SharepointFieldName("AircraftAnalyst")]
        [IgnoreInOperation("Update")]
        public List<LookupFieldMapper> AircraftAnalyst { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("AnsweredBy")]
        public LookupFieldMapper AnsweredBy { get; set; }

        [SharepointFieldName("VendorName")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper VendorName { get; set; }
                
        [SharepointFieldName("AnsweredOn")]
        public DateTime? AnsweredOn { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("Gama_x0020_Accounts")]        
        public List<LookupFieldMapper> GamaAccounts { get; set; }

        [SharepointFieldName("InvoiceId")]
        public string InvoiceId { get; set; }

        [SharepointFieldName("HAircraft")]
        public string HAircraft { get; set; }

        [SharepointFieldName("RaisedOn")]
        public DateTime? RaisedOn { get; set; }

        [SharepointFieldName("Currency")]
        public string Currency { get; set; }
        
        //[SharepointFieldName("QueryAgeing")]
        //public double QueryAgeing { get; set; }

        private double _QueryAgeing;
        public double QueryAgeing
        {
            get {

                double Ageing = 0;
                
                if (AnsweredOn == null)
                    Ageing = Math.Round(((TimeSpan)(DateTime.Now - RaisedOn)).TotalDays);
                else
                    Ageing = Math.Round(((TimeSpan)(AnsweredOn - RaisedOn)).TotalDays);
                
                return Ageing;
            }
            set { _QueryAgeing = value; }
        }


        [SharepointFieldName("DocumentType")]
        public string DocumentType { get; set; }

        [SharepointFieldName("BatchName")]
        public string BatchName { get; set; }

        #region Custom Columns Created

        private Enums.QueryStatus _iStatus;

        [IgnorePropertyInSharepoint]
        public Enums.QueryStatus iStatus
        {
            get
            {
                if (Status.ToLower() == ("Resolved").ToLower())
                    return Enums.QueryStatus.Resolved;
                if (Status.ToLower() == ("Pending with Gama Accounts for Resolution").ToLower())
                    return Enums.QueryStatus.Pending_With_GamaAccounts_For_Resolution;
                if (Status.ToLower() == ("Pending with Aircraft Analyst").ToLower())
                    return Enums.QueryStatus.Pending_With_Aircraft_Analyst;
                if (Status.ToLower() == ("Pending with OPS for Resolution").ToLower())
                    return Enums.QueryStatus.Pending_With_OPS_For_Resolution;
                if (Status.ToLower() == ("Pending with OPS for Resolution rectification").ToLower())
                    return Enums.QueryStatus.Pending_With_OPS_For_Resolution_Rectification;
                if (Status.ToLower() == ("Pending with Aircraft Analyst for Review").ToLower())
                    return Enums.QueryStatus.Pending_With_Aircraft_Analyst_For_Review;

                return Enums.QueryStatus.Undefined;
            }
        }


        #endregion

    }

    [SharepointListName("Supportings")]
    [IgnoreInCAMLRestriction]
    public class Supporting : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        [IgnoreInOperation("Update")]
        public String RSN { get; set; }

        [SharepointFieldName("Company")]
        [IgnoreInOperation("Update")]
        public LookupFieldMapper Company { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper ModifiedBy { get; set; }

        [SharepointFieldName("CheckoutUser")]
        [IgnoreInOperation("Update")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper CheckedOutTo { get; set; }

        [SharepointFieldName("FileRef")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public String FileRef { get; set; }

        [SharepointFieldName("FileLeafRef")]
        [IgnoreInOperation("Insert")]
        [IgnoreInOperation("Update")]
        public string FileName { get; set; }
        
        [SharepointFieldName("isDownloaded")]
        public bool isDownloaded { get; set; }

        [SharepointFieldName("InvoiceId")]
        [IgnoreInOperation("Update")]
        public int InvoiceId { get; set; }


    }

    [SharepointListName("GUI Settings")]
    [IgnoreInCAMLRestriction]
    public class GUISettings : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        public String Setting { get; set; }

        [SharepointFieldName("Value")]
        public String Value { get; set; }
        
        [SharepointFieldName("Modified")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        public LookupFieldMapper ModifiedBy { get; set; }
                
    }

    [SharepointListName("EmailService")]
    [IgnoreInCAMLRestriction]
    public class EmailService : IEntitySharepointMapper
    {
        [SharepointFieldName("ID")]
        [IgnoreInOperation("Insert")]
        public int Id { get; set; }

        [SharepointFieldName("Title")]
        public String To { get; set; }

        [SharepointFieldName("CC")]
        public String CC { get; set; }

        [SharepointFieldName("Subject")]
        public String Subject { get; set; }

        [SharepointFieldName("EmailBody")]
        public String EmailBody { get; set; }

        [SharepointFieldName("Status")]
        public String Status { get; set; }

        [SharepointFieldName("Modified")]
        [IgnoreInOperation("Insert")]
        public DateTime Modified { get; set; }

        [SharepointFieldName("Created")]
        [IgnoreInOperation("Insert")]
        public DateTime Created { get; set; }

        [SharepointFieldName("Author")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper CreatedBy { get; set; }

        [SharepointFieldName("Editor")]
        [IgnoreInOperation("Insert")]
        public LookupFieldMapper ModifiedBy { get; set; }

    }

    /// <summary>
    /// Class to hold SharePoint user
    /// </summary>
    [SharepointListName("Gama Approver")]
    [IgnoreInCAMLRestriction]
    public class SPUser
    {
        public int UserID { get; set; }

        public string UserAccount { get; set; }

        public string Title { get; set; }
    }

    /// <summary>
    /// Class to hold SharePoint group
    /// </summary>
    
    public class SPGroup
    {
        public int GroupID { get; set; }

        public string Title { get; set; }
        
    }

}
