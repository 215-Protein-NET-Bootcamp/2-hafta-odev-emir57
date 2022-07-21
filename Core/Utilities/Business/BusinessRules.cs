using Core.Utilities.Result;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (IResult logic in logics)
            {
                if (logic.Success == false)
                    return logic;
            }
            return null;
        }
    }
}
