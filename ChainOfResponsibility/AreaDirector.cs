using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class AreaDirector : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel req)
		{
			Context context = new Context();
			if (req.Amount <= 400000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Bölge Müdürü - Esra BODUR";
				customerProcess.Description = "Para Çekme İşlemi Onaylandı. Müşteriye Ödeme Yapıldı";
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();

			}
			else
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = req.Amount.ToString();
				customerProcess.Name = req.Name;
				customerProcess.EmployeeName = "Bölge Müdürü - Esra BODUR";
				customerProcess.Description = "Para Çekme İşlemi Onaylanmadı. Günlük Limit Aşıldı. İşlem Gerçekleştirilemedi. Para Çekme Tutarı 400 Bin  olabilir. Daha Fazla Tutar için diğer günler şubeye gelmesi gerekiyor.";
				context.CustomerProcess.Add(customerProcess);
				context.SaveChanges();


			}
		}
	}
}
