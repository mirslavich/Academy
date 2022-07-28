using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem;

public delegate void NotificationCallHandler(Client sender, NotificationCallEventArgs eventsArgs);
public delegate void NotificationChangeTariff(Client sender, NotificationChangeTariffEventArgs eventsArgs);

public class Client
{
    public Guid Agreement { get;}
    public string FirstName { get; }
    public string SecondName { get; }
    public DateTime DateOfBirth { get; }
    public string Address { get; }
    public Phone Phone { get; }
    public Port Port { get; }
    public Tariff Tariff { get; set; }
    public double Wallet { get; set; }
    public event NotificationCallHandler NotifyCall;
    public event NotificationChangeTariff NotifyChangeTariff;

    public Client(Guid agreement, string firstName, string secondName, 
        DateTime dateOfBirth, string adress, Phone phone, Port port, Tariff tariff)
    {
        Agreement = agreement;
        FirstName = firstName;
        SecondName = secondName;
        DateOfBirth = dateOfBirth;
        Address = adress;
        Phone = phone;
        Port = port;
        Tariff = tariff;
    }

    public void ConnectPhoneToPort()
    {
        Phone.ConnectPhoneToPort(this);
    }

    public void DisconnectPhoneFromPort()
    {
        Phone.DisconnectPhoneFromPort(this);
    }
    public void Call(int somePhoneNumber)   
    {
        if ((this.Port.isActive && this.Phone.SomePhone) != false)
        {
            NotifyCall?.Invoke(this, new NotificationCallEventArgs(somePhoneNumber));
        }
        else
        {
            Console.WriteLine("Net isn't working!Check please port and phone!");
        }
    }

    public void ChangeTariffPlan(TariffPlans newTariff)
    {
        NotifyChangeTariff?.Invoke(this, new NotificationChangeTariffEventArgs(newTariff));
    }

    public void PayForBilling (double sum)
    { 
        Wallet+=sum;
        Console.WriteLine($"you put {sum} on your balance");
    }
}
