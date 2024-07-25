using Journey.Communication.Requests;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public void Execute(RequestRegisterTripJson request)
        {
            Validate(request);
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new JourneyException(ResourceErrorMessages.NAME_EMPTY);
            }

            if (request.StartDate.Date < DateTime.UtcNow.Date)
            {
                throw new JourneyException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
            }

            if (request.StartDate.Date >= request.EndDate.Date)
            {
                throw new JourneyException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
            }
        }
    }
}
