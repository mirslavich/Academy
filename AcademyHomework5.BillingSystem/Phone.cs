using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem;

public delegate void NotificationConnectionHandler(Client sender, NotificationCallEventArgs callEventArgs);
public delegate void NotificationPhoneConnectionToPortHandler(Client sender, NotificationPhoneConnectionToPortEventArgs eventArgs);


public class Phone
{
    public bool SomePhone { get; set; }
    public bool PhoneConnectionToPort { get; set; } //insert sim card into phone

    public event NotificationConnectionHandler NotificationConnection;
    public event NotificationPhoneConnectionToPortHandler StatusPhoneToPort;
    
  
    public void ConnectionWithSomeone(Client sender, NotificationCallEventArgs eventArgs)
    {
        if (PhoneConnectionToPort == true && sender.Port.isActive==true)
        {
            if (sender.Port.PhoneNumber == eventArgs.SomePhoneNumber)
            {
                Console.WriteLine("It's your number");
                return;
            }
            NotificationConnection?.Invoke(sender, eventArgs);
        }
        else
        {
            Console.WriteLine("Please, connect your phone to port!");
        }
    }

    public void ConnectPhoneToPort(Client sender)
    {
        if (PhoneConnectionToPort != true)
        {
            PhoneConnectionToPort = true;
            StatusPhoneToPort?.Invoke(sender, new NotificationPhoneConnectionToPortEventArgs(true));
            Console.WriteLine("Connected to port");
        }
        else
        {
            Console.WriteLine("Phone is already connected");
        }
    }

    public void DisconnectPhoneFromPort(Client sender)
    {
        if (PhoneConnectionToPort != false)
        {
            PhoneConnectionToPort = false;
            StatusPhoneToPort?.Invoke(sender, new NotificationPhoneConnectionToPortEventArgs(false));
            Console.WriteLine("Disconnect phone from port");
        }
        else
        {
            Console.WriteLine("Phone is already disconnect");
        }
    }
}


