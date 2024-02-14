using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class Manager : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel req)
		{
			Context context = new Context();
			if (req.Amount <= 250000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Şube Müdürü - Hatice ASLAN";
				customerProcess.Description = "Para Çekme İşlemi Onaylandı. Müşteriye Ödeme Yapıldı";
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();

			}
			else if (NextApprover != null)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Şube Müdürü - Hatice ASLAN";
				customerProcess.Description = "Para Çekme İşlemi Onaylanmadı. Günlük Limit Aşıldı. İşlem Bölge Müdürüne Yönlendirildi.";
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();
				NextApprover.ProcessRequest(req);

			}
		}
	}
}
