using System.Collections.Generic;

namespace DBlazor.Modal
{
    public class ModalParameters
    {
        private Dictionary<string, object> _parameters;

        public ModalParameters()
        {
            _parameters = new Dictionary<string, object>();
        }

        public void Add(string parameterName, object value)
        {
            _parameters[parameterName] = value;
        }

        public T Get<T>(string parameterName)
        {
            if (!_parameters.ContainsKey(parameterName))
            {
                throw new KeyNotFoundException($"{parameterName}不存在于模态参数中");
            }

            return (T)_parameters[parameterName];
        }
    }
}
