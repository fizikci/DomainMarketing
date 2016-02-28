using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DealerSafe.DTO;
using DealerSafe.DTO.Mark;
using System.ComponentModel;
using System.Web;

namespace DealerSafe.ServiceClient
{
    public class MarkAPI : BaseAPI
    {
        public MarkAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);
        }
        public MarkAPI(int MemberID)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);

            this.memberId = MemberID;
        }
        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["MarkServiceURL"];
        }

        public List<ResMarkList> MarkList()
        {
            return this.Call<List<ResMarkList>, ReqEmpty>(new ReqEmpty(), "MarkList");
        }

        [Description("Calculate Mark Price")]
        public CalculateMarkPricInfo CalculateMarkPric(ReqCalculateMarkPric request)
        {
            return this.Call<CalculateMarkPricInfo, ReqCalculateMarkPric>(request, "CalculateMarkPric");
        }

        [Description("Calculate Mark Price")]
        public CalculateMarkPricInfo CalculateMarkPriceWidthProductIds(ReqCalculateMarkPriceWithProductIds request)
        {
            return this.Call<CalculateMarkPricInfo, ReqCalculateMarkPriceWithProductIds>(request, "CalculateMarkPriceWidthProductIds");
        }

        [Description("Mark Price List")]
        public MarkPriceListInfo MarkPriceList(ReqMarkPriceList request)
        {
            return this.Call<MarkPriceListInfo, ReqMarkPriceList>(request, "MarkPriceList");
        }

        [Description("Patent Price List")]
        public PatentPriceListInfo PatentPriceList(ReqEmpty request)
        {
            return this.Call<PatentPriceListInfo, ReqEmpty>(request, "PatentPriceList");
        }

        [Description("Endüstriyel Tasarım Price List")]
        public TasarimPriceListInfo TasarimPriceList(ReqEmpty request)
        {
            return this.Call<TasarimPriceListInfo, ReqEmpty>(request, "TasarimPriceList");
        }

        [Description("Staff Marka Siparişleri Getir")]
        public DealerSafe.DTO.Mark.DataTable.MarkOrdersInfo GetMarkOrders(DealerSafe.DTO.Mark.DataTable.Request.MarkOrders request)
        {
            return this.Call<DealerSafe.DTO.Mark.DataTable.MarkOrdersInfo, DealerSafe.DTO.Mark.DataTable.Request.MarkOrders>(request, "GetMarkOrders");
        }

        [Description("Get Mark Order Detail")]
        public DealerSafe.DTO.Mark.MarkOrderDetailInfo GetMarkDetail(int MarkOrderID)
        {
            return this.Call<DealerSafe.DTO.Mark.MarkOrderDetailInfo, int>(MarkOrderID, "GetMarkDetail");
        }

        [Description("Get Orders Mark Name")]
        public string GetOrdersMarkName(int ordersDetailId)
        {
            return this.Call<string, int>(ordersDetailId, "GetOrdersMarkName");
        }

        [Description("Get Payment Mark Pool Detail")]
        public List<DealerSafe.DTO.Mark.MarkPaymentPoolDetailInfo> GetMarkPaymentPoolDetail(ReqSaveBrandBankReceiptNumberPool request)
        {
            return this.Call<List<DealerSafe.DTO.Mark.MarkPaymentPoolDetailInfo>, ReqSaveBrandBankReceiptNumberPool>(request, "GetMarkPaymentPoolDetail");
        }

        [Description("Get Payment Mark Order Detail")]
        public DealerSafe.DTO.Mark.MarkPaymentDetailInfo GetPaymentMarkDetail(int MarkOrderID)
        {
            return this.Call<DealerSafe.DTO.Mark.MarkPaymentDetailInfo, int>(MarkOrderID, "GetPaymentMarkDetail");
        }

        [Description("Save Add Class")]
        public DealerSafe.DTO.Mark.MarkAddClassInfo AddAnotherClass(DealerSafe.DTO.Mark.ReqMarkAddClass request)
        {
            return this.Call<DealerSafe.DTO.Mark.MarkAddClassInfo, DealerSafe.DTO.Mark.ReqMarkAddClass>(request, "AddAnotherClass");
        }

        [Description("Save New Brand Owner")]
        public DealerSafe.DTO.Mark.SaveNewBrandOwnerInfo SaveNewBrandOwner(DealerSafe.DTO.Mark.ReqSaveNewBrandOwner request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveNewBrandOwnerInfo, DealerSafe.DTO.Mark.ReqSaveNewBrandOwner>(request, "SaveNewBrandOwner");
        }

        [Description("Delete Class")]
        public DealerSafe.DTO.Mark.DeleteClassInfo DeleteClass(DealerSafe.DTO.Mark.ReqDeleteClass request)
        {
            return this.Call<DealerSafe.DTO.Mark.DeleteClassInfo, DealerSafe.DTO.Mark.ReqDeleteClass>(request, "DeleteClass");
        }
        [Description("Save New Brand Name")]
        public DealerSafe.DTO.Mark.SaveNewBrandNameInfo SaveNewBrandName(DealerSafe.DTO.Mark.ReqSaveNewBrandName request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveNewBrandNameInfo, DealerSafe.DTO.Mark.ReqSaveNewBrandName>(request, "SaveNewBrandName");
        }

       [Description("Save SaveTPEApplyNumber")]
        public DealerSafe.DTO.Mark.SaveTPEApplyNumberInfo SaveTPEApplyNumber(DealerSafe.DTO.Mark.ReqSaveTPEApplyNumber request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveTPEApplyNumberInfo, DealerSafe.DTO.Mark.ReqSaveTPEApplyNumber>(request, "SaveTPEApplyNumber");
        }
        [Description("Get the Brand Files")]
        public GetBrandFilesInfo GetBrandFiles(ReqGetBrandFiles request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetBrandFilesInfo, ReqGetBrandFiles>(request, "GetBrandFiles");
        }

        [Description("Get the Parent Brand Files")]
        public GetBrandFilesInfo GetParentBrandFiles(ReqGetParentBrandFiles request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetBrandFilesInfo, ReqGetParentBrandFiles>(request, "GetParentBrandFiles");
        }


        [Description("Delete Brand File")]
        public DeleteBrandFileInfo DeleteBrandFile(ReqDeleteBrandFile request)
        {
            return this.Call<DealerSafe.DTO.Mark.DeleteBrandFileInfo, ReqDeleteBrandFile>(request, "DeleteBrandFile");
        }

        [Description("Save Brand File")]
        public SaveBrandFileInfo SaveBrandFile(ReqSaveBrandFile request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveBrandFileInfo, ReqSaveBrandFile>(request, "SaveBrandFile");
        }

        [Description("Get Brand Remind List")]
        public GetMarkRemindsInfo GetMarkReminds(ReqGetMarkReminds request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetMarkRemindsInfo, ReqGetMarkReminds>(request, "GetMarkReminds");
        }

        [Description("Brand Remind Send")]
        public BrandRemindSendInfo BrandRemindSend(ReqBrandRemindSend request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandRemindSendInfo, ReqBrandRemindSend>(request, "BrandRemindSend");
        }

        [Description("Brand Remind Delete")]
        public BrandRemindDeleteInfo BrandRemindDelete(ReqBrandRemindDelete request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandRemindDeleteInfo, ReqBrandRemindDelete>(request, "BrandRemindDelete");
        }

        [Description("Agreed Files")]
        public AgreedFilesInfo AgreedFiles(ReqAgreedFiles request)
        {
            return this.Call<DealerSafe.DTO.Mark.AgreedFilesInfo, ReqAgreedFiles>(request, "AgreedFiles");
        }

        [Description("Save Agreed Single File Process Type")]
        public SaveAgreedSingleFileProcessTypeInfo SaveAgreedSingleFileProcessType(ReqSaveAgreedSingleFileProcessType request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveAgreedSingleFileProcessTypeInfo, ReqSaveAgreedSingleFileProcessType>(request, "SaveAgreedSingleFileProcessType");
        }

        [Description("Save Mark Order Detail")]
        public SaveMarkOrderDetailInfo SaveMarkOrderDetail(ReqSaveMarkOrderDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveMarkOrderDetailInfo, ReqSaveMarkOrderDetail>(request, "SaveMarkOrderDetail");
        }

        [Description("Confirm Mark TPE")]
        public bool MarkTPEConfirm(string markId)
        {
            return this.Call<bool, string>(markId, "MarkTPEConfirm");
        }

        [Description("Get Brand Bank Receipt Numbers")]
        public BrandBankReceiptNumbersInfo GetBrandBankReceiptNumbers(ReqBrandBankReceiptNumbers request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandBankReceiptNumbersInfo, ReqBrandBankReceiptNumbers>(request, "GetBrandBankReceiptNumbers");
        }

        [Description("Update Brand Bank Receipt Numbers")]
        public BrandBankReceiptNumbersInfo UpdateBrandBankReceiptNumber(ReqBrandBankReceiptNumbers request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandBankReceiptNumbersInfo, ReqBrandBankReceiptNumbers>(request, "UpdateBrandBankReceiptNumber");
        }

        [Description("Brand Apply Check")]
        public BrandApplyCheckInfo BrandApplyCheck(ReqBrandApplyCheck request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandApplyCheckInfo, ReqBrandApplyCheck>(request, "BrandApplyCheck");
        }

        [Description("Save Brand Detail")]
        public SaveBrandDetailInfo SaveBrandDetail(ReqSaveBrandDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveBrandDetailInfo, ReqSaveBrandDetail>(request, "SaveBrandDetail");
        }

        [Description("Gert Brand Statics for Dashboard")]
        public BrandStaticsForDashBoardInfo BrandStaticsForDashBoard(ReqBrandStaticsForDashBoard request)
        {
            return this.Call<DealerSafe.DTO.Mark.BrandStaticsForDashBoardInfo, ReqBrandStaticsForDashBoard>(request, "BrandStaticsForDashBoard");
        }

        [Description("Add Log")]
        public AddLogInfo AddLog(DealerSafe.DTO.Mark.Logs.LogsInfo request)
        {
            return this.Call<DealerSafe.DTO.Mark.AddLogInfo, DealerSafe.DTO.Mark.Logs.LogsInfo>(request, "AddLog");
        }

        [Description("Get Mark Log List")]
        public DealerSafe.DTO.Mark.MarkOrderLogInfo GetMarkLogs(DealerSafe.DTO.Mark.ReqMarkOrderLog request)
        {
            return this.Call<DealerSafe.DTO.Mark.MarkOrderLogInfo, DealerSafe.DTO.Mark.ReqMarkOrderLog>(request, "GetMarkLogs");
        }

        [Description("Save New Mark Request")]
        public SaveNewMarkRequestInfo SaveNewMarkRequest(ReqSaveNewMarkRequest request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveNewMarkRequestInfo, DealerSafe.DTO.Mark.ReqSaveNewMarkRequest>(request, "SaveNewMarkRequest");
        }

        [Description("Staff Marka Araştırmalarını Getir")]
        public DealerSafe.DTO.Mark.DataTable.MarkRequestInfo GetMarkRequest(DealerSafe.DTO.Mark.DataTable.Request.MarkRequest request)
        {
            return this.Call<DealerSafe.DTO.Mark.DataTable.MarkRequestInfo, DealerSafe.DTO.Mark.DataTable.Request.MarkRequest>(request, "GetMarkRequest");
        }

        [Description("Get Mark Request Detail Info")]
        public DealerSafe.DTO.Mark.GetMarkRequestDetailInfo GetMarkRequestDetail(DealerSafe.DTO.Mark.ReqGetMarkRequestDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetMarkRequestDetailInfo, DealerSafe.DTO.Mark.ReqGetMarkRequestDetail>(request, "GetMarkRequestDetail");
        }

        [Description("Save New Brand Name for Request")]
        public DealerSafe.DTO.Mark.SaveNewBrandNameRequestInfo SaveNewBrandNameRequest(DealerSafe.DTO.Mark.ReqSaveNewBrandRequestName request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveNewBrandNameRequestInfo, DealerSafe.DTO.Mark.ReqSaveNewBrandRequestName>(request, "SaveNewBrandNameRequest");
        }

        [Description("Save Mark Request Detail")]
        public DealerSafe.DTO.Mark.SaveMarkRequestDetailInfo SaveMarkRequestDetail(DealerSafe.DTO.Mark.ReqSaveMarkRequestDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.SaveMarkRequestDetailInfo, DealerSafe.DTO.Mark.ReqSaveMarkRequestDetail>(request, "SaveMarkRequestDetail");
        }

        [Description("Create Order For Mark Request")]
        public DealerSafe.DTO.Mark.CreateOrderForMarkRequestInfo CreateOrderForMarkRequest(DealerSafe.DTO.Mark.ReqCreateOrderForMarkRequest request)
        {
            return this.Call<DealerSafe.DTO.Mark.CreateOrderForMarkRequestInfo, DealerSafe.DTO.Mark.ReqCreateOrderForMarkRequest>(request, "CreateOrderForMarkRequest");
        }

        [Description("Get customer brand list")]
        public DealerSafe.DTO.Mark.GetCustomerBrandListInfo GetCustomerBrandList(DealerSafe.DTO.Mark.ReqGetCustomerBrandList request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerBrandListInfo, DealerSafe.DTO.Mark.ReqGetCustomerBrandList>(request, "GetCustomerBrandList");
        }

        [Description("Get customer brand list")]
        public DealerSafe.DTO.Mark.GetCustomerBrandListInfo GetCustomerBrandDetail(DealerSafe.DTO.Mark.ReqGetCustomerBrandDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerBrandListInfo, DealerSafe.DTO.Mark.ReqGetCustomerBrandDetail>(request, "GetCustomerBrandDetail");
        }

        [Description("Get Mark Request Detail Info")]
        public DealerSafe.DTO.Mark.GetCustomerMarkRequestListInfo GetCustomerMarkRequestList(DealerSafe.DTO.Mark.ReqGetCustomerMarkRequestList request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerMarkRequestListInfo, DealerSafe.DTO.Mark.ReqGetCustomerMarkRequestList>(request, "GetCustomerMarkRequestList");
        }

        [Description("Get Mark Request Detail Info")]
        public DealerSafe.DTO.Mark.GetMarkRequestDetailInfo GetMarkRequestForMemberDetail(DealerSafe.DTO.Mark.ReqGetMarkRequestDetail request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetMarkRequestDetailInfo, DealerSafe.DTO.Mark.ReqGetMarkRequestDetail>(request, "GetMarkRequestForMemberDetail");
        }

        [Description("Delete Request Class")]
        public DealerSafe.DTO.Mark.DeleteClassInfo DeleteRequestClass(DealerSafe.DTO.Mark.ReqDeleteReqeestClass request)
        {
            return this.Call<DealerSafe.DTO.Mark.DeleteClassInfo, DealerSafe.DTO.Mark.ReqDeleteReqeestClass>(request, "DeleteRequestClass");
        }

        [Description("Add Request Class")]
        public DealerSafe.DTO.Mark.MarkAddClassInfo AddRequestClass(DealerSafe.DTO.Mark.ReqAddReqeestClass request)
        {
            return this.Call<DealerSafe.DTO.Mark.MarkAddClassInfo, DealerSafe.DTO.Mark.ReqAddReqeestClass>(request, "AddRequestClass");
        }

        [Description("Update Customer Mark Request")]
        public UpdateCustomerMarkRequestInfo UpdateCustomerMarkRequest(ReqUpdateCustomerMarkRequest request)
        {
            return this.Call<DealerSafe.DTO.Mark.UpdateCustomerMarkRequestInfo, DealerSafe.DTO.Mark.ReqUpdateCustomerMarkRequest>(request, "UpdateCustomerMarkRequest");
        }

        [Description("Get Customer Profit")]
        public GetCustomerProfitInfo GetCustomerProfit(ReqGetCustomerProfit request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerProfitInfo, DealerSafe.DTO.Mark.ReqGetCustomerProfit>(request, "GetCustomerProfit");
        }

        [Description("Get Customer Profit")]
        public GetCustomerDocProfitInfo GetCustomerDocProfit(ReqGetCustomerProfit request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerDocProfitInfo, DealerSafe.DTO.Mark.ReqGetCustomerProfit>(request, "GetCustomerDocProfit");
        }


        [Description("Get Waiting for Files")]
        public GetWaitingforFilesInfo GetWaitingforFiles(ReqGetWaitingforFiles request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetWaitingforFilesInfo, DealerSafe.DTO.Mark.ReqGetWaitingforFiles>(request, "GetWaitingforFiles");
        }

        [Description("Get Waiting for Files")]
        public GetCustomerMarkFilesInfo GetCustomerMarkFiles(ReqGetCustomerMarkFiles request)
        {
            return this.Call<DealerSafe.DTO.Mark.GetCustomerMarkFilesInfo, DealerSafe.DTO.Mark.ReqGetCustomerMarkFiles>(request, "GetCustomerMarkFiles");
        }

        public bool ChangeBrandOwner(DealerSafe.DTO.Mark.ReqSaveNewBrandOwner request)
        {
            return this.Call<bool, ReqSaveNewBrandOwner>(request, "ChangeBrandOwner");
        }

        public bool ChangeMarkReqConfirm(string code)
        { 
            return this.Call<bool,string>(code, "ChangeMarkReqConfirm");
        }
        public bool ChangeMarkConfirm(ChangeMarkInfo request)
        {
            return this.Call<bool, ChangeMarkInfo>(request, "ChangeMarkConfirm");
        }

        public bool SaveBrandDekont(ReqSaveBrandDekont request)
        {
            return this.Call<bool, ReqSaveBrandDekont>(request, "SaveBrandDekont");
        }
        public bool RemoveBrandDekont(string markId)
        {
            return this.Call<bool, string>(markId, "RemoveBrandDekont");
        }

        public bool SaveBrandBankReceiptNumberPool(ReqSaveBrandBankReceiptNumberPool request)
        {
            return this.Call<bool, ReqSaveBrandBankReceiptNumberPool>(request, "SaveBrandBankReceiptNumberPool");
        }

        public bool RemoveBrandBankReceiptNumberPool(string id)
        {
            return this.Call<bool, string>(id, "RemoveBrandBankReceiptNumberPool");
        }
        public bool ChangeBrandBankReceiptNumberPoolStatu(string id)
        {
            return this.Call<bool, string>(id, "ChangeBrandBankReceiptNumberPoolStatu");
        }
        public bool ChangeBrandBankReceiptNumberPoolBrandId(ReqSaveBrandBankReceiptNumberPool request)
        {
            return this.Call<bool, ReqSaveBrandBankReceiptNumberPool>(request, "ChangeBrandBankReceiptNumberPoolBrandId");
        }

        public bool GetUsedBrandBandReceiptNumber(ReqSaveBrandBankReceiptNumberPool request)
        {
            return this.Call<bool, ReqSaveBrandBankReceiptNumberPool>(request, "GetUsedBrandBandReceiptNumber");
        }

        public int SaveMarkOrders(ReqSaveBrandBankReceiptNumberPool request)
        {
            return this.Call<int, ReqSaveBrandBankReceiptNumberPool>(request, "SaveMarkOrders");
        }

    }
}
