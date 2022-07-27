using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem;

public delegate void NotificationConnectionHandler(Client sender, NotificationCallEventArgs callEventArgs);
public delegate void NotificationPhoneConnectionToPortHandler(Phone sender, NotificationPhoneConnectionToPortEventArgs eventArgs);


public class Phone
{
    public bool SomePhone { get; set; }
    public bool PhoneConnectionToPort { get; set; } //вставить симку в телефон 

    public event NotificationConnectionHandler NotificationConnection;
    public event NotificationPhoneConnectionToPortHandler StatusPhoneToPort;
    
  
    public void ConnectionWithSomeone(Client sender, NotificationCallEventArgs eventArgs)
    {
        if (PhoneConnectionToPort == true && sender.Port.isActive==true)
        {
           
            NotificationConnection?.Invoke(sender, eventArgs);
        }
        else
        {
            Console.WriteLine("Please, connect your phone to port!");
        }
        
    }

    public void ConnectPhoneToPort()
    {
        if (PhoneConnectionToPort != true)
        {
            PhoneConnectionToPort = true;
            StatusPhoneToPort?.Invoke(this, new NotificationPhoneConnectionToPortEventArgs(true));
            Console.WriteLine("Connected to port");
        }
        else
        {
            Console.WriteLine("Phone is already connected");
        }
    }

    public void DisconnectPhoneFromPort()
    {
        if (PhoneConnectionToPort != false)
        {
            PhoneConnectionToPort = false;
            StatusPhoneToPort?.Invoke(this, new NotificationPhoneConnectionToPortEventArgs(false));
            Console.WriteLine("Disconnect phone from port");
        }
        else
        {
            Console.WriteLine("Phone is already disconnect");
        }
    }

    




}


