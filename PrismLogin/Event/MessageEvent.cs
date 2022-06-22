using Prism.Events;
using PrismLogin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLogin.Event
{
    public class StudentTo:PubSubEvent<StudentInfo>
    {
    }
    public class DawerTo : PubSubEvent<StudentInfo>
    {
    }
    public class SingalrMessage : PubSubEvent<string>
    { 
    }
}
