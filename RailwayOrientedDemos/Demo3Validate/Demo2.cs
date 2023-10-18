using RailwayOrientedDemos.Demo1Result;

namespace RailwayOrientedDemos.Demo3Validate
{
    internal class Demo2
    {
        public static void Run()
        {
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
        }
    }
}
