using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	////////////////////////////////////
	public String getCuil(String ApellidoNombre, int genero)
    {
		
		try
		{
			
			String result = "";
			String DNI = GetRandomDNI();
			String lastNumber = GetLastNumber();

			if (genero == 1)
			{
				result = "20-" + DNI + "-" + lastNumber;

			}
			else
			{
				result = "27-" + DNI + "-" + lastNumber;
			}
			 
			
			return result;
		}
		catch (Exception e)
		{
			ExceptionCUILSrv faultContract = new ExceptionCUILSrv();
			faultContract.StatusCode = "ERR-0001";
			faultContract.Message = "ERROR AL OBTENER CUIL" ;
			faultContract.Description = e.Message;

			throw new FaultException<ExceptionCUILSrv>(faultContract);
		}

		
    }

	private string GetRandomDNI()
    {
		Random generator = new Random();
		int r = generator.Next(10000000, 100000000);

		return r.ToString();
	}

	private string GetLastNumber()
	{
		Random generator = new Random();
		int r = generator.Next(1, 9);

		return r.ToString();
	}

}
