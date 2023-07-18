using Microsoft.AspNetCore.Components.Forms;

namespace SagaMotors_API
{
    public class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationId) : base() 
        {
            base._correlationId = correlationId;
        }
        public BaseResponse()
        {

        }
    }
}
