using System.Net;
using System.Net.Mail;

namespace EmailSender
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			string fromAddress = "from_address@mail.ru";
			string toAddress = "to_address";
			string subject = "Utilization Report (This week, Monday-Friday)"; 
			string account = "Khasan Rashidov";
			string dateFrom = "2023-07-10";
			string dateTo = "2023-07-14";
			string totalSpentTime = "40";
			string projectTimeTotal = "30";
			string projectTimePercentage = "75";
			string vacationTimeTotal = "5";
			string vacationTimePercentage = "12.5";
			string benchTimeTotal = "5";
			string benchTimePercentage = "12.5";

			string body = $"<h1>Utilization Report for <span style=\"color: darkblue;\">{account}</span> from {dateFrom} to {dateTo}:</h1>" +
			$"<p style=\"font-size: 16px;\"><b>Total spent time:</b> {totalSpentTime} hours</p>" +
			$"<p style=\"font-size: 16px;\"><b>Project time:</b> {projectTimeTotal} hours (<span style=\"font-weight: bold;\">{projectTimePercentage}%</span>)</p>" +
			$"<p style=\"font-size: 16px;\"><b>Vacation time:</b> {vacationTimeTotal} hours (<span style=\"font-weight: bold;\">{vacationTimePercentage}%</span>)</p>" +
			$"<p style=\"font-size: 16px;\"><b>Bench time:</b> {benchTimeTotal} hours (<span style=\"font-weight: bold;\">{benchTimePercentage}%</span>)</p>";

			MailMessage message = new(fromAddress, toAddress, subject, body)
			{
				IsBodyHtml = true
			};

			SmtpClient smtpClient = new("smtp.mail.ru", 587)
			{
				EnableSsl = true,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress, "your_password")
			};

			try
			{
				smtpClient.Send(message);
				Console.WriteLine("Email sent successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error sending email: " + ex.Message);
			}
			finally
			{
				smtpClient.Dispose();
				message.Dispose();
			}
		}
	}
}
