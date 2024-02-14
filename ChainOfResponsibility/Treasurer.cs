using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class Treasurer : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel req)
		{
			Context context = new Context();
			if(req.Amount <=100000 ) 
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Veznedar - Hasan Ali ÇINAR";
				customerProcess.Description = "Para Çekme İşlemi Onaylandı. Müşteriye Ödeme Yapıldı";	
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();
	
			}
			else if(NextApprover !=null)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Veznedar - Hasan Ali ÇINAR";
				customerProcess.Description = "Para Çekme İşlemi Onaylanmadı. Günlük Limit Aşıldı. İşlem Şube Müdür Yardımcısına Yönlendirildi.";
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();
				NextApprover.ProcessRequest(req);

			}
		}
	}
}
