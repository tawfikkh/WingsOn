using System.Linq;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class CustomBookingRepository : BookingRepository
    {
        public override void Save(Booking booking)
        {
            // generate new booking number if empty
            if (booking.Number == null)
            {
                var nextId = Repository.Max(p => int.TryParse(p.Number.Replace("WO-", ""), out int result)
                    ? result
                    : 0) + 1;

                booking.Number = "WO-" + nextId;
            }

            base.Save(booking);
        }
    }
}
