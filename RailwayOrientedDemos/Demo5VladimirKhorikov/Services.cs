namespace RailwayOrientedDemos.Demo5VladimirKhorikov
{
    internal class GpsService
    {
        public static Result GetLocation()
        {
            return new Success(new Location());
        }
    }

    class AddressService
    {
        public static Result GetAddress(Location location)
        {
            return new Success(new Address());
        }
    }

    class DatabaseService
    {
        public static Result GetAddressInfo(Address address)
        {
            return new Success(new AddressInfo());
        }
    }




    class Location{}
    class Address{}
    class AddressInfo{}
}
