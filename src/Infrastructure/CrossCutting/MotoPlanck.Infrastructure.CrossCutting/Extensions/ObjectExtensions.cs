namespace MotoPlanck.Infrastructure.CrossCutting.Extensions
{
    public static class ObjectExtensions
    {
        public static object MapFromParameters(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var parameters = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                if (value != null)
                {
                    var name = property.Name;
                    parameters.Add(name, value);
                }
            }

            return parameters;
        }
    }
}
