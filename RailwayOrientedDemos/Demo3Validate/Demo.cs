using RailwayOrientedDemos.Demo1Result;
using RailwayOrientedDemos.Demo2Composition;

namespace RailwayOrientedDemos.Demo3Validate
{
    class Contact
    {
        public string Name;
        public string Email;
    }
    internal class Demo
    {
        public static void Run()
        {
            Action<string, float> actiona = Dummy3;
            Func<string, int> funcx = Dummy;
            Func<string, float, int> funcy = Dummy2;

            Func<
                Func<Contact, Result<Contact>>,          // single track function
                Func<Result<Contact>, Result<Contact>>>  // double track function
                bind =
                oneTrackInputFunction =>
                    twoTrackInput =>
                        twoTrackInput is Success<Contact> input ? oneTrackInputFunction(input.Result)
                            : twoTrackInput;

            Func<Contact, Result<Contact>> nameNotBlank = input => input.Name == ""
                ? new Failure<Contact>("Name must not be blank")
                : new Success<Contact>(input);

            Func<Contact, Result<Contact>> name50 = input => input.Name.Length > 50
                ? new Failure<Contact>("Name must not be longer than 50 chars")
                : new Success<Contact>(input);

            Func<Contact, Result<Contact>> emailNotBlank = input => input.Email == ""
                ? new Failure<Contact>("Email must not be blank")
                : new Success<Contact>(input);

            Func<Contact, Result<Contact>> validate = contact =>
                bind(emailNotBlank)(
                    bind(name50)(
                        nameNotBlank(contact)
                    )
                );

            var validate2 = nameNotBlank.Compose(bind(name50)).Compose(bind(emailNotBlank));
        }

        static int Dummy(string x)
        {
            return x.Length;
        }
        static int Dummy2(string x, float f)
        {
            return x.Length;
        }
        
        static void Dummy3(string x, float f)
        {
            return;
        }

    }
}
