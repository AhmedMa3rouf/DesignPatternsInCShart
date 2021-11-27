// See https://aka.ms/new-console-template for more information

// this is an implementation for Mediator Design Pattern Please review https://dotnettutorials.net/lesson/mediator-design-pattern/
//Step5: Client
IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();
User Ram = new ConcreteUser(facebookMediator, "Ram");
User Dave = new ConcreteUser(facebookMediator, "Dave");
User Smith = new ConcreteUser(facebookMediator, "Smith");
User Rajesh = new ConcreteUser(facebookMediator, "Rajesh");
User Sam = new ConcreteUser(facebookMediator, "Sam");
User Pam = new ConcreteUser(facebookMediator, "Pam");
User Anurag = new ConcreteUser(facebookMediator, "Anurag");
User John = new ConcreteUser(facebookMediator, "John");
facebookMediator.RegisterUser(Ram);
facebookMediator.RegisterUser(Dave);
facebookMediator.RegisterUser(Smith);
facebookMediator.RegisterUser(Rajesh);
facebookMediator.RegisterUser(Sam);
facebookMediator.RegisterUser(Pam);
facebookMediator.RegisterUser(Anurag);
facebookMediator.RegisterUser(John);
Dave.Send("Try Send Message To All Users");
Console.WriteLine();
Rajesh.Send("Wow this is a good pattern");
Console.Read();

//Step 1 Creating Mediator
public interface IFacebookGroupMediator
{
    void SendMessage(string msg, User user);
    void RegisterUser(User user);
}

//Step 2 Creating ConcreteMediator
public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
{
    List<User> _users = new List<User>();
    public void RegisterUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string msg, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
                u.Receive(msg);
        }
    }
}

//Step 3 Creating ConcreteMediator
public abstract class User
{
    protected IFacebookGroupMediator mediator;
    protected string name;
    public User(IFacebookGroupMediator mediator, string name)
    {
        this.mediator = mediator;
        this.name = name;
    }
    public abstract void Send(string message);
    public abstract void Receive(string message);
}

//Step 4 Creating ConcreteMediator
public class ConcreteUser : User
{
    public ConcreteUser(IFacebookGroupMediator mediator, string name)
        :base(mediator, name) { }
    public override void Receive(string message)
    {
        Console.WriteLine(this.name + ": Received Message:" + message);
    }

    public override void Send(string message)
    {
        Console.WriteLine(this.name + ": Sending Message=" + message + "\n");
        mediator.SendMessage(message, this);
    }
}