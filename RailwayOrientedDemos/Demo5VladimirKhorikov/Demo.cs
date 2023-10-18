namespace RailwayOrientedDemos.Demo5VladimirKhorikov
{
    internal class Demo
    {
        public static void Run()
        {
            // FØR:
            var locationResult = GpsService.GetLocation();
            if (!locationResult.IsSuccess)
            {
                // handle error
                return;
            }

            var location = (Location)((Success)locationResult).Result;
            var addressResult = AddressService.GetAddress(location);
            if (!addressResult.IsSuccess)
            {
                // handle error
                return;
            }

            var address = (Address)((Success)addressResult).Result;
            var addressInfoResult = DatabaseService.GetAddressInfo(address);
            if (!addressInfoResult.IsSuccess)
            {
                // handle error
                // return;
            }
            var addressInfo = (AddressInfo)((Success)addressInfoResult).Result;

            // ETTER:
            var addressInfo2 = GpsService.GetLocation()
                .OnSuccess<Location>(AddressService.GetAddress)
                .OnSuccess<Address>(DatabaseService.GetAddressInfo);
        }
    }
}
