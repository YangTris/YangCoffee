using log4net;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Domain;

namespace Application.Services
{
	public class VnPayService : IVnPayService
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public string CreatePaymentUrl(HttpContext context, long amount)
		{
			// Get Config Info
			string vnp_Returnurl = "https://localhost:44332/Order/ThankYou";
			string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
			string vnp_TmnCode = "V9M9GBAP"; 
			string vnp_HashSecret = "O76TAXIIFBGM19W73S7QHKW6U4GLRVAM";

			// Create a payment order
			VnPayment order = new VnPayment
			{
				OrderId = DateTime.Now.Ticks, // Unique transaction ID
				Amount = amount * 100000, // Example amount: 100,000 VND
				Status = "0", // Pending payment
				CreatedDate = DateTime.Now
			};

			// Build VNPAY URL
			VnPayLibrary vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", "2.1.0");
			vnpay.AddRequestData("vnp_Command", "pay");
			vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
			vnpay.AddRequestData("vnp_Amount", (order.Amount).ToString());
			vnpay.AddRequestData("vnp_BankCode", "VNBANK");
			vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
			vnpay.AddRequestData("vnp_CurrCode", "VND");
			vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
			vnpay.AddRequestData("vnp_Locale", "vn");
			vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
			vnpay.AddRequestData("vnp_OrderType", "other");
			vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
			vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());


			// Generate payment URL
			string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
			log.InfoFormat("VNPAY URL: {0}", paymentUrl);

			return paymentUrl;
		}
	}
}
