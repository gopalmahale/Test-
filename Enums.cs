using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.Gama.BO
{
    public class Enums
    {
        public enum NewItemStatus
        {
            CreatedSucsesfully =0,
            FailedInItemCreation,
            FailedInUploadAttachment,
            DuplicateRSN,
            TimeoutExpire
        };

        public enum DocumentApprovalStatus
        {
            NoApprovalRequired =0,
            ApprovedByFM ,
            DiscardByFM,
            PendingwithScannerForrectification,
            PendingForApproval1,
            PendingForApproval2,
            PendingForApproval3,
            ApporvedwithoutFM
        };
        

        public enum QueryStatus
        {
            Pending_With_GamaAccounts_For_Resolution=0,
            Pending_With_Aircraft_Analyst,
            Pending_With_OPS_For_Resolution,
            Pending_With_OPS_For_Resolution_Rectification,
            Pending_With_Aircraft_Analyst_For_Review,
            Resolved,
            Undefined
        };


        // Status to provide dynamic control status to processing window
        public enum DynamicDocumentStatus
        {
            Downloaded = 0,
            FailedToDownload,
            Scanned,
            LoadedFromDrive,
            NoFileLoaded,
            Busy
        };

                
        public enum AppUserRoles
        {
            GamaScanner=0,
            GamaUser,
            GamaAdmin,
            SKPUser
        };


        public enum AppDialogTypes
        {
            Information = 0,
            Warnning,
            Error,
            Confirmation
        };


        #region Invoice Enums

        public enum InvoiceStatus
        {
            Not_Initiated = 0,
            Pending_For_Approval,
            Pending_With_FM_For_Approval,
            Pending_For_Approver_Rectification,
            Discard,
            Pending_For_Gama_Overhead_Processing,
            Released,
            InQuery,
            Pending_With_SKP
        };

        public enum DocumentUserRoles
        {
            Scanner = 0,
            Approver,
            FMApprover,
            GamaAccount,
            AircraftAnalyst,
            OPSUser,
            GamaAdmin,
            SKPUser,
            Other
        };

        public enum InvoiceOperations
        {
            Approval_Status = 0,
            Approver_Rectification,
            Release,
            FM_Approval_Status,
            Gama_Account_Query_Resolution,
            Analyst_Query_Resolution_or_Assign_to_OPS,
            OPS_Query_Resolution,
            OPS_Query_Resolution_Rectification,
            Analyst_Resolution_Review,
            Pending_For_Gama_Overhead_Processing,
            Pending_With_SKP,
            New_Document_Creation,
            ReadOnly,
            InQuery
        };

        public enum InvoiceApprovalStatus
        {
            NoStatus=0,
            Approved,
            NotApproved,
            SendBackToScanner
        };

        public enum InvoiceFMApprovalStatus
        {
            NoStatus = 0,
            Approved,
            Discard
        };

        #endregion


        #region Enum Declaration for i-Parc

        public enum BatchCreationType
        {
            Priority = 0,
            FuealSuplier,
            Monthly,
            Reguler
        };

        public enum InvoicePriority
        {
            Normal = 0,
            PriorityChangedAfterApproval,
            PriorityBacthCreatedAfterPriorityChanged,
            PriorityBatchHasBeenNotCreated

        };

        #endregion


        #region Windows Service Enums

        public enum ServiceName
        {
            INVOICE_DOWNLOAD = 1,
            GET_QUERY_RESOLUTION,
            MANAGE_PRIORITY_UPDATES,
            INVOICE_ARCHIVAL,
            SUPPORTINGS_DOWNLOAD
        };

        public enum IntervalType
        {
            Day = 1,
            Hour
        };

        public enum State
        {
           Inprogress = 1,
           Idle
        };

        #endregion
    }
}
